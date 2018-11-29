import sys
import numpy
import scipy.special
import matplotlib.pyplot as mpl
import os.path
import random
args = sys.argv

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
        numpy.save(str("C:/Users/Solidify/Desktop/saved_wih_" + args[4] + ".npy"), self.wih)
        numpy.save(str("C:/Users/Solidify/Desktop/saved_who_" + args[4] + ".npy"), self.who)
        pass

    def load(self):
        if os.path.isfile(str("C:/Users/Solidify/Desktop/saved_wih_" + args[3] + ".npy")) & os.path.isfile(str("C:/Users/Solidify/Desktop/saved_who_" + args[3] + ".npy")):
            self.wih = numpy.load(str("C:/Users/Solidify/Desktop/saved_wih_" + args[3] + ".npy"))
            self.who = numpy.load(str("C:/Users/Solidify/Desktop/saved_who_" + args[3] + ".npy"))
            return True
        return False
        pass


if args[1] == "train":
    input_nodes = 784
    hidden_nodes = int(args[4])
    output_nodes = 10
    epochs = int(args[5])
    learning_rate = float(args[6])

    n = neuralNetwork(input_nodes, hidden_nodes, output_nodes, learning_rate)

    training_data_file = open(args[2], 'r')
    training_data_list = training_data_file.readlines()
    training_data_file.close()
    random.shuffle(training_data_list)

    for e in range(epochs):

        for record in training_data_list:

            all_values = record.split(',')

            inputs = (numpy.asfarray(all_values[1:]) / 255.0 * 0.99) + 0.01

            targets = numpy.zeros(output_nodes) + 0.01

            targets[int(all_values[0])] = 0.99
            n.train(inputs, targets)
            pass
        pass

    n.save()

    test_data_file = open(args[3], 'r')
    test_data_list = test_data_file.readlines()
    test_data_file.close()
    all_values = test_data_list[0].split(",")

    scorecard = []

    for record in test_data_list:

        all_values = record.split(',')

        correct_label = int(all_values[0])
        # scale and shift the inputs
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

if args[1] == "testdrawing":

    print("TEST")
    input_nodes = 784
    hidden_nodes = int(args[3])
    output_nodes = 10
    learning_rate = float(args[4])

    n = neuralNetwork(input_nodes, hidden_nodes, output_nodes, learning_rate)
    print("TEST")

    if n.load():

        all_values = args[2].split(',')

        inputs = (numpy.asfarray(all_values[0:]) / 255.0 * 0.99) + 0.01

        outputs = n.query(inputs)

        label = numpy.argmax(outputs)
        print("Netz sagt: ", str(label))

    else:
        print("Nix da")

    print("TEST")