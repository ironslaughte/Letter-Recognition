using NN_Hopfield_WinForm.Math.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NN_Hopfield_WinForm
{
      class Hemming : IPredictable
      {
        private float _bz, _eps;
        private List<Vector> _weightsZ;
        Vector Uz, Ua;

        private const float Un = 37f, K1 = 0.027f, Area = 0.0001f;

        public Hemming(List<Letter> letters)
        {
            _weightsZ = new List<Vector>();
            foreach(var letter in letters)
                _weightsZ.Add(letter.Vector.MultiplyByNum(0.5f));            
            _eps = 1f/letters.Count;
            _bz = letters[0].Size / 2f;
        }

        public int Predict(Vector vecLetter)
        {
            Uz = new Vector(_weightsZ.Count);
            LayerZ(vecLetter);
            ActivationZ();
            Ua = Utils.CopyVector(Uz);
            Vector outputVec = LayerMaxNet(Uz);
            return ActivationY(outputVec);
        }

        private void ActivationZ()
        {
            for (int i = 0; i < Uz.Size; i++)
            {
                if (Uz[i] <= 0 || (Uz[i] - Area) <= 0) Uz[i] = 0;
                else if (Uz[i] > Un) Uz[i] = Un;
                else Uz[i] = K1 * Uz[i];
            }
        }

        private void ActivationMaxNet(Vector Ua)
        {
            for (int i = 0; i < Ua.Size; i++)
                if (Ua[i] <= 0 || (Ua[i] - Area) <= 0) Ua[i] = 0;
        }

        private int ActivationY(Vector Ua) => Ua.ToList().FindIndex(x => x == Ua.Max());

        private float SumPrevUa(Vector Ua_prev, int index) => Ua_prev.ToList().Select(x => x).Where(x => x != Ua_prev[index]).Sum(x => x);

        private Vector LayerMaxNet(Vector UaPrev)
        {
            int countIter = 0;
            while (countIter < 15)
            {
                for (int i = 0; i < UaPrev.Size; i++)
                    Ua[i] = UaPrev[i] - _eps * SumPrevUa(UaPrev, i);

                ActivationMaxNet(Ua);
                UaPrev = Ua;
                countIter++;
            }
            return Ua;
        }

        private void LayerZ(Vector x)
        {
            for (int i = 0; i < Uz.Size; i++)
            {
                for (int j = 0; j < _weightsZ[i].Size; j++)
                    Uz[i] += _weightsZ[i][j] * x[j];

                Uz[i] += _bz;
            }            
        }
    }
}
