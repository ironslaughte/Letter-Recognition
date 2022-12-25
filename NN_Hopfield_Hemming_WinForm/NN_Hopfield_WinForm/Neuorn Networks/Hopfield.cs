using NN_Hopfield_WinForm.Math.Interfaces;
using System.Collections.Generic;

namespace NN_Hopfield_WinForm
{
    public class Hopfield : IPredictable
    {
        private readonly Matrix _weights;
        private readonly List<Letter> _letters;

        public Hopfield(List<Letter> letters)
        {
            this._letters = letters;
            _weights = new Matrix(letters[0].Vector.Size);
            InitWeights();
        }

        public int Predict(Vector vecLetter)
        {
            Vector res = new Vector(vecLetter.Size);
            int count = 0, idxOfEqualLetter = -1;
            while (count < 25 && idxOfEqualLetter == -1)
            {
                Layer(res, vecLetter);   
                Activation(res);
                idxOfEqualLetter = CheckInLetters(res);
                count++;
            }
            return idxOfEqualLetter;
        }
        private void Layer(Vector vec, Vector vecLetter)
        {
            for (int i = 0; i < _weights.Size[0]; i++)
            {
                for (int j = 1; j < _weights.Size[1]; j++)
                    vec[i] += _weights[i][j] * vecLetter[j];
            }
        }
        private int CheckInLetters(Vector pred)
        {
            for (int i = 0; i < _letters.Count; i++)
                if (pred.Equals(_letters[i].Vector)) return i;
            return -1;
        }

        private void Activation(Vector v)
        {
            for (int i = 0; i < v.Size; i++)
                v[i] = v[i] < 0 ? -1 : 1;
        }

        private void InitWeights()
        {
            for (int i = 0; i < _letters.Count; i++)
            {
                Vector letter = _letters[i].Vector;
                _weights.Sum(letter.Multiply(letter));
            }
            _weights.MultiplyByNum(1f / _letters[0].Size);
            for (int i = 0; i < _weights.Size[0]; i++)
                _weights[i][i] = 0;
        }
    }
}
