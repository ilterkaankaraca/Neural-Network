using System;
namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork NN = new NeuralNetwork();
            NN.Add(new Layer(2, ActivationType.SIGMOID,.5f));//input
            NN.Add(new Layer(4, ActivationType.TANH,.25f));
            NN.Add(new Layer(2, ActivationType.SIGMOID,1));
        }
    }
}
