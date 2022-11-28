import enum
import imp
from tokenize import String
from turtle import color
from cv2 import sqrt
from imutils import face_utils
from matplotlib import image
import numpy as np
import imutils
import dlib
import cv2
import copy
import time as t
import math
    
def ComputeFacialLandmarkRegions(image, rect, predictor):
    shape = predictor(image, rect)
    shape = face_utils.shape_to_np(shape)

    output = face_utils.visualize_facial_landmarks(image, shape)
    #grayOutput = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    cv2.imshow("Image", output)
    cv2.waitKey(0)

def ComputeLandmarks(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape) 
  i=1
  for (x, y) in shape:
    cv2.putText(image, str(i), (x - 10, y - 10),
		cv2.FONT_HERSHEY_SIMPLEX, 0.3, (0, 200, 0), 2)
    cv2.circle(image, (x, y), 1, (0, 0, 255), -1)
    i+=1

    
def CalculateEyeArea(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape)

  image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
  x1, y1 = shape[37]
  x2, y2 = shape[38] 
  x3, y3 = shape[42]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Rtri1 = absval/2

  x1, y1 = shape[38]
  x2, y2 = shape[39] 
  x3, y3 = shape[42]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Rtri2 = absval/2

  x1, y1 = shape[39]
  x2, y2 = shape[41] 
  x3, y3 = shape[42]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Rtri3 = absval/2

  x1, y1 = shape[39]
  x2, y2 = shape[40] 
  x3, y3 = shape[41]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Rtri4 = absval/2

  Rarea = Rtri1+Rtri2+Rtri3+Rtri4

  x1, y1 = shape[43]
  x2, y2 = shape[44] 
  x3, y3 = shape[48]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Ltri1 = absval/2

  x1, y1 = shape[44]
  x2, y2 = shape[45] 
  x3, y3 = shape[48]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Ltri2 = absval/2

  x1, y1 = shape[45]
  x2, y2 = shape[47] 
  x3, y3 = shape[48]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Ltri3 = absval/2

  x1, y1 = shape[45]
  x2, y2 = shape[46] 
  x3, y3 = shape[47]
  absval = abs(x1*(y2-y3) + x2*(y3-y1)+x3*(y1-y2))
  Ltri4 = absval/2

  Larea = Ltri1+Ltri2+Ltri3+Ltri4
  TotalArea = Rarea + Larea
  TotalArea = (TotalArea/ (image.shape[0] + image.shape[1]))

  return TotalArea
    
        

def CalculateNoseLength(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape)
  image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
  x1, y1 = shape[28]
  x2, y2 = shape[34]
  x1 = int(x1)
  x2 = int(x2)
  y1 = int(y1)
  y2 = int(y2)

  width = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
  width = (width/ (image.shape[0] + image.shape[1]))
  return width

def CalculateLipWidth(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape)
  x1, y1 = shape[52]
  x2, y2 = shape[58]
  x1 = int(x1)
  x2 = int(x2)
  y1 = int(y1)
  y2 = int(y2)
  width = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
  width = (width/ (image.shape[0] + image.shape[1]))
  return width 
  

def CalculateJawWidth(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape)
  x1, y1 = shape[4]
  x2, y2 = shape[14]
  x1 = int(x1)
  x2 = int(x2)
  y1 = int(y1)
  y2 = int(y2)
  width = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
  width = (width/ (image.shape[0] + image.shape[1]))
  return width 
  
def CalculateEyebrowWidth(image, rect, predictor):
  shape = predictor(image, rect)
  shape = face_utils.shape_to_np(shape)
  x1, y1 = shape[18]
  x2, y2 = shape[22]
  x1 = int(x1)
  x2 = int(x2)
  y1 = int(y1)
  y2 = int(y2)
  width = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
  width = (width/ (image.shape[0] + image.shape[1]))
  return width 