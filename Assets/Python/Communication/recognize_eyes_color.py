
#Import Libraries
import os,argparse,uuid,math
import mediapipe,cv2,filetype
import numpy as np
import config
import webcolors
from sklearn.cluster import KMeans
from collections import Counter

#To reduce false results increase the confidence level
MIN_CONFIDENCE_LEVEL = 0.5

def initialize_mediapipe():
    """
    Initializing mediapipe sub-modules
    """
    #Enable the face detection sub-module
    mpFaceDetection = mediapipe.solutions.face_detection.FaceDetection(MIN_CONFIDENCE_LEVEL)

    #Enable the face mesh sub-module
    mpFaceModule    = mediapipe.solutions.face_mesh

    return mpFaceDetection,mpFaceModule


def remove_black_areas(estimator_labels, estimator_cluster):
    """
    Remove out the black pixel from the selected area
    By default OpenCV does not handle transparent images and replaces those with zeros (black).
    Useful when thresholding is used in the image.
    """
    # Check for black
    hasBlack = False

    # Get the total number of occurance for each color
    occurance_counter = Counter(estimator_labels)

    # Quick lambda function to compare to lists
    compare = lambda x, y: Counter(x) == Counter(y)

    # Loop through the most common occuring color
    for x in occurance_counter.most_common(len(estimator_cluster)):

        # Quick List comprehension to convert each of RBG Numbers to int
        color = [int(i) for i in estimator_cluster[x[0]].tolist()]

        # Check if the color is [0,0,0] that if it is black
        if compare(color, [0, 0, 0]) == True:
            # delete the occurance
            del occurance_counter[x[0]]
            # remove the cluster
            hasBlack = True
            estimator_cluster = np.delete(estimator_cluster, x[0], 0)
            break

    return (occurance_counter, estimator_cluster, hasBlack)

def get_color_information(estimator_labels, estimator_cluster, hasThresholding=False):
    """
    Extract color information based on predictions coming from the clustering.
    Accept as input parameters estimator_labels (prediction labels)
                               estimator_cluster (cluster centroids)
                               has_thresholding (indicate whether a mask was used).
    Return an array the extracted colors.
    """
    # Variable to keep count of the occurance of each color predicted
    occurance_counter = None

    # Output list variable to return
    colorInformation = []

    # Check for Black
    hasBlack = False

    # If a mask needs to be applied, remove the black
    if hasThresholding == True:
        (occurance, cluster, black) = remove_black_areas(estimator_labels, estimator_cluster)
        occurance_counter = occurance
        estimator_cluster = cluster
        hasBlack = black
    else:
        occurance_counter = Counter(estimator_labels)

    # Get the total sum of all the predicted occurences
    totalOccurance = sum(occurance_counter.values())

    # Loop through all the predicted colors
    for x in occurance_counter.most_common(len(estimator_cluster)):
        index = (int(x[0]))

        # Quick fix for index out of bound when there is no threshold
        index = (index - 1) if ((hasThresholding & hasBlack) & (int(index) != 0)) else index

        # Get the color number into a list
        color = estimator_cluster[index].tolist()

        # Get the percentage of each color
        color_percentage = (x[1] / totalOccurance)

        # make the dictionay of the information
        colorInfo = {"cluster_index": index, "color": color, "color_percentage": color_percentage}

        # Add the dictionary to the list
        colorInformation.append(colorInfo)

    return colorInformation

def extract_dominant_colors(image, number_of_colors=5, hasThresholding=False):
    """
    Accept as input parameters image -> the input image in BGR format (8 bit / 3 channel)
                                     -> the number of colors to be extracted.
                                     -> hasThresholding indicate whether a thresholding mask was used.
    Leverage machine learning by using an unsupervised clustering algorithm (Kmeans Clustering) to cluster
    the image pixels data based on their RGB values.
    """
    # Quick Fix Increase cluster counter to neglect the black(Read Article)
    if hasThresholding == True:
        number_of_colors += 1

    # Taking Copy of the image
    img = image.copy()

    # Convert Image into RGB Colours Space
    img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

    # Reshape Image
    img = img.reshape((img.shape[0] * img.shape[1]), 3)

    # Initiate KMeans Object
    estimator = KMeans(n_clusters=number_of_colors, random_state=0)

    # Fit the image
    estimator.fit(img)

    # Get Colour Information
    colorInformation = get_color_information(estimator.labels_, estimator.cluster_centers_, hasThresholding)
    return colorInformation

def get_top_dominant_color(dominant_colors):
    """
    Return the top dominant color out of the dominant colors
    """
    def find_closest_color(req_color):
        # This is the function which converts an RGB pixel to a color name
        min_colours = {}
        for name, key in webcolors.CSS3_HEX_TO_NAMES.items():
            r_c, g_c, b_c = webcolors.hex_to_rgb(name)
            rd = (r_c - req_color[0]) ** 2
            gd = (g_c - req_color[1]) ** 2
            bd = (b_c - req_color[2]) ** 2
            min_colours[(rd + gd + bd)] = key
            closest_name = min_colours[min(min_colours.keys())]
        return closest_name

    

    color_value = (
                  int(dominant_colors[0].get('color')[2])
                , int(dominant_colors[0].get('color')[1])
                , int(dominant_colors[0].get('color')[0])
                )

    closest_color_name = find_closest_color(
        (
            int(dominant_colors[0].get('color')[0])
           ,int(dominant_colors[0].get('color')[1])
           ,int(dominant_colors[0].get('color')[2])
        )
    )

    if closest_color_name == "black" or closest_color_name == "brown" or closest_color_name == "burlywood" or closest_color_name == "chocolate" or closest_color_name == "cornsilk" or closest_color_name == "darkgoldenrod" or closest_color_name == "sandybrown" or closest_color_name == "tan" or closest_color_name == "saddlebrown": 
        closest_color_name = 1 #brown
    elif closest_color_name == "chartreuse" or closest_color_name == "darkgreen" or closest_color_name == "darkkhaki" or closest_color_name == "darkolivegreen" or closest_color_name == "darkseagreen" or closest_color_name == "green" or closest_color_name == "greenyellow" or closest_color_name == "khaki" or closest_color_name == "lightgreen" or closest_color_name == "darkgreen" or closest_color_name == "limegreen" or closest_color_name == "olive": 
        closest_color_name = 2#green
    else:
         closest_color_name = 0#blue
    return closest_color_name
