using System;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int epoc = 1000;

            NeuralNetwork nn = new NeuralNetwork(2, 2, 1, 0.5f);
            Matrix[] inputs = new Matrix[4];
            Matrix[] targets = new Matrix[4];

            inputs[0] = new Matrix(nn.inputN, 1);
            inputs[1] = new Matrix(nn.inputN, 1);
            inputs[2] = new Matrix(nn.inputN, 1);
            inputs[3] = new Matrix(nn.inputN, 1);

            targets[0] = new Matrix(nn.outputN, 1);
            targets[1] = new Matrix(nn.outputN, 1);
            targets[2] = new Matrix(nn.outputN, 1);
            targets[3] = new Matrix(nn.outputN, 1);

            inputs[0].matrix[0, 0] = 0;
            inputs[0].matrix[1, 0] = 0;
            inputs[1].matrix[0, 0] = 0;
            inputs[1].matrix[1, 0] = 1;
            inputs[2].matrix[1, 0] = 1;
            inputs[2].matrix[0, 0] = 0;
            inputs[3].matrix[0, 0] = 1;
            inputs[3].matrix[1, 0] = 1;

            targets[0].matrix[0, 0] = 0;
            targets[1].matrix[0, 0] = 1;
            targets[2].matrix[0, 0] = 1;
            targets[3].matrix[0, 0] = 0;

            for (int i = 0; i < epoc; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    nn.input = inputs[j];
                    nn.target = targets[j];
                    nn.feedForward();
                    nn.backProp();
                    Console.WriteLine(nn.output.ToString());
                }
                
            }
        }
    }
}
