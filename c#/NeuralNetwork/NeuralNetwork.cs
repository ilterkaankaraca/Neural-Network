using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
        public class NeuralNetwork
        {
            //Number of Layers
            int layerN;
            public List<Layer> layers = new List<Layer>();
            public List<Matrix> weights =new List<Matrix>();
            public List<Matrix> biases = new List<Matrix>();
            public Layer inputLayer;
            public Layer outputLayer;
            //Eski kısımlar
            public int inputN, hiddenN, outputN;
            public float learningRate;
            public Matrix input;
            public Matrix output;
            public Matrix target;
            public Matrix tempInput;
            public Matrix[] weightsA = new Matrix[2];
            public Matrix[] biasesA = new Matrix[2];
            public NeuralNetwork()
            {
                layerN=0;
            }
            public NeuralNetwork(int inputN, int hiddenN, int outputN, float learningRate)
            {
                layerN = 0;
                this.inputN = inputN;
                this.hiddenN = hiddenN;
                this.outputN = outputN;
                this.learningRate = learningRate;

                this.input = new Matrix(inputN, 1);
                this.tempInput = new Matrix(hiddenN, 1);
                this.output = new Matrix(outputN, 1);

                this.weightsA[0] = new Matrix(hiddenN, inputN); 
                this.weightsA[1] = new Matrix(outputN, hiddenN); 
                this.biasesA[0] = new Matrix(hiddenN, 1);
                this.biasesA[1] = new Matrix(outputN, 1);

                this.weightsA[0].Randomize();
                this.weightsA[1].Randomize();
                this.biasesA[0].Randomize();
                this.biasesA[1].Randomize();
            }
            //Copy constructor
            public NeuralNetwork(NeuralNetwork nn)
            {
                this.inputN = nn.inputN;
                this.hiddenN = nn.hiddenN;
                this.outputN = nn.outputN;
                this.learningRate = nn.learningRate;

                this.input  = nn.input; 
                this.tempInput = nn.tempInput;
                this.output = nn.output;
                this.weightsA[0] = new Matrix(nn.weightsA[0]);
                this.weightsA[1] = new Matrix(nn.weightsA[1]);
                this.biasesA[0] = new Matrix(nn.biasesA[0]);
                this.biasesA[1] = new Matrix(nn.biasesA[1]);
            }
            public void FeedForwardO()
            {
                tempInput = Matrix.mult(weightsA[0], input);//h
                tempInput = Matrix.add(tempInput, biasesA[0]);//neth
                ActivationFunctions.Tanh(tempInput);//outh
                output = Matrix.mult(weightsA[1], tempInput);//o
                output = Matrix.add(output, biasesA[1]);//neto
                ActivationFunctions.Tanh(output);//outo  
            }
            public void FeedForward(Matrix input)
            {
                for(int i=1;i<layers.Count;i++)
                {
                    input=layers[i].FeedForward(input);
                }
            }
            public void backProp()
            {
                //output layer
                Matrix out_d_error_L2 = Layer.dError(output, target);
                Matrix net_d_out_L2 = ActivationFunctions.DerTanh(output);
                Matrix net_d_error_L2 = Matrix.eWMult(out_d_error_L2, net_d_out_L2);
                Matrix w_d_error_L2 = Matrix.mult(net_d_error_L2, Matrix.transpose(tempInput));
                Matrix out_d_error_L1 = Matrix.mult(Matrix.transpose(weightsA[1]), net_d_error_L2);
                weightsA[1] = Matrix.subtract(weightsA[1], Matrix.scalarMult(w_d_error_L2, learningRate));

                //hidden layer
                Matrix net_d_out_L1 = ActivationFunctions.DerTanh(tempInput);
                Matrix net_d_error_L1 = Matrix.eWMult(out_d_error_L1, net_d_out_L1);
                Matrix w_d_error_L1 = Matrix.mult(net_d_error_L1, Matrix.transpose(input));
                weightsA[0] = Matrix.subtract(weightsA[0], Matrix.scalarMult(w_d_error_L1, learningRate));
            }
            public void Add(Layer layer)
            {
                layers.Add(layer);
                if(inputLayer==null)
                {
                    inputLayer=layer;
                }
                outputLayer=layers[layers.Count - 1];
            }
            public void Initialize()
            {
                for(int i=1;i<layers.Count-1;i++)
                {
                    layers[i].Initialize(layers[i+1].neuronN);
                }
                outputLayer.Initialize(0);
            }
        }

    }
