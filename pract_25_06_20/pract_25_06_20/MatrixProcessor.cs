using System.Collections.Generic;

namespace pract_25_06_20
{
    public class MatrixProcessor
    {
        private Dictionary<int, Matrix> _matrices;

        public MatrixProcessor() =>
            _matrices = new Dictionary<int, Matrix>();

        public void Create(int index, double[,] values) =>
            _matrices[index] =  new Matrix(values);

        public string Show(int index) =>
            _matrices[index].GetOutputString();

        public void SumMatrices(int i, int j) =>
            _matrices[i].Add(_matrices[j]);

        public void SubMatrices(int i, int j) =>
            _matrices[i].Sub(_matrices[j]);

        public void MpMatrix(int i, double k) =>
            _matrices[i].Multiply(k);
    }
}