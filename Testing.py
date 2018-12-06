import sys
import numpy
import scipy.special
import matplotlib.pyplot as mpl
import os.path
import os
import random
import math
from PIL import Image
import cv2
from scipy import ndimage
import time

class neuralNetwork:

    def __init__(self, inputnodes, hiddennodes, outputnodes, learningrate):
        self.inodes = inputnodes
        self.hnodes = hiddennodes
        self.onodes = outputnodes
        self.wih = numpy.random.normal(0.0, pow(self.inodes, -0.5), (self.hnodes, self.inodes))
        self.who = numpy.random.normal(0.0, pow(self.hnodes, -0.5), (self.onodes, self.hnodes))
        self.lr = learningrate
        self.activation_function = lambda x: scipy.special.expit(x)
        pass

    def train(self, inputs_list, targets_list):
        inputs = numpy.array(inputs_list, ndmin=2).T
        targets = numpy.array(targets_list, ndmin=2).T
        hidden_inputs = numpy.dot(self.wih, inputs)
        hidden_outputs = self.activation_function(hidden_inputs)
        final_inputs = numpy.dot(self.who, hidden_outputs)
        final_outputs = self.activation_function(final_inputs)
        output_errors = targets - final_outputs
        hidden_errors = numpy.dot(self.who.T, output_errors)
        self.who += self.lr * numpy.dot((output_errors * final_outputs * (1.0 - final_outputs)),
                                        numpy.transpose(hidden_outputs))
        self.wih += self.lr * numpy.dot((hidden_errors * hidden_outputs * (1.0 - hidden_outputs)),
                                        numpy.transpose(inputs))
        pass

    def query(self, inputs_list):
        inputs = numpy.array(inputs_list, ndmin=2).T
        hidden_inputs = numpy.dot(self.wih, inputs)
        hidden_outputs = self.activation_function(hidden_inputs)
        final_inputs = numpy.dot(self.who, hidden_outputs)
        final_outputs = self.activation_function(final_inputs)
        return final_outputs

    def save(self):
        numpy.save(str("saved_wih_" + str(hidden_nodes) + ".npy"), self.wih)
        numpy.save(str("saved_who_" + str(hidden_nodes) + ".npy"), self.who)
        pass

    def load(self):
        if os.path.isfile(str("saved_wih_" + str(hidden_nodes) + ".npy")) & os.path.isfile(str("saved_who_" + str(hidden_nodes) + ".npy")):
            self.wih = numpy.load(str("saved_wih_" + str(hidden_nodes) + ".npy"))
            self.who = numpy.load(str("saved_who_" + str(hidden_nodes) + ".npy"))
            return True
        return False
        pass

    def getBestShift(self, img):
        cy, cx = ndimage.measurements.center_of_mass(img)

        rows, cols = img.shape
        shiftx = numpy.round(cols / 2.0 - cx).astype(int)
        shifty = numpy.round(rows / 2.0 - cy).astype(int)

        return shiftx, shifty

    def shift(self, img, sx, sy):
        rows, cols = img.shape
        M = numpy.float32([[1, 0, sx], [0, 1, sy]])
        shifted = cv2.warpAffine(img, M, (cols, rows))
        return shifted


input_nodes = 784
hidden_nodes = 50
output_nodes = 10
epochs = 3
learning_rate = 0.3


if input("Trainieren? (y/n): ") == "y":

    for i in range(10):
        n = neuralNetwork(input_nodes, hidden_nodes, output_nodes, learning_rate)

        training_data_file = open("mnist_train.csv", 'r')
        training_data_list = training_data_file.readlines()
        training_data_file.close()
        random.shuffle(training_data_list)
        items = 0
        for e in range(epochs):

            #print("Epoche: " + str(e+1))
            for record in training_data_list:

                items += 1
                #if (items % 10000) == 0:
                    #print("Item: " + str(items))

                all_values = record.split(',')

                inputs = (numpy.asfarray(all_values[1:]) / 255.0 * 0.99) + 0.01

                targets = numpy.zeros(output_nodes) + 0.01

                targets[int(all_values[0])] = 0.99
                n.train(inputs, targets)
                pass
            pass

        n.save()

        test_data_file = open("mnist_test.csv", 'r')
        test_data_list = test_data_file.readlines()
        test_data_file.close()
        all_values = test_data_list[0].split(",")

        scorecard = []

        for record in test_data_list:

            all_values = record.split(',')

            correct_label = int(all_values[0])

            inputs = (numpy.asfarray(all_values[1:]) / 255.0 * 0.99) + 0.01

            outputs = n.query(inputs)

            label = numpy.argmax(outputs)

            if (label == correct_label):
                scorecard.append(1)
            else:
                scorecard.append(0)
                pass
            pass

        scorecard_array = numpy.asarray(scorecard)
        print("Performance is ", scorecard_array.sum() / scorecard_array.size)

if input("Testen? (y/n): ") == "y":

    n = neuralNetwork(input_nodes, hidden_nodes, output_nodes, learning_rate)

    # read the image
    gray = cv2.imread("drei.bmp", 0)

    # resize the images and invert it (black background)
    gray = cv2.resize(255 - gray, (28, 28))

    # save the processed images
    cv2.imwrite("processed_drei.bmp", gray)

    # better black and white version
    (thresh, gray) = cv2.threshold(gray, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)

    while numpy.sum(gray[0]) == 0:
        gray = gray[1:]

    while numpy.sum(gray[:, 0]) == 0:
        gray = numpy.delete(gray, 0, 1)

    while numpy.sum(gray[-1]) == 0:
        gray = gray[:-1]

    while numpy.sum(gray[:, -1]) == 0:
        gray = numpy.delete(gray, -1, 1)

    rows, cols = gray.shape

    if rows > cols:
        factor = 20.0 / rows
        rows = 20
        cols = int(round(cols * factor))
        # first cols than rows
        gray = cv2.resize(gray, (cols, rows))
    else:
        factor = 20.0 / cols
        cols = 20
        rows = int(round(rows * factor))
        # first cols than rows
        gray = cv2.resize(gray, (cols, rows))

    colsPadding = (int(math.ceil((28 - cols) / 2.0)), int(math.floor((28 - cols) / 2.0)))
    rowsPadding = (int(math.ceil((28 - rows) / 2.0)), int(math.floor((28 - rows) / 2.0)))
    gray = numpy.lib.pad(gray, (rowsPadding, colsPadding), 'constant')
    gray.flatten()


    shiftx, shifty = n.getBestShift(gray)
    shifted = n.shift(gray, shiftx, shifty)
    gray = shifted




    if n.load():
        flat = gray.flatten()
        all_values = flat

        inputs = (numpy.asfarray(all_values[0:]) / 255.0 * 0.99) + 0.01

        outputs = n.query(inputs)

        label = numpy.argmax(outputs)
        print("Netz sagt: ", str(label))

    else:
        print("Nix da")

