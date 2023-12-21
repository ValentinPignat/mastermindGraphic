using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;



/// ETML
/// Author : Valentin Pignat
/// Date (Creation) : 16.11.2023
/// Description : Mastermind avec interface grapgique (Windows Forms) 
/// GitHub : https://github.com/ValentinPignat/mastermindGraphic
/// 
/// TODO:
/// Position "absolue" ew
/// 
/// FEATURES:
/// 
/// NEXT GIT :
/// 
/// Form instead of messagebox (Rules, Victory, Defeat)
/// Correction du code


namespace MastermindGraph
{
    public partial class Main : Form
    {

        #region Initialisations

        // Initialisation constantes 
        const int NB_TRIES = 10;
        const int CODELENGTH_MAX = 6;
        const int CODELENGTH_MIN = 2;
        const int COLOR_POOL_SIZE_MAX = 7;
        const int COLOR_POOL_SIZE_MIN = 2;
        
        // Constantes dimensions
        const int GUESS_SIZE = 40;
        const int MARGIN_PBOX = 3;
        const int FB_SIZE = 16;
        const int GUESS_CELL_SIZE = 2 * MARGIN_PBOX + GUESS_SIZE;
        const int FB_CELL_SIZE = 2 * MARGIN_PBOX + FB_SIZE;


        // Variables initialisations
        int _colorPoolSize = 7;
        int _tryCount = 0;
        int _currentRight = 0;
        int _currentWrongPlace = 0;
        int _topTlpGuess = 0;
        int _leftTlpGuess = 0;
        int _topTlpFeedback = 0;
        int _leftTlpFeedback = 0;
        int _cellWidth = 0;
        bool[,] _indexVerified = new bool[2, CODELENGTH_MAX];
        Color[] _secretCode = new Color[7];
        bool[] _unusedColors = new bool[7];
        PictureBox[] _colorPbox = new PictureBox[7];

        // Thèmes
        static readonly Color[] COLOR_POOL_FORMS = { 
            Color.Yellow, 
            Color.Black, 
            Color.Red, 
            Color.Green, 
            Color.DarkOrange, 
            Color.Cyan, 
            Color.Purple };
        static readonly Color[] COLOR_POOL_COLORBLIND = { 
            ColorTranslator.FromHtml("#332288") , 
            ColorTranslator.FromHtml("#117733") , 
            ColorTranslator.FromHtml("#44AA99") , 
            ColorTranslator.FromHtml("#88CCEE") , 
            ColorTranslator.FromHtml("#DDCC77") , 
            ColorTranslator.FromHtml("#AA4499") , 
            ColorTranslator.FromHtml("#882255") };
        static readonly Color[] COLOR_POOL_PASTEL = { 
            ColorTranslator.FromHtml("#ffadad"),
            ColorTranslator.FromHtml("#ffd6a5"), 
            ColorTranslator.FromHtml("#fdffb6"), 
            ColorTranslator.FromHtml("#caffbf"), 
            ColorTranslator.FromHtml("#9bf6ff"),
            ColorTranslator.FromHtml("#a0c4ff"), 
            ColorTranslator.FromHtml("#ffc6ff") };

        // Thèmes par défaut 
        Color[] _activeColorPool = COLOR_POOL_COLORBLIND;
        #endregion

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
            _topTlpGuess = tlpGuess.Top;
            _leftTlpGuess = tlpGuess.Left;
            _topTlpFeedback = tlpFeedback.Top;
            _leftTlpFeedback = tlpFeedback.Left;

            // Place les boutons de couleur dans un tableau
            _colorPbox[0] = pBoxYellow;
            _colorPbox[1] = pBoxBlack;
            _colorPbox[2] = pBoxRed;
            _colorPbox[3] = pBoxGreen;
            _colorPbox[4] = pBoxOrange;
            _colorPbox[5] = pBoxCyan;
            _colorPbox[6] = pBoxPurple;
            

