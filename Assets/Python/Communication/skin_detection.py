import cv2
import numpy as np
import sys


# ---- START FUNCTIONS ----#


# segment using otsu binarization and thresholding
def segment_otsu(image_grayscale, img_BGR):
    threshold_value, threshold_image = cv2.threshold(image_grayscale, 0, 255,cv2.THRESH_BINARY_INV+cv2.THRESH_OTSU)
    threshold_image_binary = 1- threshold_image/255
    threshold_image_binary = np.repeat(threshold_image_binary[:, :, np.newaxis], 3, axis=2)
    img_face_only = np.multiply(threshold_image_binary, img_BGR)
    return img_face_only.astype(np.uint8)


def segmentSkinColor(image):
# read in image into openCV BGR and grayscale
    img_BGR = cv2.imread(image, 3)
    img_grayscale = cv2.cvtColor(img_BGR, cv2.COLOR_BGR2GRAY)

# foreground and background segmentation (otsu)
    img_face_only = segment_otsu(img_grayscale, img_BGR)
# convert to HSV and YCrCb color spaces and detect potential pixels
    img_HSV = cv2.cvtColor(img_face_only, cv2.COLOR_BGR2HSV)
    img_YCrCb = cv2.cvtColor(img_face_only, cv2.COLOR_BGR2YCrCb)

# aggregate skin pixels
    blue = []
    green = []
    red = []

    height, width, channels = img_face_only.shape

    for i in range (height):
        for j in range (width):
            if((img_HSV.item(i, j, 0) <= 170) and (140 <= img_YCrCb.item(i, j, 1) <= 170) and (90 <= img_YCrCb.item(i, j, 2) <= 120)):
                blue.append(img_face_only[i, j].item(0))
                green.append(img_face_only[i, j].item(1))
                red.append(img_face_only[i, j].item(2))
            else:
                img_face_only[i, j] = [0, 0, 0]

# determine mean skin tone estimate
    skin_tone_estimate_RGB = [np.mean(red), np.mean(green), np.mean(blue)]
    return skin_tone_estimate_RGB[0], skin_tone_estimate_RGB[1], skin_tone_estimate_RGB[2]