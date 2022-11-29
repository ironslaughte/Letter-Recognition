using System;
using System.Collections.Generic;
using System.Linq;

namespace NN_Hopfield_WinForm
{
      class Hemming
      {
        private int numClasses;
        private float _bz, _eps;
        private List<Vector> _weightsZ;

        private const float Un = 37f, K1 = 0.027f, Area = 0.0001f;

        public Hemming(List<Letter> letters)
        {
            _weightsZ = new List<Vector>();
            foreach(var letter in letters)
            {
                _weightsZ.Add(letter.Vector.MultiplyByNum(0.5f));
            }
            numClasses = letters.Count();
            _eps = 1f/letters.Count;
            _bz = letters[0].Size / 2f;
        }

        public int Predict(Vector x)
        {
            Func<Vector> initVec = () =>
            {
                Vector vec = new Vector(new List<float>());
                for (int i = 0; i < _weightsZ.Count; i++)
                    vec.Add(0);
                return vec;
            };
            Vector Uz = initVec();
            LayerZ(x, Uz);
            Func<Vector, Vector> copyVector = (vecToCopy) =>
            {
                Vector vec = new Vector(new List<float>());
                for (int i = 0; i < vecToCopy.Size; i++)
                    vec.Add(vecToCopy[i]);
                return vec;
            };
            Vector Ua = copyVector(Uz);
            LayerA(Uz, Ua);

            return ActivationY(Ua);
        }

        private void ActivationZ(Vector Uz)
        {
            for (int i = 0; i < Uz.Size; i++)
            {
                if (Uz[i] <= 0 || (Uz[i] - Area) <= 0) Uz[i] = 0;
                else if (Uz[i] > Un) Uz[i] = Un;
                else Uz[i] = K1 * Uz[i];
            }
        }

        private void ActivationA(Vector Ua)
        {
            for (int i = 0; i < Ua.Size; i++)
                if (Ua[i] <= 0 || (Ua[i] - Area) <= 0) Ua[i] = 0;
        }

        private int ActivationY(Vector Ua)
        {
            float max = 0;
            int idxClass = -1;
            for(int i = 0; i < Ua.Size; i++)
            {
                if (Ua[i] > max)
                {
                    idxClass = i;
                    max = Ua[i];
                }
            }
            return idxClass;
        }

        private float SumPrevUa(Vector Ua_prev, int index)
        {
            float res = 0F;
            for (int i = 0; i < Ua_prev.Size; i++)
                if(i != index)
                    res += Ua_prev[i];            
            return res;
        }

        private bool EndCycleMaxNet(Vector Ua)
        {
            int count = 0;
            for(int i = 0; i < Ua.Size; i++)
                if (Ua[i] == 0 || (Ua[i] - Area) <= 0) count++;

            if (count == numClasses-1) return true;
            return false;
        }

        private void LayerA(Vector UaPrev,Vector Ua)
        {
            int countIter = 0;
            while (EndCycleMaxNet(Ua) != true && countIter < 15)
            {
                for (int i = 0; i < UaPrev.Size; i++)
                    Ua[i] = UaPrev[i] - _eps * SumPrevUa(UaPrev, i);

                ActivationA(Ua);
                UaPrev = Ua;
                countIter++;
            } 
        }

        private void LayerZ(Vector x, Vector Uz)
        {
            for (int i = 0; i < Uz.Size; i++)
            {
                for (int j = 0; j < _weightsZ[i].Size; j++)
                    Uz[i] += _weightsZ[i][j] * x[j];

                Uz[i] += _bz;
            }
            ActivationZ(Uz);
        }
    }
}
