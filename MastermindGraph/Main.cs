using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/// ETML
/// Author : Valentin Pignat
/// Date (Creation) : 16.11.2023
/// Description : Mastermind avec interface grapgique (Windows Forms) 
/// 
/// TODO:
/// 
/// Changement de langue
/// 
/// FEATURES:
/// mode facile
/// une seule couleur
/// palette de couleur 
/// 
/// NEXT UPDATE :
/// Nettoyage du code, réorganisation
/// Changer position selon longuer
/// Bouton pour voir le code
/// Bouton Règles

namespace MastermindGraph
{
    public partial class Main : Form
    {
        
        // Declaration constantes 
        const int NB_TRIES = 10;
        const int GUESS_SIZE = 40;
        const int MARGIN_PBOX = 3;
        const int FB_SIZE = 16;
        const int CODELENGTH_MAX = 6;
        const int CODELENGTH_MIN = 2;
        const int COLOR_POOL_SIZE_MAX = 7;
        const int COLOR_POOL_SIZE_MIN = 2;
        const int GUESS_CELL_SIZE = 2 * MARGIN_PBOX + GUESS_SIZE;
        const int FB_CELL_SIZE = 2 * MARGIN_PBOX + FB_SIZE;


        // Initialisation essais et tableau de couleur
        int colorPoolSize = 7;
        int tryCount = 0;
        int currentRight = 0;
        int currentWrongPlace = 0;
        int topTlpGuess = 0;
        int leftTlpGuess = 0;
        int topTlpFeedback = 0;
        int leftTlpFeedback = 0;
        int cellWidth = 0;
        bool[,] indexVerified = new bool[2, CODELENGTH_MAX];
        readonly Color[] COLOR_POOL_DEFAULT = { Color.Yellow, Color.Black, Color.Red, Color.Green, Color.DarkOrange, Color.Cyan, Color.Purple };
        Color[] secretCode = new Color[7];
        bool easyMode = false;
        bool uniqueColors = false;

