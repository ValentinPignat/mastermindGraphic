/// ETML
/// Author : Valentin Pignat
/// Date (Creation) : 18.12.2023
/// Description : Formulaire de victoire
/// Note : Les implémentations concernant l'affichage du Gif sont inutiles étant donné que Windows Forms gère les GIF

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
    public partial class Win : Form
    {

        // timer et frames
        int _timer = 0;
        Image[] _chipiFrames = { Properties.Resources.chipi_1, Properties.Resources.chipi_2, Properties.Resources.chipi_3, Properties.Resources.chipi_4, Properties.Resources.chipi_5, Properties.Resources.chipi_6, Properties.Resources.chipi_7, Properties.Resources.chipi_8, Properties.Resources.chipi_9, Properties.Resources.chipi_10, Properties.Resources.chipi_11, Properties.Resources.chipi_12, Properties.Resources.chipi_13, Properties.Resources.chipi_14, Properties.Resources.chipi_15, Properties.Resources.chipi_16, Properties.Resources.chipi_17, Properties.Resources.chipi_18, Properties.Resources.chipi_19, Properties.Resources.chipi_20, Properties.Resources.chipi_21, Properties.Resources.chipi_22, Properties.Resources.chipi_23, Properties.Resources.chipi_24, Properties.Resources.chipi_25, Properties.Resources.chipi_26, Properties.Resources.chipi_27, Properties.Resources.chipi_28, Properties.Resources.chipi_29, Properties.Resources.chipi_30, Properties.Resources.chipi_31, Properties.Resources.chipi_32, Properties.Resources.chipi_33, Properties.Resources.chipi_34, Properties.Resources.chipi_35, Properties.Resources.chipi_36 };
        
        /// <summary>
        /// Ecran de victoire
        /// </summary>
        /// <param name="tryCount">Nombre d'essai</param>
        public Win(int tryCount)
        {
            InitializeComponent();

            // grammaire pluriel
            if (tryCount == 1) {
                lblAttemps.Text = ("Congrats! You discovered the code in " + tryCount + " try.");
            }
            else
            {
                lblAttemps.Text = ("Congrats! You discovered the code in " + tryCount + " tries.");
            }
        }

        /// <summary>
        /// Afiche les différentes frames du GIF par intervalles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGif_Tick(object sender, EventArgs e)
        {
            pBoxChipiChapa.Image = _chipiFrames[_timer];
            
            _timer++;

            // boucle
            if (_timer == _chipiFrames.Length) { 
                _timer = 0;
            }
     
        }

        /// <summary>
        /// Permet de mettre en pause le GIF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBoxChipiChapa_Click(object sender, EventArgs e)
        {
            tmrGif.Enabled = !tmrGif.Enabled;
        }
    }
}
