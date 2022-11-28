# Created by Youssef Elashry to allow two-way communication between Python3 and Unity to send and receive strings

# Feel free to use this in your individual or commercial projects BUT make sure to reference me as: Two-way communication between Python 3 and Unity (C#) - Y. T. Elashry
# It would be appreciated if you send me how you have used this in your projects (e.g. Machine Learning) at youssef.elashry@gmail.com

# Use at your own risk
# Use under the Apache License 2.0

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

# Create UDP socket to use for sending (and receiving)
sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)

i = 0

while True:

    data = sock.ReadReceivedData() # read data

    if data != None: # if NEW data has been received since last ReadReceivedData function call
        if data[0] == "C":
            DataPath = data[12:31]
            image = DataPath
            shirtROI, pantsROI = Clothing_dominant_colors.ShirtImage(image)
            shirtR, shirtG, shirtB = Clothing_dominant_colors.dominantColors(shirtROI)
            pantsR, pantsG, pantsB = Clothing_dominant_colors.dominantColors(pantsROI)
            print(shirtR, shirtG, shirtB)
            print(pantsR,pantsG, pantsB)

            sock.SendData("C" + "R" + str(shirtR)) # S = skincolor
            sock.SendData("C" + "G" + str(shirtG))
            sock.SendData("C" + "B" + str(shirtB))
            sock.SendData("P" + "R" + str(pantsR)) #H = haircolor
            sock.SendData("P" + "G" + str(pantsG))
            sock.SendData("P" + "B" + str(pantsB))


        if data[0] == "F":
            DataPath = data[9:29]
            image = DataPath
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

            sock.SendData("E" + str(eyeArea)) #E = Eyesize
            sock.SendData("Y" + str(eyecolor)) #y = eyecolor
            #sock.SendData("N" + str(NoseLength)) #N = noselength
            sock.SendData("G" + str(gender)) #G = gender
            sock.SendData("S" + "R" + str(skinR)) # S = skincolor
            sock.SendData("S" + "G" + str(skinG))
            sock.SendData("S" + "B" + str(skinB))
            sock.SendData("H" + "R" + str(hairR)) #H = haircolor
            sock.SendData("H" + "G" + str(hairG))
            sock.SendData("H" + "B" + str(hairB))
            sock.SendData("B" + str(eyebrowWidth)) # B = Brow width
            #sock.SendData("J" + str(jawWidth))
            
            


    time.sleep(1)