using System;

namespace NeuralNetwork
{



    /**
     *
     * @author Ilterkaan Karaca
     */
    public class NeuralNetwork
    {
        public int inputN, hiddenN, outputN;
        float learningRate;
        public Matrix input;
        public Matrix output;
        public Matrix target;
        Matrix hidden;
        Matrix[] weights = new Matrix[2];
        Matrix[] biases = new Matrix[2];
        public NeuralNetwork(int inputN, int hiddenN, int outputN, float learningRate)
        {
            this.inputN = inputN;
            this.hiddenN = hiddenN;
            this.outputN = outputN;
            this.learningRate = learningRate;

            input = new Matrix(inputN, 1);
            hidden = new Matrix(hiddenN, 1);
            output = new Matrix(outputN, 1);

            weights[0] = new Matrix(hiddenN, inputN);
            weights[1] = new Matrix(outputN, hiddenN);
            biases[0] = new Matrix(hiddenN, 1);
            biases[1] = new Matrix(outputN, 1);


            weights[0].Randomize();
            weights[1].Randomize();
            biases[0].Randomize();
            biases[1].Randomize();

        }
        public static void activation(Matrix temp)
        {
            for (int i = 0; i < temp.row; i++)
            {
                for (int j = 0; j < temp.column; j++)
                    temp.matrix[i,j] = (1f / (1f + (float)Math.Exp(-temp.matrix[i,j])));
            }
        }
        public static float error(Matrix output, Matrix target)
        {
            float err = 0.0f;
            Matrix temp = new Matrix(output.row, output.column);
            for (int i = 0; i < temp.row; i++)
            {
                for (int j = 0; j < temp.column; j++)
                    temp.matrix[i,j] = 0.5f * (float)(Math.Pow((double)(target.matrix[i,j] - output.matrix[i,j]), 2.0));
            }
            for (int i = 0; i < temp.row; i++)
            {
                err += temp.matrix[i,0];
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
                    temp.matrix[i,j] = output.matrix[i,j] * (1f - output.matrix[i,j]);
            }
            return temp;
        }
        public void feedForward()
        {


            hidden = Matrix.mult(weights[0], input);//h

            hidden = Matrix.add(hidden, biases[0]);//neth

            activation(hidden);//outh

            output = Matrix.mult(weights[1], hidden);//o

            output = Matrix.add(output, biases[1]);//neto
            activation(output);//outo  

        }
        public void backProp()
        {
            //output layer
            Matrix out_d_error_L2 = dError(output, target);
            Matrix net_d_out_L2 = dActivation(output);
            Matrix net_d_error_L2 = Matrix.eWMult(out_d_error_L2, net_d_out_L2);
            Matrix w_d_error_L2 = Matrix.mult(net_d_error_L2, Matrix.transpose(hidden));
            Matrix out_d_error_L1 = Matrix.mult(Matrix.transpose(weights[1]), net_d_error_L2);
            weights[1] = Matrix.subtract(weights[1], Matrix.scalarMult(w_d_error_L2, learningRate));

            //hidden layer
            Matrix net_d_out_L1 = dActivation(hidden);
            Matrix net_d_error_L1 = Matrix.eWMult(out_d_error_L1, net_d_out_L1);
            Matrix w_d_error_L1 = Matrix.mult(net_d_error_L1, Matrix.transpose(input));
            weights[0] = Matrix.subtract(weights[0], Matrix.scalarMult(w_d_error_L1, learningRate));
        }
        /**
         * @param args the command line arguments
         */
        public static void main(String[] args)
        {
            int epoc = 1;

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

            inputs[0].matrix[0,0] = 0;
            inputs[0].matrix[1,0] = 0;
            inputs[1].matrix[0,0] = 0;
            inputs[1].matrix[1,0] = 1;
            inputs[2].matrix[1,0] = 1;
            inputs[2].matrix[0,0] = 0;
            inputs[3].matrix[0,0] = 1;
            inputs[3].matrix[1,0] = 1;

            targets[0].matrix[0,0] = 0;
            targets[1].matrix[0,0] = 1;
            targets[2].matrix[0,0] = 1;
            targets[3].matrix[0,0] = 0;

            for (int i = 0; i < epoc; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    nn.input = inputs[j];
                    nn.target = targets[j];
                    nn.feedForward();
                    nn.backProp();
                }
            }


        }

    }
}