import cv2
from sklearn.cluster import KMeans

def ShirtImage(img):
    image = cv2.imread(img)
    resized_image = cv2.resize(image, (300, 300)) 
    
    shirtROI = resized_image[150:150+50, 130:130+35]
    pantsROI = resized_image[240: 240+50, 120:120+30]


    return shirtROI, pantsROI

def dominantColors(image):
    
        
        #convert to rgb from bgr
    img = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
                
        #reshaping to a list of pixels
    img = img.reshape((img.shape[0] * img.shape[1], 3))
        
        
        #using k-means to cluster pixels
    kmeans = KMeans(n_clusters = 1)
    kmeans.fit(img)
        
        #the cluster centers are our dominant colors.
    colors = kmeans.cluster_centers_
        
        #save labels
    labels = kmeans.labels_
        
        #returning after converting to integer from float
    colors = colors.astype(int)
    return colors[0,0], colors[0,1], colors[0,2]


