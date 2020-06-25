using System;
namespace NeuralNetwork
{
        public class ActivationFunctions
        {

            public static void Sigmoid(Matrix temp)
            {
                for (int i = 0; i < temp.row; i++)
                {
                    for (int j = 0; j < temp.column; j++)               
                        temp.matrix[i, j] = 1f / (1f + (float)Math.Exp(-temp.matrix[i, j]));
                }
            }
            public static void Tanh(Matrix temp)
            {
                for (int i = 0; i < temp.row; i++)
                {
                    for (int j = 0; j < temp.column; j++)               
                        temp.matrix[i, j] = 2f / (1f + (float)Math.Exp(-2f*temp.matrix[i, j]))-1;
                }
            }

        }
}