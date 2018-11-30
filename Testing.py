import numpy
import cv2

#Fill array with 255 values
def populate(a):
    (X, Y) = a.shape
    for x in range(X):
        for y in range(Y):
            a[x, y] = 255
    return a

img = cv2.imread("test.bmp", cv2.IMREAD_GRAYSCALE)
img = cv2.bitwise_not(img)

(X, Y) = img.shape
m = populate(numpy.zeros((X, Y)))

for x in range(X):
    for y in range(Y):
        m[x, y] = img[x, y]
m = m / (numpy.sum(numpy.sum(m)))

# marginal distributions
dx = numpy.sum(m, 1)
dy = numpy.sum(m, 0)

# expected values
cy = round(numpy.sum(dx * numpy.arange(X)),0)
cx = round(numpy.sum(dy * numpy.arange(Y)),0)

# Weg zu Mittelpunkt
vx = X/2 - cx
vy = Y/2 - cy

img2 = populate(numpy.zeros((X, Y), numpy.uint8))

for x in range(X):
    for y in range(Y):
        nx = int(x + vx)
        ny = int(y + vy)
        if (nx >= 20):
            break
        if (ny >= 20):
            break
        img2[nx, ny] = img[x, y]
cv2.imwrite('test2.bmp', img2)