############################################################################################
def find_eye_center(frame, eye_box_coordinates):
    """
    Localize the eye center point
    """
    np_eye_landmarks = np.array( eye_box_coordinates )
    # Devise a baunding rectangle around the coordinates specified
    (x, y, w, h) = cv2.boundingRect(np_eye_landmarks)

    # Draws a rectangle around the coordinates specified
    #cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 255, 255), 3)

    #Calculating the center point of the rectangle
    eye_center = [int(x+w/2) , int(y+h/2)]
    #cv2.circle(frame, (eye_center[0], eye_center[1]), 3, color=(255, 255, 0),thickness=-1)

    return eye_center

def segment_right_eye_area(img,face_coordinates):
    """
    Segment the right eye area based on the face coordinates
    """
    #Calculating a thickness factor for drawing
    img_height, img_width, img_channels = img.shape
    thickness_factor = math.floor(img_width * img_height / ((img_width + img_height) * 100))

    # Right eye region of interest
    r_eye_coordinates = [face_coordinates[385], face_coordinates[387],
                         face_coordinates[380], face_coordinates[373]]

    #Localize the center of the eye
    eye_center = find_eye_center(img,r_eye_coordinates)
    #print('Right eye_center',eye_center)

    #Calculate the distance between edges
    dst = int((face_coordinates[374][1] - face_coordinates[386][1]) )

    landmarks_points = []
    for n in (385,386,374,380): #,373
        x = face_coordinates[n][0]
        y = face_coordinates[n][1]
        landmarks_points.append((x, y))
    landmarks_points.append((eye_center[0], eye_center[1]))

    points = np.array(landmarks_points, np.int32)
    convexhull = cv2.convexHull(points)
    (x, y, w, h) = cv2.boundingRect(convexhull)

    #Region of interest
    roi = img[y:y + h, x:x + w].copy()
    #cv2.imshow('Right Eye roi',roi)
    #cv2.waitKey(0)

    #Extract the list of dominant colors
    dominant_colors = extract_dominant_colors(roi, hasThresholding=True)
    #Get the top dominant color
    top_color_name = get_top_dominant_color(dominant_colors)


    return roi,img, top_color_name


##############################################################################################
def grab_face_coordinates(img, img_landmarks):
    """
    Grab the coordinates of the face landmarks
    """
    face_coordinates = np.array([[int(min([landmark.x * img.shape[1], img.shape[1] - 1]))
                                , int(min([landmark.y * img.shape[0], img.shape[0] - 1]))]
                          for landmark in img_landmarks.landmark]).astype(int)
    face_coordinates[face_coordinates < 0] = 0
    return face_coordinates

def recognize_eyes_color(input_path:str,display_output:bool = False):
    """
    Recognize the eyes color of the faces showing within the image
    """
    #Initialize the mediapipe sub-modules
    mpFaceDetection,mpFaceModule = initialize_mediapipe()

    # Read Input Image
    img = cv2.imread(input_path)

    # Preserve a copy of the original
    frame = img.copy()

    # Convert it to rgb format
    rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

    # Detect faces in the rgb frame
    faces = mpFaceDetection.process(rgb_frame)

    output      = []
    output_info = []

    # Output a message showing the faces detected
    output_msg = {'msg':"{} face(s) detected.".format(len(faces.detections)),'category':"info"}
    output_info.append(output_msg)

    mpFaceMesh = mpFaceModule.FaceMesh(
        static_image_mode=True
        , max_num_faces=len(faces.detections)
        , refine_landmarks=True
        , min_detection_confidence=MIN_CONFIDENCE_LEVEL
    )
    landmarks = mpFaceMesh.process(rgb_frame).multi_face_landmarks

    # Loop over the faces detected
    for idx, (face_detected,face_landmarks) in enumerate(zip(faces.detections,landmarks)):
        # At each iteration take a new frame copy
        frame = img.copy()

        #Determine the face bounding box
        relativeBoundingBox = face_detected.location_data.relative_bounding_box
        frameHeight,frameWidth,frameChannels = frame.shape
        faceBoundingBox = int(relativeBoundingBox.xmin*frameWidth)  \
                         ,int(relativeBoundingBox.ymin*frameHeight) \
                         ,int(relativeBoundingBox.width*frameWidth) \
                         ,int(relativeBoundingBox.height*frameHeight)

        #Draws a rectangle over the face bounding box
        cv2.rectangle(frame, faceBoundingBox, (0,255,0),3)

        #Grab the coordinate of the face landmark points
        face_coordinates = grab_face_coordinates(frame, face_landmarks)

        #Process Right Eye
        roi,img,top_color_name= segment_right_eye_area(frame
                                                                                      , face_coordinates
                                                                                        )

    mpFaceMesh.close()
    mpFaceDetection.close()
    return top_color_name


    # Parsing command line arguments entered by user