        /// <summary>
        /// Main - Démarrage
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loading du Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            // Update la position des éléments
            topTlpGuess = tlpGuess.Top;
            leftTlpGuess = tlpGuess.Left;
            topTlpFeedback = tlpFeedback.Top;
            leftTlpFeedback = tlpFeedback.Left;
            StartGame();  
        }

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
        /// Remplit la première case vide de la ligne avec la couleur choisie
        /// </summary>
        /// <param name="color"></param>
        private void FillColor(Color color)
        {
            // Empêche changement des paramètres une fois la partie lancée et permet de clear
            pnlParam.Enabled = false;
            btnClear.Enabled = true;

            // Change la couleur dans la première case vide 
            for (int i = 0; i < nudCodeLength.Value; i++)
            {
                if (tlpGuess.GetControlFromPosition(i, tryCount).BackColor == Control.DefaultBackColor)
                {
                    tlpGuess.GetControlFromPosition(i, tryCount).BackColor = color;

                    // Submit actif quand la ligne est remplie
                    if (i == nudCodeLength.Value - 1)
                    {
                        btnSubmit.Enabled = true;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Soumet l'essai à la vérification et passe à la ligne suivante 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Reset 
            currentRight = 0;
            currentWrongPlace = 0;

            // Tableau à deux dimension pour verifier les paires trouvé dans l'essai / code
            indexVerified = new bool[2, CODELENGTH_MAX];
            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {

                // Si la couleur est bien placée
                if (tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[i])
                {
                    // Feedback 
                    tlpFeedback.GetControlFromPosition(currentRight, tryCount).BackColor = Color.White;

                    // Evite de reverifier comme mal placés
                    indexVerified[0, i] = true;
                    indexVerified[1, i] = true;

                    // Juste +1
                    currentRight++;

                }
            }

            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {

                // Si juste mais pas bien placée
                if (!indexVerified[0, i])
                {
                    for (int j = 0; j < (int)nudCodeLength.Value; j++)
                    {

                        // Si pas deja validé dans le code secret 
                        if (!indexVerified[1, j] && tlpGuess.GetControlFromPosition(i, tryCount).BackColor == secretCode[j])
                        {

                            // Feedback 
                            tlpFeedback.GetControlFromPosition(currentRight + currentWrongPlace, tryCount).BackColor = Color.Black;

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

            // Essai ++
            tryCount++;

            // Victoire -> résultats / message de fin 
            if (currentRight == (int)nudCodeLength.Value)
            {
                MessageBox.Show("\nBravo!\nVous avez découvert le code en " + (tryCount) + " essais.\n");
                EndSpectate();
            }

            // Défaite -> résultats / message de fin 
            if (tryCount == 10)
            {
                
                MessageBox.Show("Vous avez perdu :<\n");

                EndSpectate();
            }
            EmptyLine();
        }

        /// <summary>
        /// Désactive Submit/Clear 
        /// </summary>
        private void EmptyLine() { 
            btnSubmit.Enabled = false;
            btnClear.Enabled = false;
        }

        /// <summary>
        /// Efface la ligne en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            
            // Efface la ligne en cours
            for (int i = 0; i < nudCodeLength.Value; i++)
            {
                tlpGuess.GetControlFromPosition(i, tryCount).BackColor = Control.DefaultBackColor;
                tlpFeedback.GetControlFromPosition(i, tryCount).BackColor = Color.LightSlateGray;
                
            }
            
            // Grille vide -> Paramètres accesibles
            if (tryCount == 0) {
                pnlParam.Enabled = true;
            }
            EmptyLine();
        }

        /// <summary>
        /// Termine la partie en cours et en recommence une
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {

            // Réactive les boutons de couleur 
            foreach (PictureBox picBox in pnlColor.Controls.OfType<PictureBox>())
            {
                picBox.Enabled = true;
            }

            // Commence une nouvelle partie
            StartGame();

            // Retablissement des controles pour le début de partie
            foreach (PictureBox picBox in this.Controls.OfType<PictureBox>())
            {
                picBox.Enabled = Enabled;
            }
            btnRestart.BackColor = DefaultBackColor;
            btnClear.Enabled = false;
            pnlParam.Enabled = true;

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
                secretCode[i] = COLOR_POOL_DEFAULT[x];
                
                // TEST
                // tlpGuess.GetControlFromPosition(i, 9).BackColor = secretCode[i];
            }
        }

        /// <summary>
        /// Garde la partie ouverte et seul le bouton restart actif 
        /// </summary>
        private void EndSpectate() {
            foreach (PictureBox picBox in pnlColor.Controls.OfType<PictureBox>()) {
                picBox.Enabled = false;
            }
            btnClear.Enabled = false;
            btnRestart.BackColor = Color.LightSteelBlue;
            pnlCode.Visible = true;
        }

        /// <summary>
        /// Crée une partie, génére grille et code
        /// </summary>
        private void StartGame() {

            // Efface le contenu précédent
            tlpGuess.Controls.Clear();
            tlpFeedback.Controls.Clear();

            // Modification des deux tableaux, recréations des labels
            TlpBuild(tlpFeedback, FB_SIZE, topTlpFeedback, leftTlpFeedback, NB_TRIES);
            TlpBuild(tlpGuess, GUESS_SIZE, topTlpGuess, leftTlpGuess, NB_TRIES);
            
            // Crée un code aléatoire et essai à 0
            tryCount = 0;
            RandomCode();

            // Affichage du code secret
            for (int i = 0;i<CODELENGTH_MAX; i++) 
            {
                if (i < (int)nudCodeLength.Value)
                {
                    tlpCode.GetControlFromPosition(i, 0).BackColor = secretCode[i];
                }
                else 
                {
                    tlpCode.GetControlFromPosition(i, 0).BackColor = SystemColors.ActiveCaption;
                }
            }

            // Le rend invisible 
            pnlCode.Visible = false;
            
        }

        /// <summary>
        /// Change la taille de la grille 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCodeLength_ValueChanged(object sender, EventArgs e)
        {

            // Recrée un tableau
            StartGame();
        }

        /// <summary>
        /// Change nombre de colonne et lignes d'un Table Layout Pannel et recrée les labels
        /// </summary>
        private void TlpBuild(TableLayoutPanel tlp, int pBoxSize, int top, int left, int rows) 
        {

            // Change nombre de colonne et taille selon les options 
            tlp.ColumnCount = (int)nudCodeLength.Value;
            tlp.RowCount = rows;

            // Taille du décalage selon le Tlp
            if (tlp == tlpGuess)
            {

                // Une cellule de Guess + Une cellule de Feedback
                cellWidth = GUESS_CELL_SIZE + FB_CELL_SIZE;
            }
            else {

                // Une cellule de Feedback
                cellWidth = FB_CELL_SIZE;
            }

            // Change largeur hauteur et position
            tlp.Size = new Size((int)nudCodeLength.Value * (pBoxSize + (2 * MARGIN_PBOX)), rows * (GUESS_CELL_SIZE));
            tlp.Location = new Point(left + (cellWidth * (CODELENGTH_MAX - (int)nudCodeLength.Value)), top);
            

            // Boucle pour remplir les cases avec les labels
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < (int)nudCodeLength.Value; j++)
                {

                    // Changement du style des labels
                    PictureBox newPBox = new PictureBox();
                    newPBox.BorderStyle = BorderStyle.FixedSingle;
                    newPBox.Size = new Size(pBoxSize, pBoxSize);
                    newPBox.Anchor = AnchorStyles.None;

                    // Par defaut la couleur se calque sur le backcolor du Main
                    if (tlp == tlpGuess)
                    {
                        newPBox.BackColor = DefaultBackColor;
                    }
                    else 
                    {
                        newPBox.BackColor = Color.LightSlateGray;
                    }

                    // Ajout dans les différentes cases
                    tlp.Controls.Add(newPBox, i, j);
                }
            }
        }

        /// <summary>
        /// Change nombre de couleur disponible pour le code 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudColorPoolSize_ValueChanged(object sender, EventArgs e)
        {
            
            // Change nombre de couleur 
            colorPoolSize = (int)nudColorPoolSize.Value;

            // Désactive/Réactive les boutons //https://stackoverflow.com/questions/19775851/ability-to-find-winform-control-via-the-tag-property     
            for (int i = COLOR_POOL_SIZE_MIN; i < COLOR_POOL_SIZE_MAX; i++)
            {
                
                foreach (PictureBox c in pnlColor.Controls)
                {
                    // Trouve bouton selon les couleurs
                    if (c.BackColor == COLOR_POOL_DEFAULT[i]) {

                        // Si plus haut que nombre de couleurs -> Disabled et hachuré
                        if (i >= colorPoolSize) {
                            c.Enabled = false;
                            c.Image = MastermindGraph.Properties.Resources.crossed;
                        }

                        // Si plus bas -> Enabled
                        else
                        {
                            c.Enabled = true;
                            c.Image = null;
                        }  
                    }      
                }
            }
            

            // Recommence une partie
            StartGame();
            
        }

        /// <summary>
        /// Montre / Cache le code secret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCode_Click(object sender, EventArgs e)
        {
            pnlCode.Visible = !pnlCode.Visible;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mastermind rules:\n\n" +
                "Try to guess the secret code by trying color sequences.\n\n" +
                "On the right you will receive feedback after each try:\n" +
                "   - Black: One of your colors is well placed\n" +
                "   - White: One of your colors is present in the code but not where you placed it\n\n" +
                "On easy mode the indicators are on the corresponding square where in normal mode their placement don't mean anything.")
                ;
        }

        /// <summary>
        /// Active/Desactive Easy Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxEasy_CheckedChanged(object sender, EventArgs e)
        {
            easyMode = !easyMode;
        }

        /// <summary>
        /// Active/Desactive couleurs uniques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxUnique_CheckedChanged(object sender, EventArgs e)
        {
            uniqueColors = !uniqueColors;
        }
    }
}