            // Palette de couleur par defaut
            cmbBoxColorPalette.SelectedIndex = 1;

            // Changement de couleur du Titre
            lblMastermind.ForeColor = ColorTranslator.FromHtml("#2c4875");

            // Commence une partie 
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
                if (tlpGuess.GetControlFromPosition(i, _tryCount).BackColor == Control.DefaultBackColor)
                {
                    tlpGuess.GetControlFromPosition(i, _tryCount).BackColor = color;

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
            _currentRight = 0;
            _currentWrongPlace = 0;

            // Tableau à deux dimension pour verifier les paires trouvé dans l'essai / code
            _indexVerified = new bool[2, CODELENGTH_MAX];
            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {

                // Si la couleur est bien placée
                if (tlpGuess.GetControlFromPosition(i, _tryCount).BackColor == _secretCode[i])
                {
                    // Feedback Facile
                    if (cBoxEasy.Checked) {
                        tlpFeedback.GetControlFromPosition(i, _tryCount).BackColor = Color.White;
                    }

                    // Feedback Normal
                    else
                    {
                        tlpFeedback.GetControlFromPosition(_currentRight, _tryCount).BackColor = Color.White;
                    }

                    // Evite de reverifier comme mal placés
                    _indexVerified[0, i] = true;
                    _indexVerified[1, i] = true;

                    // Juste +1
                    _currentRight++;

                }
            }

            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {

                // Si juste mais pas bien placée
                if (!_indexVerified[0, i])
                {
                    for (int j = 0; j < (int)nudCodeLength.Value; j++)
                    {

                        // Si pas deja validé dans le code secret 
                        if (!_indexVerified[1, j] && tlpGuess.GetControlFromPosition(i, _tryCount).BackColor == _secretCode[j])
                        {

                            // Feedback Facile
                            if (cBoxEasy.Checked)
                            {
                                tlpFeedback.GetControlFromPosition(i, _tryCount).BackColor = Color.Black;
                            }

                            // Feedback Normal
                            else
                            {
                                tlpFeedback.GetControlFromPosition(_currentRight + _currentWrongPlace, _tryCount).BackColor = Color.Black;
                            }
                            

                            // Evite doublons
                            _indexVerified[0, i] = true;
                            _indexVerified[1, j] = true;

                            // Juste +1
                            _currentWrongPlace++;

                            break;
                        }
                    }
                }
            }

            // Essai ++
            _tryCount++;

            // Victoire -> résultats / message de fin 
            if (_currentRight == (int)nudCodeLength.Value)
            {
                Win form = new Win(_tryCount);
                form.ShowDialog();
                EndSpectate();
            }

            // Défaite -> résultats / message de fin 
            if (_tryCount == 10)
            {

                Loose form = new Loose();
                form.ShowDialog();
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
                tlpGuess.GetControlFromPosition(i, _tryCount).BackColor = Control.DefaultBackColor;
                tlpFeedback.GetControlFromPosition(i, _tryCount).BackColor = Color.LightSlateGray;
                
            }
            
            // Grille vide -> Paramètres accesibles
            if (_tryCount == 0) {
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
                int x = rnd.Next(0, _colorPoolSize);
                _secretCode[i] = _activeColorPool[x];
            }
        }

