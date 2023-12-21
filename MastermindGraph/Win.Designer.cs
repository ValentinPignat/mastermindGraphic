namespace MastermindGraph
{
    partial class Win
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win));
            this.lblWin = new System.Windows.Forms.Label();
            this.pBoxChipiChapa = new System.Windows.Forms.PictureBox();
            this.lblAttemps = new System.Windows.Forms.Label();
            this.tmrGif = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxChipiChapa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Font = new System.Drawing.Font("OCR A Extended", 40F, System.Drawing.FontStyle.Bold);
            this.lblWin.Location = new System.Drawing.Point(224, 28);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(331, 57);
            this.lblWin.TabIndex = 0;
            this.lblWin.Text = "VICTORY !";
            // 
            // pBoxChipiChapa
            // 
            this.pBoxChipiChapa.Image = ((System.Drawing.Image)(resources.GetObject("pBoxChipiChapa.Image")));
            this.pBoxChipiChapa.InitialImage = null;
            this.pBoxChipiChapa.Location = new System.Drawing.Point(103, 158);
            this.pBoxChipiChapa.Name = "pBoxChipiChapa";
            this.pBoxChipiChapa.Size = new System.Drawing.Size(569, 280);
            this.pBoxChipiChapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxChipiChapa.TabIndex = 1;
            this.pBoxChipiChapa.TabStop = false;
            this.pBoxChipiChapa.Click += new System.EventHandler(this.pBoxChipiChapa_Click);
            // 
            // lblAttemps
            // 
            this.lblAttemps.AutoSize = true;
            this.lblAttemps.Font = new System.Drawing.Font("OCR A Extended", 20F);
            this.lblAttemps.Location = new System.Drawing.Point(33, 105);
            this.lblAttemps.Name = "lblAttemps";
            this.lblAttemps.Size = new System.Drawing.Size(733, 29);
            this.lblAttemps.TabIndex = 2;
            this.lblAttemps.Text = "Congrats! You discovered the code in 0 tries.";
            // 
            // tmrGif
            // 
            this.tmrGif.Enabled = true;
            this.tmrGif.Interval = 50;
            this.tmrGif.Tick += new System.EventHandler(this.tmrGif_Tick);
            // 
            // Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAttemps);
            this.Controls.Add(this.pBoxChipiChapa);
            this.Controls.Add(this.lblWin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Win";
            this.Text = "Victory !";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxChipiChapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.PictureBox pBoxChipiChapa;
        private System.Windows.Forms.Label lblAttemps;
        private System.Windows.Forms.Timer tmrGif;
    }
}