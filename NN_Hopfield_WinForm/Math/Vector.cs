using NN_Hopfield_WinForm.Math.Interfaces;
using System;
using System.Collections.Generic;

namespace NN_Hopfield_WinForm
{
    public class Vector : IMathObject1D
    {
        private readonly List<float> _vector;
        public int Size => _vector.Count;

        public Vector(List<float> vector) => _vector = vector;
        public void Add(float value) => _vector.Add(value);

        public override bool Equals(object obj)
        {
            if (!(obj is Vector otherVec) || otherVec.Size != Size) return false;
            for (int i = 0; i < Size; i++)
                if (System.Math.Abs(_vector[i] - otherVec[i]) > 0.0001f) return false;
            return true;
        }

        public Vector MultiplyByNum(float num)
        {
            List<float> result = new List<float>(_vector);
            for (int i = 0; i < Size; i++)
                result[i] *= num;
            return new Vector(result);
        }

        public Matrix Multiply(Vector vector)
        {
            if (vector.Size != Size) return new Matrix(0);

            Matrix res = new Matrix(Size);
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    res[i][j] += _vector[i] * vector[j];
            return res;
        }

        public float this[int index]
        {
            get => _vector[index];
            set => _vector[index] = value;
        }
    }
}
