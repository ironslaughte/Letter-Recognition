using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_Hopfield_WinForm.Math.Interfaces
{
    public interface IPredictable
    {
        int Predict(Vector vecLetter);
    }
}
