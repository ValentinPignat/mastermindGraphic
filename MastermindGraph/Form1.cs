using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MastermindGraph
{
    public partial class Form1 : Form
    {
        const int NBCOLUMS = 4;
        int tryCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void colorSelect(object sender, EventArgs e)
        {
            PictureBox color = sender as PictureBox;
            fillColor(color.BackColor);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            for (int i = 0; i < NBCOLUMS; i++)
            {
                tLPGuess.GetControlFromPosition(i, tryCount).BackColor = Control.DefaultBackColor;
                btnSubmit.Enabled = false;
            }
        }
        private void fillColor(System.Drawing.Color color) {
            for (int i = 0; i < NBCOLUMS; i++) {
                if (tLPGuess.GetControlFromPosition(i, tryCount).BackColor == Control.DefaultBackColor)
                {
                    tLPGuess.GetControlFromPosition(i, tryCount).BackColor = color;
                    if (i == NBCOLUMS-1) {
                        btnSubmit.Enabled = true;
                    }
                    break;
                }
            }
        }
        private void submit() 
        {
            tryCount++;
            btnSubmit.Enabled = false;
        }
    }
}
