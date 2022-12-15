#Import Libraries
#inspired by Educative
import os,argparse,uuid
import dlib,cv2,filetype
import numpy as np
from imutils import face_utils
import config
import webcolors
from sklearn.cluster import KMeans
from collections import Counter
from PIL import Image, ImageEnhance



def extract_faces_landmarks(img, detector, predictor):
    # Convert image to grayscale
    img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # Detect faces in the gray scale frame
    faces = detector(img_gray, 0)

    for idx, face in enumerate(faces):
        landmarks = predictor(img_gray, face)
        landmarks_points = []
        for n in range(0, 68):
            x = landmarks.part(n).x
            y = landmarks.part(n).y
            landmarks_points.append((x, y))
        yield {
                "face": face
                , "landmarks": landmarks_points
        }

def mask_landmark(img,pts):
    # Create a mask
    mask = np.ones(img.shape[:2],np.uint8) #np.zeros(img.shape[:2],np.uint8)
    cv2.drawContours(mask,[pts],-1,(0,0,0),-1,cv2.LINE_AA)
    masked_img = cv2.bitwise_and(img,img,mask=mask)

    return masked_img

def extract_face_skin_area(img,landmarks_points,shape,face_landmarks,face):
    # Convert image to grayscale
    img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    #creating an array of zeros, with the same size as the original face image.
    face_mask = np.zeros_like(img_gray)
    #Creates an array containg all the landmark points
    points = np.array(landmarks_points, np.int32)
    #creates a convexhull over all the points of the landmarks that are the outer part of the face
    convexhull = cv2.convexHull(points)

    head_mask = cv2.fillConvexPoly(face_mask, convexhull, 255)

    masked_img = cv2.bitwise_and(img,img, mask=head_mask)
    for name, (i, j) in (
              face_landmarks[0]  # mouth
            , face_landmarks[1]  # inner_mouth
            , face_landmarks[2]  # right_eyebrow
            , face_landmarks[3]  # left_eyebrow
            , face_landmarks[4]  # right_eye
            , face_landmarks[5]  # left_eye
            ):
        pts = np.array([shape[i:j]])
        masked_img = mask_landmark(masked_img, pts)


    (x, y, w, h) = face_utils.rect_to_bb(face)
    x = 0 if x < 0 else x
    y = 0 if y < 0 else y
    masked_face = masked_img[y:y + h, x:x + w]

    masked_face = cv2.GaussianBlur(masked_face, (3, 3), 0)
    return masked_face


def remove_black_areas(estimator_labels, estimator_cluster):
    # Check for black
    hasBlack = False

    # Get the total number of occurence for each color
    occurence_counter = Counter(estimator_labels)

    # Quick lambda function to compare to lists
    compare = lambda x, y: Counter(x) == Counter(y)

    # Loop through the most common occuring color
    for x in occurence_counter.most_common(len(estimator_cluster)):

        # Quick List comprehension to convert each of RBG Numbers to int
        color = [int(i) for i in estimator_cluster[x[0]].tolist()]

        # Check if the color is [0,0,0] that if it is black
        if compare(color, [0, 0, 0]) == True:
            # delete the occurence
            del occurence_counter[x[0]]
            # remove the cluster
            hasBlack = True
            estimator_cluster = np.delete(estimator_cluster, x[0], 0)
            break

    return (occurence_counter, estimator_cluster, hasBlack)


def get_color_information(estimator_labels, estimator_cluster, hasThresholding=False):
    # Variable to keep count of the occurence of each color predicted
    occurence_counter = None

    # Output list variable to return
    colorInformation = []

    # Check for Black
    hasBlack = False

    # If a mask has be applied, remove th black
    if hasThresholding == True:

        (occurence, cluster, black) = remove_black_areas(estimator_labels, estimator_cluster)
        occurence_counter = occurence
        estimator_cluster = cluster
        hasBlack = black

    else:
        occurence_counter = Counter(estimator_labels)

    # Loop through all the predicted colors
    for x in occurence_counter.most_common(len(estimator_cluster)):
        index = (int(x[0]))

        # Quick fix for index out of bound when there is no threshold
        index = (index - 1) if ((hasThresholding & hasBlack) & (int(index) != 0)) else index

        # Get the color number into a list
        color = estimator_cluster[index].tolist()

        # make the dictionay of the information
        colorInfo = {"color": color }

        # Add the dictionary to the list
        colorInformation.append(colorInfo)

    return colorInformation


def extract_dominant_colors(image, number_of_colors=5, hasThresholding=False):
    # Quick Fix Increase cluster counter to neglect the black(Read Article)
    if hasThresholding == True:
        number_of_colors += 1

    # Taking Copy of the image
    img = image.copy()
    img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    img = img.reshape((img.shape[0] * img.shape[1]), 3)

    # Creating Kmeans estimator
    estimator = KMeans(n_clusters=number_of_colors, random_state=0)
    #using the estimator on the image
    estimator.fit(img)
    # Getting Color Information
    dominantColors = get_color_information(estimator.labels_, estimator.cluster_centers_, hasThresholding)
    #returning the dominant color of the first cluster center
    colorVal = (int(dominantColors[0].get('color')[2]), int(dominantColors[0].get('color')[1]), int(dominantColors[0].get('color')[0]))
    return colorVal

def detect_skin_color(input_path:str,display_output:bool = False):
    #dlib face Predictor
    detector  = dlib.get_frontal_face_detector()
    predictor = dlib.shape_predictor("ShapePredictor.dat") 
    # Read Input Image
    img = cv2.imread(input_path)
    # Preserve a copy of the original
    frame = img.copy()
    # Convert it to gray scale
    gray_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # Loop over the faces detected
    for idx, face_landmarks in enumerate(extract_faces_landmarks(frame, detector, predictor)):
        frame = img.copy()

        face = face_landmarks['face']
        landmark_points = face_landmarks['landmarks']
        shape = predictor(gray_frame,face)
        shape = face_utils.shape_to_np(shape)

        # List containing the facial features
        face_landmarks = list(face_utils.FACIAL_LANDMARKS_IDXS.items())
        
        #Extract Face Skin Area
        face_skin_area = extract_face_skin_area(frame,landmark_points, shape, face_landmarks,face)
    
        colorval = extract_dominant_colors(face_skin_area,number_of_colors=5,hasThresholding=True)

    return colorval[2], colorval[1], colorval[0]

