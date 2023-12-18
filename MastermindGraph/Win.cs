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
/// Date (Creation) : 18.12.2023
/// Description : Formulaire de victoire


namespace MastermindGraph
{
    public partial class Win : Form
    {
        public Win(Main game)
        {
            InitializeComponent();
            
            // grammaire pluriel
            if (game.tryCount == 1) {
                lblAttemps.Text = ("Congrats! You discovered the code in " + game.tryCount + " try.");
            }
            else
            {
                lblAttemps.Text = ("Congrats! You discovered the code in " + game.tryCount + " tries.");
            }
        }
    }
}
