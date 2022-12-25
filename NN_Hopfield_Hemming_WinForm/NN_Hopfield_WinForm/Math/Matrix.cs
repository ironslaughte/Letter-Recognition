using NN_Hopfield_WinForm.Math.Interfaces;
using System.Collections.Generic;

namespace NN_Hopfield_WinForm
{
    public class Matrix : IMathObject2D
    {
        private readonly List<Vector> _container;

        public Vector Size => new Vector(new List<float>() { _container.Count, this._container[0].Size });

        public Matrix(List<Vector> container)
        {
            _container = container;
        }      
        public Matrix(int dimension)
        {
            _container = new List<Vector>();
            for (int i = 0; i < dimension; i++)              
                _container.Add(new Vector(CreateZeroList(dimension)));
        }
        
        private List<float> CreateZeroList(int dimension)
        {
            List<float> zeroList = new List<float>();
            for (int i = 0; i < dimension; i++)
                zeroList.Add(0f);
            return zeroList;
        }
        public void Sum(Matrix matrix)
        {
            for (int i = 0; i < _container.Count; i++)
                for (int j = 0; j < _container[i].Size; j++)
                    _container[i][j] += matrix[i][j];
        }
        public void MultiplyByNum(float num)
        {
            for (int i = 0; i < _container.Count; i++)
                for (int j = 0; j < _container[i].Size; j++)
                    _container[i][j] *= num;
        }
        public Vector this[int index]
        {
            get => _container[index];
            set => _container[index] = value;
        }
    }
}
