using System;
namespace NeuralNetwork
{
        public class Layer
        {
                public int neuronN;
                Matrix layer;
                public Matrix weight;
                Matrix bias;
                ActivationType activationFunc;
                public Layer(int neuronNumber, ActivationType activationFunc, float learning_rate)
                {
                        this.neuronN=neuronNumber;
                        this.activationFunc=activationFunc;
                }
                public Matrix ApplyActivation(Matrix input)
                {
                
                        if(activationFunc==ActivationType.SIGMOID)
                        {
                                return ActivationFunctions.Sigmoid(input);
                        }
                        else if(activationFunc==ActivationType.TANH)
                        {
                                return ActivationFunctions.Tanh(input);
                        }
                        return null;
                }
                public Matrix ApplyDerActivation(Matrix input)
                {
                
                        if(activationFunc==ActivationType.SIGMOID)
                        {
                                return ActivationFunctions.DerSigmoid(input);
                        }
                        else if(activationFunc==ActivationType.TANH)
                        {
                                return ActivationFunctions.DerTanh(input);
                        }
                        return null;
                }
                public void Initialize(int nextLayerN)
                {
                        if(nextLayerN==0)
                        {
                                this.layer = new Matrix(neuronN, 1);
                                this.weight = null;
                                this.bias = null;
                        }
                        else
                        {
                                this.layer = new Matrix(neuronN, 1);
                                this.weight = new Matrix(nextLayerN, neuronN); 
                                this.bias = new Matrix(neuronN, 1); 
                                this.weight.Randomize();
                                this.bias.Randomize();
                        }
                        
                }
                //TODO: Bunun için Matt Mazura bakman lazım 
                public float error(Matrix output, Matrix target)
                {
                    float err = 0.0f;
                    Matrix temp = new Matrix(output.row, output.column);
                    for (int i = 0; i < temp.row; i++)
                    {
                        for (int j = 0; j < temp.column; j++)
                            temp.data[i, j] = 0.5f * (float)(Math.Pow((double)(target.data[i, j] - output.data[i, j]), 2.0));
                    }
                    for (int i = 0; i < temp.row; i++)
                    {
                        err += temp.data[i, 0];
                    }
                    return err;
                }
                public Matrix dError(Matrix output, Matrix target)
                {
                    Matrix temp = Matrix.subtract(output, target);
                    return temp;
                }
                public Matrix FeedForward(Matrix input)
                {
                        //Buraya eski feedforwarddaki şeyler gelecek
                }
    }
}