## Now let’s load an image and observe its various properties in general.
## https://towardsdatascience.com/image-data-analysis-using-python-edddfdf128f4

#%%
import imageio
import matplotlib.pyplot as plt
# %matplotlib inline
pic = imageio.imread('images/drawing1.png')
plt.figure(figsize = (5,5))
plt.imshow(pic)

#%%
## -------- OBSERVE BASIC PROPERTIES OF IMAGE -------- ##

print('Type of the image : ' , type(pic)) 
print('Shape of the image : {}'.format(pic.shape)) 
print('Image Hight {}'.format(pic.shape[0])) 
print('Image Width {}'.format(pic.shape[1])) 
print('Dimension of Image {}'.format(pic.ndim))


#%%
print('Image size {}'.format(pic.size)) 
print('Maximum RGB value in this image {}'.format(pic.max())) 
print('Minimum RGB value in this image {}'.format(pic.min()))

# %%
# A specific pixel located at Row : 100 ; Column : 50  
# Each channel's value of it, gradually R , G , B  
print('Value of only R channel {}'.format(pic[ 100, 50, 0])) 
print('Value of only G channel {}'.format(pic[ 100, 50, 1])) 
print('Value of only B channel {}'.format(pic[ 100, 50, 2]))

# %%
## view of each channel in the whole image

plt.title('R channel') 
plt.ylabel('Height {}'.format(pic.shape[0])) 
plt.xlabel('Width {}'.format(pic.shape[1])) 
plt.imshow(pic[ : , : , 0])
plt.show()

plt.title('G channel')
plt.ylabel('Height {}'.format(pic.shape[0])) 
plt.xlabel('Width {}'.format(pic.shape[1])) 
plt.imshow(pic[ : , : , 1]) 
plt.show()

plt.title('B channel') 
plt.ylabel('Height {}'.format(pic.shape[0])) 
plt.xlabel('Width {}'.format(pic.shape[1])) 
plt.imshow(pic[ : , : , 2]) 
plt.show()

# %%
## we can also able to change the number of RGB values. As an example, let’s set the Red, Green, Blue layer for following Rows values to full intensity.
###  R channel: Row — 100 to 110
### G channel: Row — 200 to 210
### B channel: Row — 300 to 310

pic[50:150 , : , 0] = 255 # full intensity to those pixel's R channel 
plt.figure( figsize = (5,5)) 
plt.imshow(pic) 
plt.show()

pic[200:300 , : , 1] = 255 # full intensity to those pixel's G channel 
plt.figure( figsize = (5,5)) 
plt.imshow(pic) 
plt.show()

pic[350:450 , : , 2] = 255 # full intensity to those pixel's B channel 
plt.figure( figsize = (5,5)) 
plt.imshow(pic) 
plt.show()

# %%
## To make it more clear let’s change the column section too and this time we’ll change the RGB channel simultaneously.

# set value 200 of all channels to those pixels which turns them to white 
pic[ 50:450 , 400:600 , [0,1,2] ] = 200  
plt.figure( figsize = (5,5)) 
plt.imshow(pic) 
plt.show()

# %%
## -------- SPLITTING LAYERS -------- ##
import numpy as np 
pic = imageio.imread('images/drawing1.png') 
fig, ax = plt.subplots(nrows = 1, ncols=3, figsize=(15,5))  
for c, ax in zip(range(3), ax):     
    # create zero matrix        
    split_img = np.zeros(pic.shape, dtype="uint8") 
    # 'dtype' by default: 'numpy.float64'  # assing each channel      
    split_img[ :, :, c] = pic[ :, :, c] # display each channel     
    ax.imshow(split_img)
# %%
## -------- GREYSCALE -------- ##

### There’re two types of black and white images:
### - Binary: Pixel is either black or white:0 or 255
### - Greyscale: Ranges of shades of grey:0 ~ 255

## Y' = 0.299 R + 0.587 G + 0.114 B

pic = imageio.imread('images/drawing1.png') 
gray = lambda rgb : np.dot(rgb[... , :3] , [0.299 , 0.587, 0.114])   
gray = gray(pic) 
plt.figure( figsize = (5,5))  
plt.imshow(gray, cmap = plt.get_cmap(name = 'gray')) 
plt.show()
# %%

