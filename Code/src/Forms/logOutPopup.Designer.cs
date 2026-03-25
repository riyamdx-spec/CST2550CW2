namespace BettingSystem.Forms
{
    partial class logOutPopup
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
            messageLbl = new Label();
            confirmationBtnPanel = new TableLayoutPanel();
            leaveBtn = new RoundedButton();
            cancelBtn = new RoundedButton();
            popupLbl = new Label();
            panelBg.SuspendLayout();
            confirmationBtnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelBg
            // 
            panelBg.BackColor = Color.FromArgb(36, 36, 36);
            panelBg.Controls.Add(messageLbl);
            panelBg.Controls.Add(confirmationBtnPanel);
            panelBg.Controls.Add(popupLbl);
            panelBg.Dock = DockStyle.Fill;
            panelBg.Location = new Point(0, 0);
            panelBg.Name = "panelBg";
            panelBg.Padding = new Padding(5, 10, 5, 5);
            panelBg.Size = new Size(487, 184);
            panelBg.TabIndex = 0;
            // 
            // messageLbl
            // 
            messageLbl.Dock = DockStyle.Top;
            messageLbl.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLbl.ForeColor = Color.FromArgb(241, 241, 241);
            messageLbl.Location = new Point(5, 46);
            messageLbl.Name = "messageLbl";
            messageLbl.Size = new Size(477, 69);
            messageLbl.TabIndex = 5;
            messageLbl.Text = "All unpaid bets will be lost and cannot be recovered";
            messageLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirmationBtnPanel
            // 
            confirmationBtnPanel.ColumnCount = 2;
            confirmationBtnPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            confirmationBtnPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            confirmationBtnPanel.Controls.Add(leaveBtn, 1, 0);
            confirmationBtnPanel.Controls.Add(cancelBtn, 0, 0);
            confirmationBtnPanel.Dock = DockStyle.Bottom;
            confirmationBtnPanel.Location = new Point(5, 115);
            confirmationBtnPanel.Name = "confirmationBtnPanel";
            confirmationBtnPanel.RowCount = 1;
            confirmationBtnPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            confirmationBtnPanel.Size = new Size(477, 64);
            confirmationBtnPanel.TabIndex = 4;
            // 
            // leaveBtn
            // 
            leaveBtn.Anchor = AnchorStyles.None;
            leaveBtn.BackColor = Color.FromArgb(93, 185, 64);
            leaveBtn.CornerRadius = 12;
            leaveBtn.Cursor = Cursors.Hand;
            leaveBtn.FlatAppearance.BorderSize = 0;
            leaveBtn.FlatStyle = FlatStyle.Flat;
            leaveBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leaveBtn.ForeColor = Color.FromArgb(241, 241, 241);
            leaveBtn.Location = new Point(275, 10);
            leaveBtn.Name = "leaveBtn";
            leaveBtn.Size = new Size(165, 43);
            leaveBtn.TabIndex = 2;
            leaveBtn.TabStop = false;
            leaveBtn.Text = "Yes";
            leaveBtn.UseVisualStyleBackColor = false;
            leaveBtn.Click += leaveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.None;
            cancelBtn.BackColor = Color.FromArgb(241, 241, 241);
            cancelBtn.CornerRadius = 12;
            cancelBtn.Cursor = Cursors.Hand;
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(26, 26, 26);
            cancelBtn.Location = new Point(36, 10);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(165, 43);
            cancelBtn.TabIndex = 1;
            cancelBtn.TabStop = false;
            cancelBtn.Text = "No";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // popupLbl
            // 
            popupLbl.Dock = DockStyle.Top;
            popupLbl.Font = new Font("Times New Roman", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            popupLbl.ForeColor = Color.FromArgb(241, 241, 241);
            popupLbl.Location = new Point(5, 10);
            popupLbl.Name = "popupLbl";
            popupLbl.Size = new Size(477, 36);
            popupLbl.TabIndex = 0;
            popupLbl.Text = "Are you sure you want to leave?";
            popupLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logOutPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 184);
            Controls.Add(panelBg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "logOutPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "logOutForm";
            panelBg.ResumeLayout(false);
            confirmationBtnPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBg;
        private Label popupLbl;
        private TableLayoutPanel confirmationBtnPanel;
        private RoundedButton leaveBtn;
        private RoundedButton cancelBtn;
        private Label messageLbl;
    }
}