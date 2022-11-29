using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_Hopfield_WinForm
{
    public class Painter
    {
        private readonly int _cellInitialOffsetX = 12;
        private readonly int _cellInitialOffsetY = 12;

        public PictureBox[,] Cells { get; }

        private Image _whiteImage;
        private Image _blackImage;

        private const int Dimension = 6;
        private const int CellSize = 25;
        private const int CellOffset = 25;

        private const string WhitePicPath = @".\Pictures\\WhiteImg.png";
        private const string BlackPicPath = @".\Pictures\\BlackImg.png";

        public Painter(Control.ControlCollection сontrols, MouseEventHandler clickAction = null, int offsetX = 12, int offsetY = 12)
        {
            Cells = new PictureBox[Dimension, Dimension];
            _cellInitialOffsetX = offsetX;
            _cellInitialOffsetY = offsetY;
            InitializeImg();
            InitializeCells(сontrols, clickAction);
        }

        private void InitializeImg()
        {
            _whiteImage = Image.FromFile(WhitePicPath);
            _blackImage = Image.FromFile(BlackPicPath);
        }

        private void InitializeCells(Control.ControlCollection сontrols, MouseEventHandler clickAction)
        {
            for (var i = 0; i < Dimension; i++)
            {
                for (var j = 0; j < Dimension; j++)
                {
                    Cells[i, j] = new PictureBox();
                    Cells[i, j].MouseClick += clickAction;
                    Cells[i, j].Location = new Point(_cellInitialOffsetX + (CellOffset * i),
                        _cellInitialOffsetY + (CellOffset * j));
                    Cells[i, j].Size = new Size(CellSize, CellSize);
                    Cells[i, j].Image = _whiteImage;
                    Cells[i, j].ForeColor = Color.White;
                    Cells[i, j].Name = $"{i},{j}";
                    сontrols.Add(Cells[i, j]);                  
                }
            }
        }

        public void ChangeImgPaint(int i, int j)
        {
            Cells[i, j].Image = Cells[i, j].Image == _whiteImage ? _blackImage : _whiteImage;
            Cells[i, j].ForeColor = Cells[i, j].ForeColor == Color.White ? Color.Black : Color.White;
        }

        public void UpdateCells(Letter letter)
        {
            Vector vectorizeLetter = letter.Vector;
            for (int i = 0, j = 0; i < vectorizeLetter.Size;)
            {
                Cells[(i % 6), j].Image = vectorizeLetter[i] == 1 ? _blackImage : _whiteImage;
                i++;
                if (i % 6 == 0)
                    j++;
            }
        }
    }
}
