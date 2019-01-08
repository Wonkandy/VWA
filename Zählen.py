import numpy
import scipy.special
import scipy.ndimage
import matplotlib.pyplot
import os.path
import random
import math
import cv2

training_data_file = open("mnist_train.csv", 'r')
training_data_list = training_data_file.readlines()
random.shuffle(training_data_list)
training_data_file.close()

null = 0
eins = 0
zwei = 0
drei = 0
vier = 0
fünf = 0
sechs = 0
sieben = 0
acht = 0
neun = 0
alle = 0

for record in training_data_list:
    alle += 1

    all_values = record.split(',')

    if int(all_values[0]) == 0:
        null += 1
    if int(all_values[0]) == 1:
        eins += 1
    if int(all_values[0]) == 2:
        zwei += 1
    if int(all_values[0]) == 3:
        drei += 1
    if int(all_values[0]) == 4:
        vier += 1
    if int(all_values[0]) == 5:
        fünf += 1
    if int(all_values[0]) == 6:
        sechs += 1
    if int(all_values[0]) == 7:
        sieben += 1
    if int(all_values[0]) == 8:
        acht += 1
    if int(all_values[0]) == 9:
        neun += 1

    pass

print("ALLE",alle)
print("Null",null,"\t",round(null/alle,3))
print("EINS", eins,"\t",round(eins/alle,3))
print("ZWEI",zwei,"\t",round(zwei/alle,3))
print("DREI",drei,"\t",round(drei/alle,3))
print("VIER",vier,"\t",round(vier/alle,3))
print("FÜNF",fünf,"\t",round(fünf/alle,3))
print("SECHS", sechs,"\t",round(sechs/alle,3))
print("SIEBEN",sieben,"\t",round(sieben/alle,3))
print("ACHT",acht,"\t",round(acht/alle,3))
print("NEUN",neun,"\t",round(neun/alle,3))
