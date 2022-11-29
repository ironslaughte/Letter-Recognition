using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NN_Hopfield_WinForm
{
    public partial class ViewForm : Form
    {
        private Painter _inputLetter;
        private Painter _outputLetter;
        private Hopfield _hopfieldModel;
        private Hemming _hemmingModel;
        List<Letter> _lettersToFit;
        Letter _unknowLetter;
        private int _idxToPred = -1;

        public ViewForm()
        {
            InitializeComponent();
            InitialazePainters();
            InitialazeLetters();
            InitialazeModels();
            PredButton.Enabled = false;
        }
      
        private void PictureBoxes_Click(object sender, EventArgs e)
        {
            var idxOnClick = Utils.ParseIdxClick((PictureBox)sender);
            _inputLetter.ChangeImgPaint(idxOnClick.Item1,idxOnClick.Item2);
        }

        private void PredButton_Click(object sender, EventArgs e)
        {
            Vector vectorLetter = _inputLetter.ConvertToVector();
            int idxLetter;

            if(_idxToPred == 0)
                idxLetter = _hemmingModel.Predict(vectorLetter);
            else
                idxLetter = _hopfieldModel.Predict(vectorLetter);

            UpdateOutputPainter(idxLetter);
        }

        private void UpdateOutputPainter(int idxLetter)
        {
            if (idxLetter != -1)
                _outputLetter.UpdateCells(_lettersToFit[idxLetter]);
            else
                _outputLetter.UpdateCells(_unknowLetter);
        }

        private void ListAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idxToPred = ListAI.SelectedIndex; // 0 - Хемминг, 1 - Хопфилд
            PredButton.Enabled = true;                                    
        }

        private void InitialazeModels()
        {
            _hopfieldModel = new Hopfield(_lettersToFit);
            _hemmingModel = new Hemming(_lettersToFit);
        }

        private void InitialazeLetters()
        {
            _lettersToFit = new List<Letter>
            {
                new Letter('р',new Vector(new List<float>{1,1,1,1,1,1,   1,-1,-1,-1,-1,1,  1,-1,-1,-1,-1,1,  1,1,1,1,1,1,          1,-1,-1,-1,-1,-1,  1,-1,-1,-1,-1,-1 })),
                new Letter('о',new Vector(new List<float>{-1,1,1,1,1,-1, 1,-1,-1,-1,-1,1,  1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,1,       1,-1,-1,-1,-1,1,  -1,1,1,1,1,-1 })),
                new Letter('т',new Vector(new List<float>{1,1,1,1,1,1,   -1,-1,1,1,-1,-1,  -1,-1,1,1,-1,-1, -1,-1,1,1,-1,-1,      -1,-1,1,1,-1,-1,   -1,-1,1,1,-1,-1 })),
                new Letter('д',new Vector(new List<float>{-1,-1,1,1,-1,-1,   -1,1,-1,-1,1,-1, -1,1,-1,-1,1,-1,  -1,1,-1,-1,1,-1,   1,1,1,1,1,1,  1,-1,-1,-1,-1,1 }))
            };
            _unknowLetter = new Letter('\0',
                new Vector
                (new List<float> {
                    1, -1, -1, -1, -1, -1,
                    -1, 1, -1, -1, -1, -1,
                    -1, -1, 1, -1, -1, -1,
                    -1, -1, -1, 1, -1, -1,
                    -1, -1, -1, -1, 1, -1,
                    -1, -1, -1, -1, -1, 1 }));
        }

        private void InitialazePainters()
        {
            _inputLetter = new Painter(Controls, clickAction: PictureBoxes_Click);
            _outputLetter = new Painter(Controls, clickAction: null, offsetX: 250);
        }
    }
}
