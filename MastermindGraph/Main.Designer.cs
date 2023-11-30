namespace MastermindGraph
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBoxWhite = new System.Windows.Forms.PictureBox();
            this.pBoxPurple = new System.Windows.Forms.PictureBox();
            this.pBoxCyan = new System.Windows.Forms.PictureBox();
            this.pBoxBlack = new System.Windows.Forms.PictureBox();
            this.pBoxRed = new System.Windows.Forms.PictureBox();
            this.pBoxGreen = new System.Windows.Forms.PictureBox();
            this.pBoxYellow = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCodeLength = new System.Windows.Forms.Label();
            this.nudCodeLength = new System.Windows.Forms.NumericUpDown();
            this.lblColorPoolSize = new System.Windows.Forms.Label();
            this.nudColorPoolSize = new System.Windows.Forms.NumericUpDown();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblMastermind = new System.Windows.Forms.Label();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.pnlGameControl = new System.Windows.Forms.Panel();
            this.pnlParam = new System.Windows.Forms.Panel();
            this.tlpGuess = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFeedback = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPurple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCyan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodeLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorPoolSize)).BeginInit();
            this.pnlColor.SuspendLayout();
            this.pnlGameControl.SuspendLayout();
            this.pnlParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxWhite
            // 
            this.pBoxWhite.BackColor = System.Drawing.Color.DarkOrange;
            this.pBoxWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxWhite.Location = new System.Drawing.Point(35, 46);
            this.pBoxWhite.Name = "pBoxWhite";
            this.pBoxWhite.Size = new System.Drawing.Size(34, 34);
            this.pBoxWhite.TabIndex = 87;
            this.pBoxWhite.TabStop = false;
            this.pBoxWhite.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxPurple
            // 
            this.pBoxPurple.BackColor = System.Drawing.Color.Purple;
            this.pBoxPurple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxPurple.Location = new System.Drawing.Point(115, 46);
            this.pBoxPurple.Name = "pBoxPurple";
            this.pBoxPurple.Size = new System.Drawing.Size(34, 34);
            this.pBoxPurple.TabIndex = 86;
            this.pBoxPurple.TabStop = false;
            this.pBoxPurple.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxCyan
            // 
            this.pBoxCyan.BackColor = System.Drawing.Color.Cyan;
            this.pBoxCyan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxCyan.Location = new System.Drawing.Point(75, 46);
            this.pBoxCyan.Name = "pBoxCyan";
            this.pBoxCyan.Size = new System.Drawing.Size(34, 34);
            this.pBoxCyan.TabIndex = 84;
            this.pBoxCyan.TabStop = false;
            this.pBoxCyan.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxBlack
            // 
            this.pBoxBlack.BackColor = System.Drawing.Color.Black;
            this.pBoxBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxBlack.Location = new System.Drawing.Point(54, 7);
            this.pBoxBlack.Name = "pBoxBlack";
            this.pBoxBlack.Size = new System.Drawing.Size(34, 34);
            this.pBoxBlack.TabIndex = 91;
            this.pBoxBlack.TabStop = false;
            this.pBoxBlack.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxRed
            // 
            this.pBoxRed.BackColor = System.Drawing.Color.Red;
            this.pBoxRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxRed.Location = new System.Drawing.Point(94, 7);
            this.pBoxRed.Name = "pBoxRed";
            this.pBoxRed.Size = new System.Drawing.Size(34, 34);
            this.pBoxRed.TabIndex = 90;
            this.pBoxRed.TabStop = false;
            this.pBoxRed.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxGreen
            // 
            this.pBoxGreen.BackColor = System.Drawing.Color.Green;
            this.pBoxGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxGreen.Location = new System.Drawing.Point(134, 7);
            this.pBoxGreen.Name = "pBoxGreen";
            this.pBoxGreen.Size = new System.Drawing.Size(34, 34);
            this.pBoxGreen.TabIndex = 89;
            this.pBoxGreen.TabStop = false;
            this.pBoxGreen.Click += new System.EventHandler(this.ColorSelect);
            // 
            // pBoxYellow
            // 
            this.pBoxYellow.BackColor = System.Drawing.Color.Yellow;
            this.pBoxYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxYellow.Location = new System.Drawing.Point(14, 7);
            this.pBoxYellow.Name = "pBoxYellow";
            this.pBoxYellow.Size = new System.Drawing.Size(34, 34);
            this.pBoxYellow.TabIndex = 88;
            this.pBoxYellow.TabStop = false;
            this.pBoxYellow.Click += new System.EventHandler(this.ColorSelect);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(16, 19);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(115, 39);
            this.btnSubmit.TabIndex = 102;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(16, 65);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 38);
            this.btnClear.TabIndex = 103;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCodeLength
            // 
            this.lblCodeLength.AutoSize = true;
            this.lblCodeLength.Location = new System.Drawing.Point(13, 9);
            this.lblCodeLength.Name = "lblCodeLength";
            this.lblCodeLength.Size = new System.Drawing.Size(68, 13);
            this.lblCodeLength.TabIndex = 104;
            this.lblCodeLength.Text = "Code Length";
            // 
            // nudCodeLength
            // 
            this.nudCodeLength.Location = new System.Drawing.Point(133, 7);
            this.nudCodeLength.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudCodeLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCodeLength.Name = "nudCodeLength";
            this.nudCodeLength.Size = new System.Drawing.Size(34, 20);
            this.nudCodeLength.TabIndex = 105;
            this.nudCodeLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudCodeLength.ValueChanged += new System.EventHandler(this.nudCodeLength_ValueChanged);
            // 
            // lblColorPoolSize
            // 
            this.lblColorPoolSize.AutoSize = true;
            this.lblColorPoolSize.Location = new System.Drawing.Point(13, 46);
            this.lblColorPoolSize.Name = "lblColorPoolSize";
            this.lblColorPoolSize.Size = new System.Drawing.Size(87, 13);
            this.lblColorPoolSize.TabIndex = 106;
            this.lblColorPoolSize.Text = "Number of colors";
            // 
            // nudColorPoolSize
            // 
            this.nudColorPoolSize.Location = new System.Drawing.Point(133, 46);
            this.nudColorPoolSize.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudColorPoolSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudColorPoolSize.Name = "nudColorPoolSize";
            this.nudColorPoolSize.Size = new System.Drawing.Size(34, 20);
            this.nudColorPoolSize.TabIndex = 107;
            this.nudColorPoolSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(16, 119);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(115, 35);
            this.btnRestart.TabIndex = 108;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblMastermind
            // 
            this.lblMastermind.AutoSize = true;
            this.lblMastermind.Font = new System.Drawing.Font("Impact", 40.25F);
            this.lblMastermind.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMastermind.Location = new System.Drawing.Point(401, 9);
            this.lblMastermind.Name = "lblMastermind";
            this.lblMastermind.Size = new System.Drawing.Size(295, 66);
            this.lblMastermind.TabIndex = 109;
            this.lblMastermind.Text = "Mastermind";
            // 
            // pnlColor
            // 
            this.pnlColor.Controls.Add(this.pBoxBlack);
            this.pnlColor.Controls.Add(this.pBoxRed);
            this.pnlColor.Controls.Add(this.pBoxGreen);
            this.pnlColor.Controls.Add(this.pBoxYellow);
            this.pnlColor.Controls.Add(this.pBoxWhite);
            this.pnlColor.Controls.Add(this.pBoxPurple);
            this.pnlColor.Controls.Add(this.pBoxCyan);
            this.pnlColor.Location = new System.Drawing.Point(641, 100);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(193, 88);
            this.pnlColor.TabIndex = 110;
            // 
            // pnlGameControl
            // 
            this.pnlGameControl.Controls.Add(this.btnRestart);
            this.pnlGameControl.Controls.Add(this.btnClear);
            this.pnlGameControl.Controls.Add(this.btnSubmit);
            this.pnlGameControl.Location = new System.Drawing.Point(674, 200);
            this.pnlGameControl.Name = "pnlGameControl";
            this.pnlGameControl.Size = new System.Drawing.Size(148, 176);
            this.pnlGameControl.TabIndex = 112;
            // 
            // pnlParam
            // 
            this.pnlParam.Controls.Add(this.nudColorPoolSize);
            this.pnlParam.Controls.Add(this.lblColorPoolSize);
            this.pnlParam.Controls.Add(this.nudCodeLength);
            this.pnlParam.Controls.Add(this.lblCodeLength);
            this.pnlParam.Location = new System.Drawing.Point(641, 398);
            this.pnlParam.Name = "pnlParam";
            this.pnlParam.Size = new System.Drawing.Size(193, 71);
            this.pnlParam.TabIndex = 113;
            // 
            // tlpGuess
            // 
            this.tlpGuess.ColumnCount = 6;
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpGuess.Location = new System.Drawing.Point(226, 100);
            this.tlpGuess.Name = "tlpGuess";
            this.tlpGuess.RowCount = 10;
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpGuess.Size = new System.Drawing.Size(205, 369);
            this.tlpGuess.TabIndex = 114;
            // 
            // tlpFeedback
            // 
            this.tlpFeedback.ColumnCount = 6;
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFeedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFeedback.Location = new System.Drawing.Point(503, 100);
            this.tlpFeedback.Margin = new System.Windows.Forms.Padding(14);
            this.tlpFeedback.Name = "tlpFeedback";
            this.tlpFeedback.RowCount = 10;
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFeedback.Size = new System.Drawing.Size(99, 369);
            this.tlpFeedback.TabIndex = 115;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 662);
            this.Controls.Add(this.tlpFeedback);
            this.Controls.Add(this.tlpGuess);
            this.Controls.Add(this.pnlParam);
            this.Controls.Add(this.pnlGameControl);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.lblMastermind);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPurple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCyan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodeLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorPoolSize)).EndInit();
            this.pnlColor.ResumeLayout(false);
            this.pnlGameControl.ResumeLayout(false);
            this.pnlParam.ResumeLayout(false);
            this.pnlParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pBoxWhite;
        private System.Windows.Forms.PictureBox pBoxPurple;
        private System.Windows.Forms.PictureBox pBoxCyan;
        private System.Windows.Forms.PictureBox pBoxBlack;
        private System.Windows.Forms.PictureBox pBoxRed;
        private System.Windows.Forms.PictureBox pBoxGreen;
        private System.Windows.Forms.PictureBox pBoxYellow;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCodeLength;
        private System.Windows.Forms.NumericUpDown nudCodeLength;
        private System.Windows.Forms.Label lblColorPoolSize;
        private System.Windows.Forms.NumericUpDown nudColorPoolSize;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblMastermind;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Panel pnlGameControl;
        private System.Windows.Forms.Panel pnlParam;
        private System.Windows.Forms.TableLayoutPanel tlpGuess;
        private System.Windows.Forms.TableLayoutPanel tlpFeedback;
    }
}

