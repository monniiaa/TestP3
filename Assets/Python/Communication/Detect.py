#First installing the teachable-machine
from distutils.log import debug
from teachable_machine import TeachableMachine
import cv2
import cvlib as cv
import numpy as np
import FaceDetector
import math
import sys
from PIL import Image, ImageOps
from keras.models import load_model

FACE_PROTO = "weights/opencv_face_detector.pbtxt"
FACE_MODEL = "weights/opencv_face_detector_uint8.pb"
FACE_NET = cv2.dnn.readNet(FACE_MODEL, FACE_PROTO)
MODEL_MEAN_VALUES = (78.4263377603, 87.7689143744, 114.895847746)

GENDER_PROTO = "weights/gender_deploy.prototxt"
GENDER_MODEL = "weights/gender_net.caffemodel"
GENDER_NET = cv2.dnn.readNet(GENDER_MODEL, GENDER_PROTO)
GENDER_LIST = ["Male", "Female"]
box_padding = 20

def DetectClothes(img_path):
#Importing my model as a Keras file
    IMGPath = 'IMG-1108.jpg'
    my_model = TeachableMachine(model_path='keras_model.h5', labels_file_path="labels.txt", model_type='h5')

    result = my_model.classify_image(img_path)
    print('highest_class_id:', result['highest_class_id'])
    print('all_predictions:', result['all_predictions'])


def DetectBottums(img_path):
#Importing my model as a Keras file
    np.set_printoptions(suppress=True)

    model = load_model('pants_detection/pants_model.h5', compile=False)

    # Load the labels
    class_names = open('pants_detection/pants_labels.txt', 'r').readlines()
    path= 'IMG-1088.jpg'
    data = np.ndarray(shape=(1, 224, 224, 3), dtype=np.float32)

# Replace this with the path to your image
    image = Image.open(path).convert('RGB')

    size = (224, 224)
    image = ImageOps.fit(image, size, Image.Resampling.LANCZOS)

#turn the image into a numpy array
    image_array = np.asarray(image)

# Normalize the image
    normalized_image_array = (image_array.astype(np.float32) / 127.0) - 1

# Load the image into the array
    data[0] = normalized_image_array

# run the inference
    prediction = model.predict(data)
    index = np.argmax(prediction)
    class_name = class_names[index]
    confidence_score = prediction[0][index]

    print('Class:', class_name, end='')
    print('Confidence score:', confidence_score)


def get_face_box (net, frame, conf_threshold = 0.7):
  frame_copy = frame.copy()
  frame_height = frame_copy.shape[0]
  frame_width = frame_copy.shape[1]
  blob = cv2.dnn.blobFromImage(frame_copy, 1.0, (300, 300), [104, 117, 123], True, False)

  net.setInput(blob)
  detections = net.forward()
  boxes = []

  for i in range(detections.shape[2]):
    confidence = detections[0, 0, i, 2]

    if confidence > conf_threshold:
      x1 = int(detections[0, 0, i, 3] * frame_width)
      y1 = int(detections[0, 0, i, 4] * frame_height)
      x2 = int(detections[0, 0, i, 5] * frame_width)
      y2 = int(detections[0, 0, i, 6] * frame_height)
      boxes.append([x1, y1, x2, y2])
      cv2.rectangle(frame_copy, (x1, y1), (x2, y2), (0, 255, 0), int(round(frame_height / 150)), 8)

  return frame_copy, boxes

def DetectGender(path):
    image = cv2.imread(path)
    resized_image = cv2.resize(image, (640, 480))

    frame = resized_image.copy()
    frame_face, boxes = get_face_box(FACE_NET, frame)
    for box in boxes:
        face = frame[max(0, box[1] - box_padding):min(box[3] + box_padding, frame.shape[0] - 1), \
            max(0, box[0] - box_padding):min(box[2] + box_padding, frame.shape[1] - 1)]

        blob = cv2.dnn.blobFromImage(face, 1.0, (227, 227), MODEL_MEAN_VALUES, swapRB = False)
        GENDER_NET.setInput(blob)
        gender_predictions = GENDER_NET.forward()
        gender = GENDER_LIST[gender_predictions[0].argmax()]

        label = gender
        return(gender)