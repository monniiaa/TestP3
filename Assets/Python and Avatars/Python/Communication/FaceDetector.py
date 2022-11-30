import enum
from tokenize import String
from turtle import color
from imutils import face_utils
import dlib
import cv2
import LandmarkDetector

def DetectFaceInImage(img):
    image = cv2.imread(img)
    image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    image = cv2.resize(image,(500, 500))
    
    detector = dlib.get_frontal_face_detector()
    rects = detector(image, 1)
    
    eyeArea = LandmarkDetector.CalculateEyeArea(image, rects[0], predictor= dlib.shape_predictor("ShapePredictor.dat"))
    NoseLength = LandmarkDetector.CalculateNoseLength(image, rects[0], predictor= dlib.shape_predictor("ShapePredictor.dat"))
    jawWidth = LandmarkDetector.CalculateJawWidth(image, rects[0], predictor= dlib.shape_predictor("ShapePredictor.dat"))
    eyebrowWidth = LandmarkDetector.CalculateEyebrowWidth(image, rects[0], predictor= dlib.shape_predictor("ShapePredictor.dat"))
    mouthWidth = LandmarkDetector.CalculateLipWidth(image, rects[0], predictor= dlib.shape_predictor("ShapePredictor.dat"))
    return eyeArea, NoseLength, jawWidth, eyebrowWidth, mouthWidth
    
def DetectFace(img):
    image = cv2.imread(img)
    #image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    image = cv2.resize(image,(500, 500))
    
    detector = dlib.get_frontal_face_detector()
    rects = detector(image, 1)
    return rects[0]
        
        