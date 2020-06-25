using System;
using System.Drawing;
using System.Text;

namespace pract_25_06_20
{
    public class Matrix
    {
        public double[,] Cells => _cells;
        public Size Size => new Size(_cells.GetLength(1), _cells.GetLength(0));
        private double[,] _cells;

        public Matrix(double[,] cells) 
            => _cells = cells;

        public double this[int i, int j]
        {
            get => _cells[i, j];
            set => _cells[i, j] = value;
        }

        public bool IsSameSize(Matrix matrix) =>
            Size.Width == matrix.Size.Width && Size.Height == matrix.Size.Height;

        public void Add(Matrix matrix)
        {
            if (!IsSameSize(matrix))
                throw new ArgumentException();
            for (int i=0; i< Size.Height; i++)
            for (int j = 0; j < Size.Width; j++)
                _cells[i, j] += matrix[i, j];
        }

        public void Sub(Matrix matrix)
        {
            if (!IsSameSize(matrix))
                throw new ArgumentException();
            for (int i=0; i< Size.Height; i++)
            for (int j = 0; j < Size.Width; j++)
                _cells[i, j] -= matrix[i, j];
        }

        public void Multiply(double k)
        {
            for (int i=0; i< Size.Height; i++)
            for (int j = 0; j < Size.Width; j++)
                _cells[i, j] *= k;
        }

        public string GetOutputString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                    builder.Append(_cells[i, j] + " ");
                builder.Append('\r');
            }
            return builder.ToString();
        }
    }
}