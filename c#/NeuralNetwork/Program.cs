using System;
namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork NN = new NeuralNetwork();
            NN.Add(new Layer(4, ActivationType.TANH,.5f));//input
            NN.Add(new Layer(5, ActivationType.TANH,.25f));
            NN.Add(new Layer(4, ActivationType.TANH,1));
            NN.Add(new Layer(1, ActivationType.SIGMOID,1));
            NN.Initialize();
        }
    }
}
