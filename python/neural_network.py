import numpy as np
import math 
class NeuralNetwork:
    inputN  = None
    hiddenN  = None
    outputN  = None
    learningRate  = None
    tolerance = None
    _input  = None
    output  = None
    target  = None
    hidden  = None
    epoc = None
    weights = []
    biases = []
    
    def __init__(self, inputN, hiddenN, outputN, learningRate, tolerance, epoc):
        self.inputN = inputN
        self.hiddenN = hiddenN
        self.outputN = outputN
        self.learningRate = learningRate
        self.tolerance = tolerance
        self.epoc = epoc

        self._input = np.random.uniform(0,1,[inputN,1])
        self.hidden= np.random.uniform(0,1,[hiddenN,1])
        self.output = np.random.uniform(0,1,[outputN,1])

        self.weights.append(np.random.uniform(0,1,[hiddenN,inputN]))
        self.weights.append(np.random.uniform(0,1,[outputN,hiddenN]))
        self.biases.append(np.random.uniform(0,1,[hiddenN,1]))
        self.biases.append(np.random.uniform(0,1,[outputN,1]))
    def activation(self, temp):
        for i in range(len(temp)):
            for j in range(len(temp[0])):
                 temp[i][j]= (1/(1+math.exp(-1*temp[i][j])))
    
    def error(self, output, target):
        err = 0.0
        temp = np.empty([len(output),len(output[0])])
        for i in range(len(temp)):
            for j in range(len(temp[0])):
                temp[i][j]=0.5*(math.pow((target[i][j]-output[i][j]),2))
        for i in range(len(temp)):
            err+=temp[i][0]
        return err
    
    def dError(self, output, target):
        temp = np.subtract(output, target)
        return temp

    def dActivation(self, output):
        temp = np.empty([len(output),len(output[0])])
        for i in range(len(temp)):
            for j in range(len(temp[0])):
                temp[i][j] = output[i][j] * (1 - output[i][j])
        return temp

    def feedForward(self):
        self.hidden = self.weights[0].dot(self._input)#h
        self.hidden = np.add(self.hidden, self.biases[0])#neth
        self.activation(self.hidden)#outh
        self.output = self.weights[1].dot(self.hidden)#o
        self.output = np.add(self.output,self.biases[1])#neto     
        self.activation(self.output)#outo 

    def backProp(self):
        #output layer
        out_d_error_L2 = self.dError(self.output, self.target)
        net_d_out_L2 = self.dActivation(self.output)
        net_d_error_L2 = np.multiply(out_d_error_L2, net_d_out_L2)
        w_d_error_L2 = net_d_error_L2.dot(np.transpose(self.hidden))
        out_d_error_L1 = np.transpose(self.weights[1]).dot(net_d_error_L2)
        self.weights[1]=np.subtract(self.weights[1], np.multiply(w_d_error_L2, self.learningRate))
        
        #hidden layer
        net_d_out_L1 = self.dActivation(self.hidden)
        net_d_error_L1 = np.multiply(out_d_error_L1, net_d_out_L1)
        w_d_error_L1 = net_d_error_L1.dot(np.transpose(self._input))
        self.weights[0]=np.subtract(self.weights[0], np.multiply(w_d_error_L1, self.learningRate))


nn = NeuralNetwork(2,2,1,0.5,0.05,1200)
inputs = []
targets = []
outputs = []

inputs.append(np.empty([nn.inputN,1]))
inputs.append(np.empty([nn.inputN,1]))
inputs.append(np.empty([nn.inputN,1]))
inputs.append(np.empty([nn.inputN,1]))

targets.append(np.empty([nn.outputN,1]))
targets.append(np.empty([nn.outputN,1]))
targets.append(np.empty([nn.outputN,1]))
targets.append(np.empty([nn.outputN,1]))

outputs.append(np.empty([nn.outputN,1]))
outputs.append(np.empty([nn.outputN,1]))
outputs.append(np.empty([nn.outputN,1]))
outputs.append(np.empty([nn.outputN,1]))

inputs[0][0][0]=0
inputs[0][1][0]=0
inputs[1][0][0]=0
inputs[1][1][0]=1
inputs[2][1][0]=1
inputs[2][0][0]=0
inputs[3][0][0]=1
inputs[3][1][0]=1

targets[0][0][0]=0
targets[1][0][0]=1
targets[2][0][0]=1
targets[3][0][0]=0

i=0
while True:
    for j in range(len(inputs)):
        
        nn._input=inputs[j]
        nn.target=targets[j]
        nn.feedForward()
        print(str(j) + " "  + str(nn.output))
        outputs[j]=nn.output
        nn.backProp()
    print("epoc")
    print(i)
    if abs(outputs[0]-targets[0])<nn.tolerance and abs(outputs[1]-targets[1])<nn.tolerance and abs(outputs[2]-targets[2])<nn.tolerance and abs(outputs[3]-targets[3])<nn.tolerance:
        break
    i+=1