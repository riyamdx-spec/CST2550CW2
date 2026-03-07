namespace BettingSystem
{
    partial class Notification
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
            mainPanel = new RoundedPanel();
            lblMessage = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(93, 185, 64);
            mainPanel.Controls.Add(lblMessage);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(350, 80);
            mainPanel.TabIndex = 0;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblMessage.Location = new Point(132, 24);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(86, 32);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Notification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(350, 80);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Notification";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NotificationPopup";
            TopMost = true;
            TransparencyKey = Color.MediumAquamarine;
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel mainPanel;
        private Label lblMessage;
    }
}