using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// ETML
/// Author : Valentin Pignat
/// Date (Creation) : 16.11.2023
/// Description : Mastermind avec interface grapgique (Windows Forms) 

namespace MastermindGraph
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();

            // Longueur du code par defaut
            tlpGuess.ColumnCount = 4;
            tlpFeedback.ColumnCount = 4;

            // Génére code
            RandomCode();
        }

        // Valeurs par défault et essais
        int colorPoolSize = 7;
        int codeLength = 4;
        int tryCount = 0;
        System.Drawing.Color[] COLOR_POOL_DEFAULT = { System.Drawing.Color.Yellow, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.DarkOrange, System.Drawing.Color.Cyan, System.Drawing.Color.Purple };
        System.Drawing.Color[] colorPool = { System.Drawing.Color.Yellow, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.DarkOrange, System.Drawing.Color.Cyan, System.Drawing.Color.Purple };
        System.Drawing.Color[] secretCode = new System.Drawing.Color[7];

        /// <summary>
        /// Prends la couleur de l'élément selectioné et appelle FillColor()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSelect(object sender, EventArgs e)
        {
            PictureBox color = sender as PictureBox;
            FillColor(color.BackColor);
        }

        /// <summary>
        /// Soumet l'essai à la vérification et passe à la ligne suivante 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            int currentRight = 0;
            int currentWrongPlace = 0;
            // Tableau à deux dimension PSKSKSK
            bool[,] indexVerified = new bool[2, 7];
            for (int i = 0; i < codeLength; i++)
            {
                if (tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[i])
                {
                    // Feedback 
                    tlpFeedback.GetControlFromPosition(currentRight, tryCount).BackColor = System.Drawing.Color.Black;

                    // Evite de reverifier comme mal placés
                    indexVerified[0, i] = true;
                    indexVerified[1, i] = true;

                    // Juste +1
                    currentRight++;

                }
            }

            for (int i = 0; i < codeLength; i++)
            {
                // Si pas bien placés 
                if (!indexVerified[0, i])
                {
                    for (int j = 0; j < codeLength; j++)
                    {
                        // Si pas deja validé dans le code secret 
                        if (!indexVerified[1, j] && tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[j])
                        {

                            // Feedback 
                            tlpFeedback.GetControlFromPosition(currentRight + currentWrongPlace, tryCount).BackColor = System.Drawing.Color.Red;

                            // Evite doublons
                            indexVerified[0, i] = true;
                            indexVerified[1, j] = true;

                            // Juste +1
                            currentWrongPlace++;

                            break;
                        }
                    }
                }
            }
            btnClear.Enabled = false;
            // Victoire -> résultats / message de fin 
            if (currentRight == codeLength)
            {
                MessageBox.Show("\nBravo!\nVous avez découvert le code en " + (tryCount + 1) + " essais.\n");
                EndSpectate();
            }
            tryCount++;
            if (tryCount == 10)
            {
                MessageBox.Show("Vous avez perdu :<\nLe code secret était: " + secretCode + "\n");
                // AFFICHER LE CODE 
                EndSpectate();
            }
            btnSubmit.Enabled = false;

        }

        /// <summary>
        /// Efface la ligne en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nudCodeLength.Value; i++)
            {
                tlpGuess.GetControlFromPosition(i, tryCount).BackColor = Control.DefaultBackColor;
                tlpFeedback.GetControlFromPosition(i, tryCount).BackColor = Control.DefaultBackColor;
                btnSubmit.Enabled = false;
            }
            if (tryCount == 0) {
                EnableParameters();
            }
            btnClear.Enabled = false;
        }

        /// <summary>
        /// Rempli la première case vide de la ligne avec la couleur choisie
        /// </summary>
        /// <param name="color"></param>
        private void FillColor(System.Drawing.Color color) {
            nudCodeLength.Enabled = false;
            nudColorPoolSize.Enabled = false;
            btnClear.Enabled = true;
            for (int i = 0; i < nudCodeLength.Value; i++) {
                if (tlpGuess.GetControlFromPosition(i, tryCount).BackColor == Control.DefaultBackColor)
                {
                    tlpGuess.GetControlFromPosition(i, tryCount).BackColor = color;
                    if (i == nudCodeLength.Value - 1) {
                        btnSubmit.Enabled = true;
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// Permet de changer la longeur du code 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCodeLength_ValueChanged(object sender, EventArgs e)
        {
            tlpGuess.ColumnCount = (int)nudCodeLength.Value;
        }

        /// <summary>
        /// Termine la partie en cours et en recommence une
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tryCount+1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tlpGuess.GetControlFromPosition(j,i).BackColor = Control.DefaultBackColor;
                    tlpFeedback.GetControlFromPosition(j, i).BackColor = Control.DefaultBackColor;
                }
            }
            tryCount = 0;
            foreach (var picBox in this.Controls.OfType<PictureBox>())
            {
                picBox.Enabled = Enabled;
            }
            btnRestart.BackColor = DefaultBackColor;
            btnClear.Enabled = false;
            EnableParameters();
            RandomCode();
        }

        /// <summary>
        /// Rends utilisable les paramêtre quand aucune partie n'est active 
        /// </summary>
        private void EnableParameters()
        {
            nudCodeLength.Enabled = true;
            nudColorPoolSize.Enabled = true;
        }

        /// <summary>
        /// Crée un code secret selon la longueur et le nombre de couleur
        /// </summary>
        private void RandomCode()
        {
            // Generer Code aléatoire (index aléatoire dans colorPool)
            Random rnd = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                int x = rnd.Next(0, colorPoolSize);
                secretCode[i] = colorPool[x];
                // TEST
                tlpGuess.GetControlFromPosition(i, 9).BackColor = secretCode[i];
            }
        }

        /// <summary>
        /// Garde la partie ouverte et seul le bouton restart actif 
        /// </summary>
        private void EndSpectate() {
            foreach (var picBox in this.Controls.OfType<PictureBox>()) {
                picBox.Enabled = false;
            }
            btnClear.Enabled = false;
            btnRestart.BackColor = Color.LightSteelBlue;
        }

        
    }
}