        /// <summary>
        /// Crée un code secret, sans doublons, selon la longueur et le nombre de couleur 
        /// </summary>
        private void RandomUniqueCode()
        {
            // Tableau couleur déja utilisée
            _unusedColors = new bool[7];


            // Generer Code aléatoire (index aléatoire dans colorPool)
            Random rnd = new Random();
            for (int i = 0; i < (int)nudCodeLength.Value; i++)
            {
                int x = rnd.Next(0, _colorPoolSize);

                // Si la couleur n'est pas encore utilisée
                if (_unusedColors[x] == false) { 
                    _secretCode[i] = _activeColorPool[x];
                    _unusedColors[x] = true;
                }

                // Si pas ajoutée décremente 
                else
                {
                    i--;
                }
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
            TlpBuild(tlpFeedback, FB_SIZE, _topTlpFeedback, _leftTlpFeedback, NB_TRIES);
            TlpBuild(tlpGuess, GUESS_SIZE, _topTlpGuess, _leftTlpGuess, NB_TRIES);
            
            // Crée un code aléatoire et essai à 0
            _tryCount = 0;

            // Code sans doublons
            if (cBoxUnique.Checked)
            {
                RandomUniqueCode();
            }

            // Code normal
            else
            {
                RandomCode();
            }

            // Affichage du code secret
            for (int i = 0;i<CODELENGTH_MAX; i++) 
            {
                if (i < (int)nudCodeLength.Value)
                {
                    tlpCode.GetControlFromPosition(i, 0).BackColor = _secretCode[i];
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
            
            // Vérifie possible conflit avec le mode unique
            CheckUnique();
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
                _cellWidth = GUESS_CELL_SIZE + FB_CELL_SIZE;
            }
            else {

                // Une cellule de Feedback
                _cellWidth = FB_CELL_SIZE;
            }

            // Change largeur hauteur et position
            tlp.Size = new Size((int)nudCodeLength.Value * (pBoxSize + (2 * MARGIN_PBOX)), rows * (GUESS_CELL_SIZE));
            tlp.Location = new Point(left + (_cellWidth * (CODELENGTH_MAX - (int)nudCodeLength.Value)), top);
            

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
            _colorPoolSize = (int)nudColorPoolSize.Value;

            // Désactive/Réactive les boutons //https://stackoverflow.com/questions/19775851/ability-to-find-winform-control-via-the-tag-property     
            for (int i = COLOR_POOL_SIZE_MIN; i < COLOR_POOL_SIZE_MAX; i++)
            {
                
                foreach (PictureBox c in pnlColor.Controls)
                {
                    // Trouve bouton selon les couleurs
                    if (c.BackColor == _activeColorPool[i]) {

                        // Si plus haut que nombre de couleurs -> Disabled et hachuré
                        if (i >= _colorPoolSize) {
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

            // Verifie possible conflit avec le mode unique
            CheckUnique();

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

        /// <summary>
        /// Ouvre une page avec les règles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRules_Click(object sender, EventArgs e)
        {
            Rules form = new Rules();
            form.ShowDialog();
        }

        /// <summary>
        /// Active/Desactive couleurs uniques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxUnique.Checked)
            {

                // Empêche l'activation du code si le code est plus long que le nombre de couleur
                CheckUnique();
            }

            // Relance une nouvelle partie avec les nouveaux paramètres
            StartGame();

        }

        /// <summary>
        /// Vérifie conflit entre le mode unique et la longueur du code / nombre de couleur
        /// </summary>
        private void CheckUnique() {
            if ((int)nudCodeLength.Value > (int)nudColorPoolSize.Value && cBoxUnique.Checked)
            {
                cBoxUnique.Checked = false;
                MessageBox.Show("Unique mode has been disable because the code is too long for the number of color");
            }

        }

        /// <summary>
        /// Change la palette de couleurs selon la selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBoxColorPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change la palette de couleur active selon la selection
            switch (cmbBoxColorPalette.SelectedIndex) {

                case 0:
                    _activeColorPool = COLOR_POOL_FORMS;
                    break;
                case 2:
                    _activeColorPool = COLOR_POOL_PASTEL;
                    break;
                default:
                    _activeColorPool = COLOR_POOL_COLORBLIND;
                    break;
            }

            // Actualise la palette de couleur 
            for (int i = 0; i < COLOR_POOL_SIZE_MAX; i++) {
                _colorPbox[i].BackColor = _activeColorPool[i];
            }

            // Relance une partie avec les nouveaux paramètres
            StartGame();
        }
    }
}
