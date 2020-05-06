using System;

namespace NeuralNetwork
{
	public class Matrix
	{
		int row;
		int column;
		float[,] matrix;

		static Random randomize = new Random();

		public Matrix(int row, int column)
		{
			this.row = row;
			this.column = column;
			matrix = new float[row][column];
		}

		// Copy Constructor
		public Matrix(Matrix m)
		{
			this.rows = m.rows;
			this.cols = m.cols;

			this.data = new float[rows, cols];

			for(int i = 0; i < rows; i++)
				for(int j = 0; j < cols; j++)
					this.data[i, j] = m.data[i, j];
		}
		public static Matrix multiple(Matrix M1, Matrix M2)
		{
			Matrix temp = new Matrix(M1.row, M2.column);
			if (M1.column == M2.row)
			{
				for (int i = 0; i < M1.matrix.length; i++)
				{
					for (int j = 0; j < M2.matrix[0].length; j++)
					{
						for (int k = 0; k < M2.matrix.length; k++)
						{
							temp.matrix[i][j] += M1.matrix[i][k] * M2.matrix[k][j];
						}
					}
				}
			}
			else
			{
				Console.WriteLine("M1.row and M2.column must be equal.");
				return null;
			}
			return temp;
		}
		// Element-wise add
		public static Matrix add(Matrix M1, Matrix M2)
		{
			Matrix temp = new Matrix(M1.row, M1.column);
			if (M1.row == M2.row && M1.column == M2.column)
			{
				for (int i = 0; i < M1.row; i++)
				{
					for (int j = 0; j < M2.column; j++)
					{
						temp.matrix[i][j] = M1.matrix[i][j] + M2.matrix[i][j];
					}
				}
			}
			else
			{
				Console.WriteLine("adding error");
			}
			return temp;
		}

		public static Matrix subtract(Matrix M1, Matrix M2)
		{
			Matrix temp = new Matrix(M1.row, M1.column);
			if (M1.row == M2.row && M1.column == M2.column)
			{
				for (int i = 0; i < M1.row; i++)
				{
					for (int j = 0; j < M2.column; j++)
					{
						temp.matrix[i][j] = M1.matrix[i][j] - M2.matrix[i][j];
					}
				}
			}
			else
			{
				Console.WriteLine("subtraction error");
			}
			return temp;
		}
		public static Matrix eWMult(Matrix M1, Matrix M2)
		{ //element wise multiplacation
			Matrix temp = new Matrix(M1.row, M1.column);
			if (M1.row == M2.row && M1.column == M2.column)
			{
				for (int i = 0; i < M1.row; i++)
				{
					for (int j = 0; j < M2.column; j++)
					{
						temp.matrix[i][j] = M1.matrix[i][j] * M2.matrix[i][j];
					}
				}
			}
			else
			{
				Console.WriteLine("eWMult error");
			}
			return temp;
        }
        public static Matrix scalarMult(Matrix M1, float number)
        {
            Matrix temp = new Matrix(M1.row, M1.column);
            for (int i = 0; i < M1.row; i++)
            {
                for (int j = 0; j < M1.column; j++)
                {
                    temp.matrix[i][j] = M1.matrix[i][j] * number;
                }
            }
            return temp;
        }
        public static Matrix powMatrix(Matrix M1)
        {
            Matrix temp = new Matrix(M1.row, M1.column);
            for (int i = 0; i < M1.row; i++)
            {
                for (int j = 0; j < M1.column; j++)
                {
                    temp.matrix[i][j] = M1.matrix[i][j] * M1.matrix[i][j];
                }
            }
            return temp;
        }
        public static Matrix transpose(Matrix M1)
        {
            Matrix temp = new Matrix(M1.column, M1.row);
            for (int i = 0; i < M1.row; i++)
            {
                for (int j = 0; j < M1.column; j++)
                {
                    temp.matrix[j][i] = M1.matrix[i][j];
                }
            }
            return temp;
        }
        public void randomize()
        {
            Random rand = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i][j] = rand.nextfloat();
                }
            }
        }
        public void mult(Matrix M2)
        {
            // Matris çarpımının tutulacağı matris.
            if (this.column == M2.row)
            {
                for (int i = 0; i < this.matrix.length; i++)
                {
                    for (int j = 0; j < M2.matrix[0].length; j++)
                    {
                        for (int k = 0; k < M2.matrix.length; k++)
                        {
                            // M1'in i. satırı ve M2'nin j. sütununun
                            // çarpımından elde edilen toplam.
                            this.matrix[i][j] += this.matrix[i][k] * M2.matrix[k][j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("M1.row and M2.column must be equal.");
            }
        }
        public void add(Matrix M2)
        {
            if (this.row == M2.row && this.column == M2.column)
            {
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < M2.column; j++)
                    {
                        this.matrix[i][j] = this.matrix[i][j] + M2.matrix[i][j];
                    }
                }
            }
            else
            {
                Console.WriteLine("add error");
            }
        }
        public void sub(Matrix M2)
        {
            if (this.row == M2.row && this.column == M2.column)
            {
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < M2.column; j++)
                    {
                        this.matrix[i][j] = this.matrix[i][j] - M2.matrix[i][j];
                    }
                }
            }
            else
            {
                Console.WriteLine("sub error");
            }
        }
        public void eWMult(Matrix M2)
        {
            if (this.row == M2.row && this.column == M2.column)
            {
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < M2.column; j++)
                    {
                        this.matrix[i][j] = this.matrix[i][j] * M2.matrix[i][j];
                    }
                }
            }
            else
            {
                Console.WriteLine("eWMult error");
            }
        }
        public void scalarMult(float number)
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    this.matrix[i][j] = this.matrix[i][j] * number;
                }
            }
        }
        public void powMatrix()
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    this.matrix[i][j] = this.matrix[i][j] * this.matrix[i][j];
                }
            }
        }
        public void transpose()
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    this.matrix[j][i] = this.matrix[i][j];
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            ret += string.Format("rows: {0}, cols: {1}\n", rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ret += data[i, j] + "\t";
                }
                ret += "\n";
            }

            return ret;
        }
    }
}


