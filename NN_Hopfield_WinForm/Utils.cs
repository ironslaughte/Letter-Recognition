using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_Hopfield_WinForm
{
    public static class Utils
    {
        public static (int, int) ParseIdxClick(PictureBox sender)
        {
            string[] idxPics = sender.Name.Split(',');
            return (Convert.ToInt32(idxPics[0]), Convert.ToInt32(idxPics[1]));
        }

        public static Vector ConvertToVector(this Painter painter)
        {
            Vector vectorLetter = new Vector(new List<float>());
            for (int i = 0; i < painter.Cells.Length / 6; i++)
            {
                for (int j = (painter.Cells.Length / 6) - 1; j >= 0; j--)
                {
                    if (painter.Cells[j, i].ForeColor == Color.White)
                        vectorLetter.Add(-1);
                    else
                        vectorLetter.Add(1);
                }
            }
            return vectorLetter;
        }
    }
}
