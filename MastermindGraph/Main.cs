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
        const int NB_TRIES = 10;
        const int PBOX_SIZE = 40;
        const int MARGIN_PBOX = 3;
        const int FB_SIZE = 15;
        const int MARGIN_FB =14;
        public Main()
        {
            InitializeComponent();
        }

        // Valeurs par défault et essais
        int colorPoolSize = 7;
        int tryCount = 0;
        Color[] COLOR_POOL_DEFAULT = { Color.Yellow, Color.Black, Color.Red, Color.Green, Color.DarkOrange, Color.Cyan, Color.Purple };
        Color[] colorPool = { Color.Yellow, Color.Black, Color.Red, Color.Green, Color.DarkOrange, Color.Cyan, Color.Purple };
        Color[] secretCode = new Color[7];

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
            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {
                if (tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[i])
                {
                    // Feedback 
                    tlpFeedback.GetControlFromPosition(currentRight, tryCount).BackColor = Color.Black;

                    // Evite de reverifier comme mal placés
                    indexVerified[0, i] = true;
                    indexVerified[1, i] = true;

                    // Juste +1
                    currentRight++;

                }
            }

            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {
                // Si pas bien placés 
                if (!indexVerified[0, i])
                {
                    for (int j = 0; j < (int)nudCodeLength.Value; j++)
                    {
                        // Si pas deja validé dans le code secret 
                        if (!indexVerified[1, j] && tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[j])
                        {

                            // Feedback 
                            tlpFeedback.GetControlFromPosition(currentRight + currentWrongPlace, tryCount).BackColor = Color.Red;

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
            if (currentRight == (int)nudCodeLength.Value)
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
        private void FillColor(Color color) {
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
        /// Termine la partie en cours et en recommence une
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tryCount+1; i++)
            {
                for (int j = 0; j < (int)nudCodeLength.Value; j++)
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
            for (int i = 0; i < (int)nudCodeLength.Value; i++)
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

        private void StartGame() {
            tlpGuess.ColumnCount = (int)nudCodeLength.Value;
            tlpGuess.RowCount = NB_TRIES;
            tlpGuess.Size = new Size((int)nudCodeLength.Value * (PBOX_SIZE + (2 * MARGIN_PBOX)), NB_TRIES * (PBOX_SIZE + (2 * MARGIN_PBOX)));

            for (int i = 0; i < NB_TRIES; i++)
            {
                for (int j = 0; j < (int)nudCodeLength.Value; j++)
                {
                    PictureBox newPBox = new PictureBox();
                    newPBox.BorderStyle = BorderStyle.FixedSingle;
                    newPBox.Size = new Size(PBOX_SIZE, PBOX_SIZE);
                    newPBox.Anchor = AnchorStyles.None;
                    tlpGuess.Controls.Add(newPBox, i, j);
                }
            }

            tlpFeedback.ColumnCount = (int)nudCodeLength.Value;
            tlpFeedback.RowCount = NB_TRIES;
            tlpFeedback.Size = new Size((int)nudCodeLength.Value * (FB_SIZE + (2 * MARGIN_PBOX)), NB_TRIES * (PBOX_SIZE + (2 * MARGIN_PBOX)));

            for (int i = 0; i < NB_TRIES; i++)
            {
                for (int j = 0; j < (int)nudCodeLength.Value; j++)
                {
                    PictureBox newPBox = new PictureBox();
                    newPBox.BorderStyle = BorderStyle.FixedSingle;
                    newPBox.Anchor = AnchorStyles.None;
                    newPBox.Size = new Size(FB_SIZE, FB_SIZE);
                    tlpFeedback.Controls.Add(newPBox, i, j); 
                }
            }




            RandomCode();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            StartGame();
            
            
        }

        private void nudCodeLength_ValueChanged(object sender, EventArgs e)
        {
            tlpGuess.Controls.Clear();
            tlpFeedback.Controls.Clear();
            StartGame();
        }
    }
}
