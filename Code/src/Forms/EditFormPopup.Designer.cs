namespace BettingSystem.Forms
{
    partial class EditFormPopup
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
            editFormBgPanel = new Panel();
            errorMsg = new Label();
            ConfirmationBtntableLayoutPanel = new TableLayoutPanel();
            confirmEditBtn = new RoundedButton();
            cancelBtn = new RoundedButton();
            emailErrorMsg = new Label();
            refreshBtn = new PictureBox();
            emailPassword = new Panel();
            emailTextbox = new UnderlineTextBox();
            emailLbl = new Label();
            lNameErrorMsg = new Label();
            lNamePanel = new Panel();
            lNameTextbox = new UnderlineTextBox();
            lNameLbl = new Label();
            fNameErrorMsg = new Label();
            fNamePanel = new Panel();
            fNameTextbox = new UnderlineTextBox();
            fNameLbl = new Label();
            editPopupLbl = new Label();
            editFormBgPanel.SuspendLayout();
            ConfirmationBtntableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)refreshBtn).BeginInit();
            emailPassword.SuspendLayout();
            lNamePanel.SuspendLayout();
            fNamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // editFormBgPanel
            // 
            editFormBgPanel.BackColor = Color.FromArgb(36, 36, 36);
            editFormBgPanel.Controls.Add(errorMsg);
            editFormBgPanel.Controls.Add(ConfirmationBtntableLayoutPanel);
            editFormBgPanel.Controls.Add(emailErrorMsg);
            editFormBgPanel.Controls.Add(refreshBtn);
            editFormBgPanel.Controls.Add(emailPassword);
            editFormBgPanel.Controls.Add(lNameErrorMsg);
            editFormBgPanel.Controls.Add(lNamePanel);
            editFormBgPanel.Controls.Add(fNameErrorMsg);
            editFormBgPanel.Controls.Add(fNamePanel);
            editFormBgPanel.Controls.Add(editPopupLbl);
            editFormBgPanel.Dock = DockStyle.Fill;
            editFormBgPanel.Location = new Point(0, 0);
            editFormBgPanel.Name = "editFormBgPanel";
            editFormBgPanel.Padding = new Padding(15, 10, 15, 10);
            editFormBgPanel.Size = new Size(574, 437);
            editFormBgPanel.TabIndex = 0;
            // 
            // errorMsg
            // 
            errorMsg.Dock = DockStyle.Top;
            errorMsg.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            errorMsg.ForeColor = Color.Firebrick;
            errorMsg.Location = new Point(15, 337);
            errorMsg.Name = "errorMsg";
            errorMsg.Padding = new Padding(0, 2, 0, 0);
            errorMsg.Size = new Size(544, 19);
            errorMsg.TabIndex = 12;
            errorMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmationBtntableLayoutPanel
            // 
            ConfirmationBtntableLayoutPanel.ColumnCount = 2;
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Controls.Add(confirmEditBtn, 1, 0);
            ConfirmationBtntableLayoutPanel.Controls.Add(cancelBtn, 0, 0);
            ConfirmationBtntableLayoutPanel.Dock = DockStyle.Bottom;
            ConfirmationBtntableLayoutPanel.Location = new Point(15, 363);
            ConfirmationBtntableLayoutPanel.Name = "ConfirmationBtntableLayoutPanel";
            ConfirmationBtntableLayoutPanel.RowCount = 1;
            ConfirmationBtntableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Size = new Size(544, 64);
            ConfirmationBtntableLayoutPanel.TabIndex = 8;
            // 
            // confirmEditBtn
            // 
            confirmEditBtn.Anchor = AnchorStyles.None;
            confirmEditBtn.BackColor = Color.FromArgb(93, 185, 64);
            confirmEditBtn.CornerRadius = 12;
            confirmEditBtn.Cursor = Cursors.Hand;
            confirmEditBtn.FlatAppearance.BorderSize = 0;
            confirmEditBtn.FlatStyle = FlatStyle.Flat;
            confirmEditBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmEditBtn.ForeColor = Color.FromArgb(241, 241, 241);
            confirmEditBtn.Location = new Point(325, 9);
            confirmEditBtn.Name = "confirmEditBtn";
            confirmEditBtn.Size = new Size(165, 45);
            confirmEditBtn.TabIndex = 1;
            confirmEditBtn.TabStop = false;
            confirmEditBtn.Text = "Confirm Changes";
            confirmEditBtn.UseVisualStyleBackColor = false;
            confirmEditBtn.Click += confirmEditBtn_Click;
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
            cancelBtn.Location = new Point(53, 9);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(165, 45);
            cancelBtn.TabIndex = 0;
            cancelBtn.TabStop = false;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // emailErrorMsg
            // 
            emailErrorMsg.Dock = DockStyle.Top;
            emailErrorMsg.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailErrorMsg.ForeColor = Color.Firebrick;
            emailErrorMsg.Location = new Point(15, 318);
            emailErrorMsg.Name = "emailErrorMsg";
            emailErrorMsg.Padding = new Padding(0, 4, 0, 0);
            emailErrorMsg.Size = new Size(544, 19);
            emailErrorMsg.TabIndex = 7;
            emailErrorMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // refreshBtn
            // 
            refreshBtn.Cursor = Cursors.Hand;
            refreshBtn.Image = Properties.Resources.reset;
            refreshBtn.Location = new Point(15, 10);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(30, 26);
            refreshBtn.SizeMode = PictureBoxSizeMode.Zoom;
            refreshBtn.TabIndex = 6;
            refreshBtn.TabStop = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // emailPassword
            // 
            emailPassword.Controls.Add(emailTextbox);
            emailPassword.Controls.Add(emailLbl);
            emailPassword.Dock = DockStyle.Top;
            emailPassword.Location = new Point(15, 249);
            emailPassword.Name = "emailPassword";
            emailPassword.Padding = new Padding(0, 20, 0, 0);
            emailPassword.Size = new Size(544, 69);
            emailPassword.TabIndex = 4;
            // 
            // emailTextbox
            // 
            emailTextbox.BackColor = Color.FromArgb(36, 36, 36);
            emailTextbox.BorderStyle = BorderStyle.None;
            emailTextbox.Dock = DockStyle.Bottom;
            emailTextbox.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTextbox.ForeColor = Color.White;
            emailTextbox.Location = new Point(0, 52);
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new Size(544, 17);
            emailTextbox.TabIndex = 1;
            // 
            // emailLbl
            // 
            emailLbl.Dock = DockStyle.Top;
            emailLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLbl.ForeColor = Color.FromArgb(241, 241, 241);
            emailLbl.ImageAlign = ContentAlignment.MiddleLeft;
            emailLbl.Location = new Point(0, 20);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(544, 23);
            emailLbl.TabIndex = 0;
            emailLbl.Text = "Email";
            emailLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lNameErrorMsg
            // 
            lNameErrorMsg.Dock = DockStyle.Top;
            lNameErrorMsg.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lNameErrorMsg.ForeColor = Color.Firebrick;
            lNameErrorMsg.Location = new Point(15, 230);
            lNameErrorMsg.Name = "lNameErrorMsg";
            lNameErrorMsg.Padding = new Padding(0, 4, 0, 0);
            lNameErrorMsg.Size = new Size(544, 19);
            lNameErrorMsg.TabIndex = 10;
            lNameErrorMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lNamePanel
            // 
            lNamePanel.Controls.Add(lNameTextbox);
            lNamePanel.Controls.Add(lNameLbl);
            lNamePanel.Dock = DockStyle.Top;
            lNamePanel.Location = new Point(15, 161);
            lNamePanel.Name = "lNamePanel";
            lNamePanel.Padding = new Padding(0, 20, 0, 0);
            lNamePanel.Size = new Size(544, 69);
            lNamePanel.TabIndex = 3;
            // 
            // lNameTextbox
            // 
            lNameTextbox.BackColor = Color.FromArgb(36, 36, 36);
            lNameTextbox.BorderStyle = BorderStyle.None;
            lNameTextbox.Dock = DockStyle.Bottom;
            lNameTextbox.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lNameTextbox.ForeColor = Color.White;
            lNameTextbox.Location = new Point(0, 52);
            lNameTextbox.Name = "lNameTextbox";
            lNameTextbox.Size = new Size(544, 17);
            lNameTextbox.TabIndex = 1;
            // 
            // lNameLbl
            // 
            lNameLbl.Dock = DockStyle.Top;
            lNameLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNameLbl.ForeColor = Color.FromArgb(241, 241, 241);
            lNameLbl.ImageAlign = ContentAlignment.MiddleLeft;
            lNameLbl.Location = new Point(0, 20);
            lNameLbl.Name = "lNameLbl";
            lNameLbl.Size = new Size(544, 23);
            lNameLbl.TabIndex = 0;
            lNameLbl.Text = "Last Name";
            lNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fNameErrorMsg
            // 
            fNameErrorMsg.Dock = DockStyle.Top;
            fNameErrorMsg.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fNameErrorMsg.ForeColor = Color.Firebrick;
            fNameErrorMsg.Location = new Point(15, 142);
            fNameErrorMsg.Name = "fNameErrorMsg";
            fNameErrorMsg.Padding = new Padding(0, 4, 0, 0);
            fNameErrorMsg.Size = new Size(544, 19);
            fNameErrorMsg.TabIndex = 11;
            fNameErrorMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fNamePanel
            // 
            fNamePanel.Controls.Add(fNameTextbox);
            fNamePanel.Controls.Add(fNameLbl);
            fNamePanel.Dock = DockStyle.Top;
            fNamePanel.Location = new Point(15, 73);
            fNamePanel.Name = "fNamePanel";
            fNamePanel.Padding = new Padding(0, 20, 0, 0);
            fNamePanel.Size = new Size(544, 69);
            fNamePanel.TabIndex = 2;
            // 
            // fNameTextbox
            // 
            fNameTextbox.BackColor = Color.FromArgb(36, 36, 36);
            fNameTextbox.BorderStyle = BorderStyle.None;
            fNameTextbox.Dock = DockStyle.Bottom;
            fNameTextbox.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fNameTextbox.ForeColor = Color.White;
            fNameTextbox.Location = new Point(0, 52);
            fNameTextbox.Name = "fNameTextbox";
            fNameTextbox.Size = new Size(544, 17);
            fNameTextbox.TabIndex = 1;
            // 
            // fNameLbl
            // 
            fNameLbl.Dock = DockStyle.Top;
            fNameLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fNameLbl.ForeColor = Color.FromArgb(241, 241, 241);
            fNameLbl.ImageAlign = ContentAlignment.MiddleLeft;
            fNameLbl.Location = new Point(0, 20);
            fNameLbl.Name = "fNameLbl";
            fNameLbl.Size = new Size(544, 23);
            fNameLbl.TabIndex = 0;
            fNameLbl.Text = "First Name";
            fNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // editPopupLbl
            // 
            editPopupLbl.Dock = DockStyle.Top;
            editPopupLbl.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editPopupLbl.ForeColor = Color.FromArgb(241, 241, 241);
            editPopupLbl.Location = new Point(15, 10);
            editPopupLbl.Name = "editPopupLbl";
            editPopupLbl.Size = new Size(544, 63);
            editPopupLbl.TabIndex = 0;
            editPopupLbl.Text = "Edit Profile";
            editPopupLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditFormPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 437);
            Controls.Add(editFormBgPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditFormPopup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditFormPopup";
            editFormBgPanel.ResumeLayout(false);
            ConfirmationBtntableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)refreshBtn).EndInit();
            emailPassword.ResumeLayout(false);
            emailPassword.PerformLayout();
            lNamePanel.ResumeLayout(false);
            lNamePanel.PerformLayout();
            fNamePanel.ResumeLayout(false);
            fNamePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel editFormBgPanel;
        private Panel fNamePanel;
        private UnderlineTextBox fNameTextbox;
        private Label fNameLbl;
        private Label editPopupLbl;
        private Panel emailPassword;
        private UnderlineTextBox emailTextbox;
        private Label emailLbl;
        private Panel lNamePanel;
        private UnderlineTextBox lNameTextbox;
        private Label lNameLbl;
        private PictureBox refreshBtn;
        private TableLayoutPanel ConfirmationBtntableLayoutPanel;
        private RoundedButton confirmEditBtn;
        private RoundedButton cancelBtn;
        private Label emailErrorMsg;
        private Label lNameErrorMsg;
        private Label fNameErrorMsg;
        private Label errorMsg;
    }
}