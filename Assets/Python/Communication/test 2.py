
from distutils.log import debug
from socket import socket
import UdpComms as U
import time
import Detect
import FaceDetector
import dlib
import LandmarkDetector
import detect_hair_color
import detect_skin_color
import recognize_eyes_color
import Clothing_dominant_colors


image = "FaceShots/face0.png"

gender = Detect.DetectGender(image)
eyecolor = recognize_eyes_color.recognize_eyes_color(image)
eyeArea, NoseLength, jawWidth, eyebrowWidth, mouthWidth = FaceDetector.DetectFaceInImage(image)
skinR, skinG, skinB = detect_skin_color.detect_skin_color(image)
hairR, hairG, hairB = detect_hair_color.detect_hair_color(image)
print(gender)
print(eyecolor)
print(eyeArea)
print(jawWidth)
print (NoseLength)
print(eyebrowWidth)
print(mouthWidth)