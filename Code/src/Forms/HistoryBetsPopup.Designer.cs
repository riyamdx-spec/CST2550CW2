namespace BettingSystem.Forms
{
    partial class HistoryBetsPopup
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
            panelBg = new Panel();
            betsFlowLayoutPanel = new FlowLayoutPanel();
            betsPopupLbl = new Label();
            panelBg.SuspendLayout();
            SuspendLayout();
            // 
            // panelBg
            // 
            panelBg.BackColor = Color.FromArgb(36, 36, 36);
            panelBg.Controls.Add(betsFlowLayoutPanel);
            panelBg.Controls.Add(betsPopupLbl);
            panelBg.Dock = DockStyle.Fill;
            panelBg.Location = new Point(0, 0);
            panelBg.Name = "panelBg";
            panelBg.Size = new Size(832, 545);
            panelBg.TabIndex = 0;
            // 
            // betsFlowLayoutPanel
            // 
            betsFlowLayoutPanel.AutoScroll = true;
            betsFlowLayoutPanel.Dock = DockStyle.Fill;
            betsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            betsFlowLayoutPanel.Location = new Point(0, 57);
            betsFlowLayoutPanel.Name = "betsFlowLayoutPanel";
            betsFlowLayoutPanel.Padding = new Padding(15, 10, 15, 10);
            betsFlowLayoutPanel.Size = new Size(832, 488);
            betsFlowLayoutPanel.TabIndex = 4;
            // 
            // betsPopupLbl
            // 
            betsPopupLbl.BackColor = Color.Transparent;
            betsPopupLbl.Dock = DockStyle.Top;
            betsPopupLbl.Font = new Font("Times New Roman", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            betsPopupLbl.ForeColor = Color.FromArgb(241, 241, 241);
            betsPopupLbl.Location = new Point(0, 0);
            betsPopupLbl.Name = "betsPopupLbl";
            betsPopupLbl.Padding = new Padding(0, 10, 0, 0);
            betsPopupLbl.Size = new Size(832, 57);
            betsPopupLbl.TabIndex = 3;
            betsPopupLbl.Text = "Bets";
            betsPopupLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HistoryBetsPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 545);
            Controls.Add(panelBg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HistoryBetsPopup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "HistoryBetsPopup";
            panelBg.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBg;
        private Label betsPopupLbl;
        private FlowLayoutPanel betsFlowLayoutPanel;
        private Label label1;
    }
}