import numpy
import cv2

img = cv2.imread("test.bmp", cv2.IMREAD_GRAYSCALE)

def getCenter(img):
    (X, Y) = img.shape
    totalX = 0
    totalY = 0
    a = 0
    for y in range(Y):
        sumX = 0
        i = 0
        for x in range(X):
            if(img[x, y] == 0):
                sumX = sumX + x
                i = i + 1
        if i > 0:
            totalX = totalX + sumX / i
            a = a + 1
    if a > 0:
        totalX = totalX / a
    a = 0
    for x in range(X):
        sumY = 0
        i = 0
        for y in range(Y):
            if(img[x, y] == 0):
                sumY = sumY + y
                i = i + 1
        if i > 0:
            totalY = totalY + sumY / i
            a = a + 1
    if a > 0:
        totalY = totalY / a
    return (round(totalX), round(totalY))

def populate(a):
    (X, Y) = a.shape
    for x in range(X):
        for y in range(Y):
            a[x, y] = 255
    return a

(X, Y) = getCenter(img)

img2 = populate(numpy.zeros(img.shape))

dX = X - 10
dY = Y - 10

for x in range(19):
    for y in range(19):
        if x - dX > 19 | x - dX < 0 | y - dY > 19 | y - dY < 0:
            continue
        else:
            img2[x - dX, y - dY] = img[x, y]

cv2.imwrite("test3.bmp", img2)