## Use Logical Operator To Process Pixel Values

## Let’s first load an image and show it on screen.
pic = imageio.imread('images/drawing2.jpg') 
plt.figure(figsize=(5,5)) 
plt.imshow(pic) 
plt.show()
# %%

## we want to filter out all the pixel values, which is below than, let’s assume, 20
low_pixel = pic < 20  
# to ensure of it let's check if all values in low_pixel are True or not 
if low_pixel.any() == True:     
    print(low_pixel.shape)
# %%
## if we see the shape of both low_pixel and pic , we’ll find that both have the same shape.

print(pic.shape)
print(low_pixel.shape)

# %%
## we can use this low_pixel array as an index to set those low values to some specific values, which may be higher than or lower than the previous pixel value

# randomly choose a value 
import random

# load the orginal image
pic = imageio.imread('images/drawing2.jpg')

# set value randomly range from 25 to 225 - these value also randomly choosen
pic[low_pixel] = random.randint(25,225)
# display the image
plt.figure( figsize = (5,5))
plt.imshow(pic)
plt.show()

# %%
## -------- MASKING -------- ##
## Image masking is an image processing technique that is used to remove the background from which photographs those have fuzzy edges, transparent or hair portions.

## we’ll create a mask that is in shape of a circular disc
## First, we’ll measure the distance from the center of the image to every border pixel values. And we take a convenient radius value, and then using logical operator, we’ll create a circular disc.

# Load the image 
pic = imageio.imread('images/drawing3.jpg')  
# seperate the row and column values  
total_row , total_col , layers = pic.shape  
'''     Create vector.     
        Ogrid is a compact method of creating a multidimensional     
        ndarray operations in single lines.     
for ex:     
>>> ogrid[0:5,0:5]     
output: [array([[0],
                [1],
                [2],
                [3],
                [4]]),
        array([[0, 1, 2, 3, 4]])]  
''' 
x , y = np.ogrid[:total_row , :total_col]  
# get the center values of the image 
cen_x , cen_y = total_row/2 , total_col/2  
'''    
Measure distance value from center to each border pixel.
To make it easy, we can think it's like, we draw a line from center-     
to each edge pixel value --> s**2 = (Y-y)**2 + (X-x)**2  
''' 
distance_from_the_center = np.sqrt((x-cen_x)**2 + (y-cen_y)**2)  
# Select convenient radius value 
radius = (total_row/2)  
# Using logical operator '>'  
''' 
logical operator to do this task which will return as a value  of True for all the index according to the given condition 
''' 
circular_pic = distance_from_the_center > radius  
''' 
let assign value zero for all pixel value that outside the cirular disc. All the pixel value outside the circular disc, will be black now. 
''' 
pic[circular_pic] = 0 
plt.figure(figsize = (5,5)) 
plt.imshow(pic)  
plt.show()


# %%

## -------- IMAGE PROCESSING -------- ##

## Red pixel indicates: Altitude
## Blue pixel indicates: Aspect
## Green pixel indicates: Slope

# Only Red Pixel value , higher than 180
pic = imageio.imread('images/drawing3.jpg')
red_mask = pic[:, :, 0] < 180
pic[red_mask] = 0
plt.figure(figsize=(5,5))
plt.imshow(pic)

# Only Green Pixel value , higher than 180
pic = imageio.imread('images/drawing3.jpg')
green_mask = pic[:, :, 1] < 180
pic[green_mask] = 0
plt.figure(figsize=(5,5))
plt.imshow(pic)
# Only Blue Pixel value , higher than 180
pic = imageio.imread('images/drawing3.jpg')
blue_mask = pic[:, :, 2] < 180
pic[blue_mask] = 0
plt.figure(figsize=(5,5))
plt.imshow(pic)
# Composite mask using logical_and
pic = imageio.imread('images/drawing3.jpg')
final_mask = np.logical_and(red_mask, green_mask, blue_mask)
pic[final_mask] = 40
plt.figure(figsize=(5,5))
plt.imshow(pic)
# %%
