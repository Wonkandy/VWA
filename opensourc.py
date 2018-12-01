import numpy
import cv2
from scipy import ndimage
import math


def getBestShift(img):
    cy,cx = ndimage.measurements.center_of_mass(img)

    rows,cols = img.shape
    shiftx = numpy.round(cols/2.0-cx).astype(int)
    shifty = numpy.round(rows/2.0-cy).astype(int)

    return shiftx,shifty


def shift(img,sx,sy):
    rows,cols = img.shape
    M = numpy.float32([[1,0,sx],[0,1,sy]])
    shifted = cv2.warpAffine(img,M,(cols,rows))
    return shifted


# read the image
gray = cv2.imread("drei.bmp", 0)

# resize the images and invert it (black background)
gray = cv2.resize(255-gray, (28, 28))

# save the processed images
cv2.imwrite("processed_drei.bmp", gray)

# better black and white version
(thresh, gray) = cv2.threshold(gray, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)

while numpy.sum(gray[0]) == 0:
			gray = gray[1:]

while numpy.sum(gray[:,0]) == 0:
			gray = numpy.delete(gray,0,1)

while numpy.sum(gray[-1]) == 0:
			gray = gray[:-1]

while numpy.sum(gray[:,-1]) == 0:
			gray = numpy.delete(gray,-1,1)

rows,cols = gray.shape

if rows > cols:
     factor = 20.0/rows
     rows = 20
     cols = int(round(cols*factor))
      # first cols than rows
     gray = cv2.resize(gray, (cols,rows))
else:
	factor = 20.0/cols
	cols = 20
	rows = int(round(rows*factor))
	# first cols than rows
	gray = cv2.resize(gray, (cols, rows))

colsPadding = (int(math.ceil((28-cols)/2.0)),int(math.floor((28-cols)/2.0)))
rowsPadding = (int(math.ceil((28-rows)/2.0)),int(math.floor((28-rows)/2.0)))
gray = numpy.lib.pad(gray,(rowsPadding,colsPadding),'constant')

shiftx,shifty = getBestShift(gray)
shifted = shift(gray,shiftx,shifty)
gray = shifted

cv2.imwrite("processed_drei.bmp", gray)

print(gray)

print(gray.flatten())