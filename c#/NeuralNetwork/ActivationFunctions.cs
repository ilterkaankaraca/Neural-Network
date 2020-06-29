using System;
namespace NeuralNetwork
{
        public class ActivationFunctions
        {

            public static Matrix Sigmoid(Matrix input)
            {
                Matrix output = new Matrix(input);
                for (int i = 0; i < output.row; i++)
                {
                    for (int j = 0; j < output.column; j++)               
                        output.data[i, j] = 1f / (1f + (float)Math.Exp(-output.data[i, j]));
                }
                return output;
            }
            public static Matrix Tanh(Matrix input)
            {
                Matrix output = new Matrix(input);
                for (int i = 0; i < output.row; i++)
                {
                    for (int j = 0; j < output.column; j++)               
                        output.data[i, j] = 2f / (1f + (float)Math.Exp(-2f*output.data[i, j]))-1;
                }
                return output;
            }
            public static Matrix sigmoid(Matrix input)
            {
                Matrix output = new Matrix(input);
                for (int i = 0; i < output.row; i++)
                {
                    for (int j = 0; j < output.column; j++)
                    { 
                        output.data[i,j] = 1.0f / (1.0f + (float)Math.Exp(-output.data[i,j]));
                    }
                }
                return output;
            }

            public static Matrix DerSigmoid(Matrix input)
            {
                Matrix output = new Matrix(input);
                for (int i = 0; i < output.row; i++)
                {
                    for (int j = 0; j < output.column; j++)
                    { 
                        output.data[i,j] =  output.data[i,j] * (1.0f - output.data[i,j]);
                    }
                }
                return output;
            }
            public static Matrix DerTanh(Matrix input)
            {
                Matrix output = new Matrix(input);
                for (int i = 0; i < output.row; i++)
                {
                    for (int j = 0; j < output.column; j++)
                    { 
                        output.data[i,j] = 1.0f - (output.data[i,j]  * output.data[i,j]);
                    }
                }
                return output;
            }
           
        }
}