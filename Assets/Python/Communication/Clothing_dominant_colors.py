import cv2
from sklearn.cluster import KMeans

def ShirtImage(img):
    image = cv2.imread(img)
    resized_image = cv2.resize(image, (300, 300)) 
    
    cv2.rectangle(resized_image, (120, 90), (120+50,90+45), (255,0,0), 3)
    cv2.rectangle(resized_image, (125, 200), (125+40, 200+30), (255,0,0), 3)
    
    cv2.imshow("frame", resized_image)
    cv2.waitKey(0)

    shirtROI = resized_image[120:120+50, 90:90+45]
    pantsROI = resized_image[125: 125+40, 190:190+30]
    
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


img = "BodyShots/body0.png"

ShirtImage(img)