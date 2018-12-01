import sys
import numpy
import scipy.special
import matplotlib.pyplot as mpl
import os.path
import random
from PIL import Image
import cv2
import PIL.ImageOps

img = Image.open("drei.bmp")
cogimg = cv2.imread("drei.bmp",  cv2.IMREAD_GRAYSCALE)

# Schwerpunktberechnung
(X, Y) = img.size
m = numpy.zeros((X, Y))
for x in range(X):
    for y in range(Y):
        m[x, y] = cogimg[x, y]
m = m / (numpy.sum(numpy.sum(m)))

# marginal distributions
dx = numpy.sum(m, 1)
dy = numpy.sum(m, 0)

# Schwerpunktkoordinaten
cy = round(numpy.sum(dx * numpy.arange(X)), 0)
cx = round(numpy.sum(dy * numpy.arange(Y)), 0)

# Weg zu Mittelpunkt
vx = X/2 - cx
vy = Y/2 - cy

# newimg = verschobenes Bild
newimg = cv2.imread("asdf.bmp", cv2.IMREAD_GRAYSCALE)#Image.new("L", (X, Y), "white")
#invimg = PIL.ImageOps.invert(newimg)
#invimg.save("inv.bmp")
#newimg.save("asdf.bmp")
#print(newimg.getpixel((1,1)))

for x in range(X):
    for y in range(Y):
        nx = int(x + vx)
        ny = int(y + vy)
        if (nx >= X or nx < 0):
            break
        if (ny >= Y or ny < 0):
            break
        v = cogimg[x, y]
        newimg[nx, ny] = v

cv2.imwrite("asdf.bmp", newimg)
















#img = cv2.bitwise_not(img)  Methode zum Invertieren