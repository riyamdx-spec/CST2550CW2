namespace BettingSystem.Forms.CustomControls
{
    partial class leagueButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LeagueBtnRoundedPanelBG = new RoundedPanel();
            leagueImg = new PictureBox();
            LeagueBtnRoundedPanelBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leagueImg).BeginInit();
            SuspendLayout();
            // 
            // LeagueBtnRoundedPanelBG
            // 
            LeagueBtnRoundedPanelBG.BackColor = Color.FromArgb(35, 255, 255, 255);
            LeagueBtnRoundedPanelBG.Controls.Add(leagueImg);
            LeagueBtnRoundedPanelBG.Dock = DockStyle.Fill;
            LeagueBtnRoundedPanelBG.Location = new Point(0, 0);
            LeagueBtnRoundedPanelBG.Name = "LeagueBtnRoundedPanelBG";
            LeagueBtnRoundedPanelBG.Padding = new Padding(10);
            LeagueBtnRoundedPanelBG.Size = new Size(102, 84);
            LeagueBtnRoundedPanelBG.TabIndex = 0;
            // 
            // leagueImg
            // 
            leagueImg.Dock = DockStyle.Fill;
            leagueImg.ErrorImage = null;
            leagueImg.InitialImage = null;
            leagueImg.Location = new Point(10, 10);
            leagueImg.Name = "leagueImg";
            leagueImg.Size = new Size(82, 64);
            leagueImg.SizeMode = PictureBoxSizeMode.Zoom;
            leagueImg.TabIndex = 0;
            leagueImg.TabStop = false;
            // 
            // leagueButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(LeagueBtnRoundedPanelBG);
            Name = "leagueButton";
            Size = new Size(102, 84);
            LeagueBtnRoundedPanelBG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leagueImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel LeagueBtnRoundedPanelBG;
        private PictureBox leagueImg;
    }
}
