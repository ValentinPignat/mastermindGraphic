namespace MastermindGraph
{
    partial class Loose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loose));
            this.lblLoose = new System.Windows.Forms.Label();
            this.pBoxHuh = new System.Windows.Forms.PictureBox();
            this.lblBetterLuck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxHuh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoose
            // 
            this.lblLoose.AutoSize = true;
            this.lblLoose.Font = new System.Drawing.Font("OCR A Extended", 40F, System.Drawing.FontStyle.Bold);
            this.lblLoose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoose.Location = new System.Drawing.Point(97, 117);
            this.lblLoose.Name = "lblLoose";
            this.lblLoose.Size = new System.Drawing.Size(297, 57);
            this.lblLoose.TabIndex = 0;
            this.lblLoose.Text = "Defeat !";
            this.lblLoose.UseMnemonic = false;
            // 
            // pBoxHuh
            // 
            this.pBoxHuh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxHuh.Image")));
            this.pBoxHuh.Location = new System.Drawing.Point(468, 24);
            this.pBoxHuh.Name = "pBoxHuh";
            this.pBoxHuh.Size = new System.Drawing.Size(306, 394);
            this.pBoxHuh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxHuh.TabIndex = 1;
            this.pBoxHuh.TabStop = false;
            // 
            // lblBetterLuck
            // 
            this.lblBetterLuck.AutoSize = true;
            this.lblBetterLuck.Font = new System.Drawing.Font("OCR A Extended", 20F);
            this.lblBetterLuck.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBetterLuck.Location = new System.Drawing.Point(41, 259);
            this.lblBetterLuck.Name = "lblBetterLuck";
            this.lblBetterLuck.Size = new System.Drawing.Size(397, 29);
            this.lblBetterLuck.TabIndex = 2;
            this.lblBetterLuck.Text = "Better luck next time :>";
            // 
            // Loose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBetterLuck);
            this.Controls.Add(this.pBoxHuh);
            this.Controls.Add(this.lblLoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loose";
            this.Text = "Defeat !";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxHuh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoose;
        private System.Windows.Forms.PictureBox pBoxHuh;
        private System.Windows.Forms.Label lblBetterLuck;
    }
}