namespace NeuralNetwork
{
        public class Layer
        {
                int neuronNumber;
                Matrix input;
                Matrix output;
                Matrix weight;
                Matrix bias;
                string activationFunc;
                public Layer(int neuronNumber,string activationFunc)
                {
                        this.neuronNumber=neuronNumber;
                }
        }
}