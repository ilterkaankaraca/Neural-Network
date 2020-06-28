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
            public Matrix hidden;
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
                this.hidden = new Matrix(hiddenN, 1);
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
                this.hidden = nn.hidden;
                this.output = nn.output;
                this.weightsA[0] = new Matrix(nn.weightsA[0]);
                this.weightsA[1] = new Matrix(nn.weightsA[1]);
                this.biasesA[0] = new Matrix(nn.biasesA[0]);
                this.biasesA[1] = new Matrix(nn.biasesA[1]);
            }
            public static float error(Matrix output, Matrix target)
            {
                float err = 0.0f;
                Matrix temp = new Matrix(output.row, output.column);
                for (int i = 0; i < temp.row; i++)
                {
                    for (int j = 0; j < temp.column; j++)
                        temp.matrix[i, j] = 0.5f * (float)(Math.Pow((double)(target.matrix[i, j] - output.matrix[i, j]), 2.0));
                }
                for (int i = 0; i < temp.row; i++)
                {
                    err += temp.matrix[i, 0];
                }
                return err;
            }

            public static Matrix dError(Matrix output, Matrix target)
            {
                Matrix temp = Matrix.subtract(output, target);
                return temp;
            }
            public static Matrix dActivation(Matrix output)
            {
                Matrix temp = new Matrix(output.row, output.column);
                for (int i = 0; i < temp.row; i++)
                {
                    for (int j = 0; j < temp.column; j++)
                        temp.matrix[i, j] = output.matrix[i, j] * (1f - output.matrix[i, j]);
                }
                return temp;
            }
            public void FeedForward()
            {
                hidden = Matrix.mult(weightsA[0], input);//h
                hidden = Matrix.add(hidden, biasesA[0]);//neth
                ActivationFunctions.Tanh(hidden);//outh
                output = Matrix.mult(weightsA[1], hidden);//o
                output = Matrix.add(output, biasesA[1]);//neto
                ActivationFunctions.Tanh(output);//outo  
            }
            public void backProp()
            {
                //output layer
                Matrix out_d_error_L2 = dError(output, target);
                Matrix net_d_out_L2 = ActivationFunctions.DerTanh(output);
                Matrix net_d_error_L2 = Matrix.eWMult(out_d_error_L2, net_d_out_L2);
                Matrix w_d_error_L2 = Matrix.mult(net_d_error_L2, Matrix.transpose(hidden));
                Matrix out_d_error_L1 = Matrix.mult(Matrix.transpose(weightsA[1]), net_d_error_L2);
                weightsA[1] = Matrix.subtract(weightsA[1], Matrix.scalarMult(w_d_error_L2, learningRate));

                //hidden layer
                Matrix net_d_out_L1 = dActivation(hidden);
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

            }
        }

    }
