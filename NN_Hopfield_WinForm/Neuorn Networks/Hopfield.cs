using System;
using System.Collections.Generic;

namespace NN_Hopfield_WinForm
{
    public class Hopfield
    {
        private readonly Matrix _weights;
        private readonly List<Letter> _letters;

        public Hopfield(List<Letter> letters)
        {
            this._letters = letters;
            _weights = new Matrix(letters[0].Vector.Size);
            InitWeights();
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

        public int Predict(Vector vectorLetter)
        {
            Vector res = new Vector(new List<float>());
            Action<Vector> init = (vec) =>
            {
                for (int i = 0; i < vectorLetter.Size; i++)
                    res.Add(0);
            };
            init(res);
            var idxOfEqualLetter = IndexOfEqualLetter(res, vectorLetter);
            return idxOfEqualLetter;
        }

        private int CheckInLetters(Vector pred)
        {
            for (int i = 0; i < _letters.Count; i++)
                if (pred.Equals(_letters[i].Vector)) return i;
            return -1;
        }

        private int IndexOfEqualLetter(Vector res, Vector vectorLetter)
        {
            int count = 0, idxOfEqualLetter = -1;
            while (count < 20 && idxOfEqualLetter == -1)
            {
                for (int i = 0; i < _weights.Size[0]; i++)
                {
                    for (int j = 1; j < _weights.Size[1]; j++)
                        res[i] += _weights[i][j] * vectorLetter[j];
                }

                Activation(res);
                idxOfEqualLetter = CheckInLetters(res);
                count++;
            }
            return idxOfEqualLetter;
        }

        private void Activation(Vector v)
        {
            for (int i = 0; i < v.Size; i++)
                v[i] = v[i] < 0 ? -1 : 1;
        }       
    }
}
