import cv2
import numpy as np
import tensorflow.lite as tflite
from PIL import Image
import tensorflow as tf
import tensorflow as tf
from PIL import Image, ImageOps
import numpy as np
import pandas as pd

#Load label and model
#build label dictionary
with open("converted_keras (13)/labels.txt") as fl:
    label_lines=fl.read().splitlines()
labels={} # "0" --> A, "1"-->"B"
for each_l in label_lines:
    labels[each_l.split()[0]]=each_l.split()[1]

#load the model
model=tf.keras.models.load_model('converted_keras (14)/keras_model.h5')
# Predict the label
# Create the array of the right shape to feed into the keras model
# The 'length' or number of images you can put into the array is
# determined by the first position in the shape tuple, in this case 1.
data = np.ndarray(shape=(1, 224, 224, 3), dtype=np.float32)
# Replace this with the path to your image
image = Image.open('IMG-0764.JPG').convert('RGB')# convert screen snap to RGB
#resize the image to a 224x224 with the same strategy as in TM2:
#resizing the image to be at least 224x224 and then cropping from the center
size = (224, 224)
image = ImageOps.fit(image, size, Image.ANTIALIAS)

#turn the image into a numpy array
image_array = np.asarray(image)
# Normalize the image
normalized_image_array = (image_array.astype(np.float32) / 127.0) - 1
# Load the image into the array
data[0] = normalized_image_array

# run the inference
prediction = model.predict(data)
#print(prediction)
#print("Predicted label : ",labels[str(np.argmax(prediction[0]))])

#load the model
#now with converted_tflite
# Load the TFLite model and allocate tensors.
interpreter = tf.lite.Interpreter(model_path="converted_tflite/model_unquant.tflite")
interpreter.allocate_tensors()

# Get input and output tensors.
input_details = interpreter.get_input_details()
output_details = interpreter.get_output_details()


interpreter.invoke()
size = (224, 224)

img = Image.open('IMG-0764.JPG').convert("RGB")
img = ImageOps.fit(img, size, Image.ANTIALIAS)
input_data = np.expand_dims(img, axis=0).astype(np.float32)
input_data /= 255.
input_data
interpreter.set_tensor(input_details[0]['index'], input_data)

interpreter.invoke()

# The function `get_tensor()` returns a copy of the tensor data.
# Use `tensor()` in order to get a pointer to the tensor.
output_data = interpreter.get_tensor(output_details[0]['index'])
#print(np.argmax(output_data[0]))
print("Predicted label : ",labels[str(np.argmax(output_data[0]))])

