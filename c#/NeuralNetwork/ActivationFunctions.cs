using System;
namespace NeuralNetwork
{
        public class ActivationFunctions
        {

            public static void Sigmoid(Matrix input)
            {
                for (int i = 0; i < input.row; i++)
                {
                    for (int j = 0; j < input.column; j++)               
                        input.matrix[i, j] = 1f / (1f + (float)Math.Exp(-input.matrix[i, j]));
                }
            }
            public static void Tanh(Matrix input)
            {
                for (int i = 0; i < input.row; i++)
                {
                    for (int j = 0; j < input.column; j++)               
                        input.matrix[i, j] = 2f / (1f + (float)Math.Exp(-2f*input.matrix[i, j]))-1;
                }
            }
            private static void sigmoid(Matrix input)
            {
                for (int i = 0; i < input.row; i++)
                {
                    for (int j = 0; j < input.column; j++)
                    { 
                        input.matrix[i,j] = 1.0f / (1.0f + (float)Math.Exp(-input.matrix[i,j]));
                    }
                }
            }

            private static void DerSigmoid(Matrix input)
            {
                for (int i = 0; i < input.row; i++)
                {
                    for (int j = 0; j < input.column; j++)
                    { 
                        input.matrix[i,j] =  input.matrix[i,j] * (1.0f - input.matrix[i,j]);
                    }
                }
            }
            private static void DerTanh(Matrix input)
            {
                for (int i = 0; i < input.row; i++)
                {
                    for (int j = 0; j < input.column; j++)
                    { 
                        input.matrix[i,j] = 1.0f - (input.matrix[i,j]  * input.matrix[i,j]);
                    }
                }
            }
        }
}