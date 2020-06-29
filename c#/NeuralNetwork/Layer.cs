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
    }
}