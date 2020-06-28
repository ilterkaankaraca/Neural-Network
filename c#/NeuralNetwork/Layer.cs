using System;
namespace NeuralNetwork
{
        public class Layer
        {
                int loc;
                int neuronNumber;
                Matrix input;
                Matrix output;
                Matrix weight;
                Matrix bias;
                ActivationType activationFunc;
                public Layer(int neuronNumber, ActivationType activationFunc, float learning_rate)
                {
                        this.neuronNumber=neuronNumber;
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
        }
}