using System.Windows.Forms.VisualStyles;

namespace BettingSystem
{
    partial class DepositMoneyPopup
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
            backgroundPanel = new Panel();
            btnPanel = new Panel();
            errorPanel = new Panel();
            lblDepositError = new Label();
            depositBtn = new Button();
            entriesLayout = new TableLayoutPanel();
            lblCvvError = new Label();
            lblExpDateError = new Label();
            lblCardNumError = new Label();
            cvvPanel = new Panel();
            txtCvv = new TextBox();
            txtCvvLine = new Panel();
            expDatePanel = new Panel();
            txtExpDate = new MaskedTextBox();
            amountPanel = new Panel();
            txtAmount = new TextBox();
            txtAmountLine = new Panel();
            lblAmount = new Label();
            lblCardNumber = new Label();
            lblExpDate = new Label();
            lblCVV = new Label();
            cardNumPanel = new Panel();
            txtCardNumber = new TextBox();
            txtCardNumLine = new Panel();
            lblAmountError = new Label();
            lblBalance = new Label();
            walletIcon = new PictureBox();
            backgroundPanel.SuspendLayout();
            btnPanel.SuspendLayout();
            errorPanel.SuspendLayout();
            entriesLayout.SuspendLayout();
            cvvPanel.SuspendLayout();
            expDatePanel.SuspendLayout();
            amountPanel.SuspendLayout();
            cardNumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)walletIcon).BeginInit();
            SuspendLayout();
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = Color.FromArgb(36, 36, 36);
            backgroundPanel.Controls.Add(btnPanel);
            backgroundPanel.Controls.Add(entriesLayout);
            backgroundPanel.Controls.Add(lblBalance);
            backgroundPanel.Controls.Add(walletIcon);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Padding = new Padding(5);
            backgroundPanel.Size = new Size(603, 372);
            backgroundPanel.TabIndex = 0;
            // 
            // btnPanel
            // 
            btnPanel.Controls.Add(errorPanel);
            btnPanel.Controls.Add(depositBtn);
            btnPanel.Dock = DockStyle.Fill;
            btnPanel.Location = new Point(5, 303);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(593, 64);
            btnPanel.TabIndex = 3;
            // 
            // errorPanel
            // 
            errorPanel.Controls.Add(lblDepositError);
            errorPanel.Dock = DockStyle.Bottom;
            errorPanel.Location = new Point(0, 49);
            errorPanel.Name = "errorPanel";
            errorPanel.Size = new Size(593, 15);
            errorPanel.TabIndex = 2;
            // 
            // lblDepositError
            // 
            lblDepositError.Anchor = AnchorStyles.Top;
            lblDepositError.AutoSize = true;
            lblDepositError.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepositError.ForeColor = Color.Firebrick;
            lblDepositError.Location = new Point(271, 0);
            lblDepositError.Name = "lblDepositError";
            lblDepositError.Size = new Size(69, 15);
            lblDepositError.TabIndex = 22;
            lblDepositError.Text = "deposit error";
            lblDepositError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // depositBtn
            // 
            depositBtn.Anchor = AnchorStyles.None;
            depositBtn.BackColor = Color.FromArgb(93, 185, 64);
            depositBtn.FlatAppearance.BorderColor = Color.FromArgb(93, 185, 64);
            depositBtn.FlatAppearance.BorderSize = 0;
            depositBtn.FlatStyle = FlatStyle.Popup;
            depositBtn.Font = new Font("Times New Roman", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            depositBtn.ForeColor = Color.FromArgb(241, 241, 241);
            depositBtn.Location = new Point(229, 11);
            depositBtn.Name = "depositBtn";
            depositBtn.Size = new Size(160, 35);
            depositBtn.TabIndex = 1;
            depositBtn.Text = "Deposit";
            depositBtn.UseVisualStyleBackColor = false;
            // 
            // entriesLayout
            // 
            entriesLayout.ColumnCount = 2;
            entriesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            entriesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            entriesLayout.Controls.Add(lblCvvError, 1, 7);
            entriesLayout.Controls.Add(lblExpDateError, 1, 5);
            entriesLayout.Controls.Add(lblCardNumError, 1, 3);
            entriesLayout.Controls.Add(cvvPanel, 1, 6);
            entriesLayout.Controls.Add(expDatePanel, 1, 4);
            entriesLayout.Controls.Add(amountPanel, 1, 0);
            entriesLayout.Controls.Add(lblAmount, 0, 0);
            entriesLayout.Controls.Add(lblCardNumber, 0, 2);
            entriesLayout.Controls.Add(lblExpDate, 0, 4);
            entriesLayout.Controls.Add(lblCVV, 0, 6);
            entriesLayout.Controls.Add(cardNumPanel, 1, 2);
            entriesLayout.Controls.Add(lblAmountError, 1, 1);
            entriesLayout.Dock = DockStyle.Top;
            entriesLayout.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            entriesLayout.Location = new Point(5, 100);
            entriesLayout.Name = "entriesLayout";
            entriesLayout.Padding = new Padding(20, 10, 20, 10);
            entriesLayout.RowCount = 8;
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle());
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            entriesLayout.Size = new Size(593, 203);
            entriesLayout.TabIndex = 2;
            // 
            // lblCvvError
            // 
            lblCvvError.AutoSize = true;
            lblCvvError.Dock = DockStyle.Fill;
            lblCvvError.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCvvError.ForeColor = Color.Firebrick;
            lblCvvError.Location = new Point(244, 170);
            lblCvvError.Name = "lblCvvError";
            lblCvvError.Size = new Size(326, 23);
            lblCvvError.TabIndex = 20;
            lblCvvError.Text = "cvv error";
            lblCvvError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpDateError
            // 
            lblExpDateError.AutoSize = true;
            lblExpDateError.Dock = DockStyle.Fill;
            lblExpDateError.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpDateError.ForeColor = Color.Firebrick;
            lblExpDateError.Location = new Point(244, 123);
            lblExpDateError.Name = "lblExpDateError";
            lblExpDateError.Size = new Size(326, 21);
            lblExpDateError.TabIndex = 18;
            lblExpDateError.Text = "date error";
            lblExpDateError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardNumError
            // 
            lblCardNumError.AutoSize = true;
            lblCardNumError.Dock = DockStyle.Fill;
            lblCardNumError.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCardNumError.ForeColor = Color.Firebrick;
            lblCardNumError.Location = new Point(244, 77);
            lblCardNumError.Name = "lblCardNumError";
            lblCardNumError.Size = new Size(326, 20);
            lblCardNumError.TabIndex = 16;
            lblCardNumError.Text = "card error";
            lblCardNumError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cvvPanel
            // 
            cvvPanel.Controls.Add(txtCvv);
            cvvPanel.Controls.Add(txtCvvLine);
            cvvPanel.Dock = DockStyle.Fill;
            cvvPanel.Location = new Point(241, 144);
            cvvPanel.Margin = new Padding(0);
            cvvPanel.Name = "cvvPanel";
            cvvPanel.Padding = new Padding(0, 5, 0, 0);
            cvvPanel.Size = new Size(332, 26);
            cvvPanel.TabIndex = 9;
            // 
            // txtCvv
            // 
            txtCvv.BackColor = Color.FromArgb(36, 36, 36);
            txtCvv.BorderStyle = BorderStyle.None;
            txtCvv.Dock = DockStyle.Fill;
            txtCvv.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCvv.ForeColor = Color.FromArgb(241, 241, 241);
            txtCvv.Location = new Point(0, 5);
            txtCvv.Name = "txtCvv";
            txtCvv.Size = new Size(332, 19);
            txtCvv.TabIndex = 0;
            // 
            // txtCvvLine
            // 
            txtCvvLine.BackColor = Color.FromArgb(241, 241, 241);
            txtCvvLine.Dock = DockStyle.Bottom;
            txtCvvLine.Location = new Point(0, 25);
            txtCvvLine.Name = "txtCvvLine";
            txtCvvLine.Size = new Size(332, 1);
            txtCvvLine.TabIndex = 1;
            // 
            // expDatePanel
            // 
            expDatePanel.Controls.Add(txtExpDate);
            expDatePanel.Dock = DockStyle.Fill;
            expDatePanel.Location = new Point(241, 97);
            expDatePanel.Margin = new Padding(0);
            expDatePanel.Name = "expDatePanel";
            expDatePanel.Padding = new Padding(0, 5, 0, 0);
            expDatePanel.Size = new Size(332, 26);
            expDatePanel.TabIndex = 8;
            // 
            // txtExpDate
            // 
            txtExpDate.BackColor = Color.FromArgb(36, 36, 36);
            txtExpDate.BorderStyle = BorderStyle.None;
            txtExpDate.Dock = DockStyle.Left;
            txtExpDate.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtExpDate.ForeColor = Color.FromArgb(241, 241, 241);
            txtExpDate.Location = new Point(0, 5);
            txtExpDate.Mask = "00/00";
            txtExpDate.Name = "txtExpDate";
            txtExpDate.Size = new Size(100, 19);
            txtExpDate.TabIndex = 3;
            // 
            // amountPanel
            // 
            amountPanel.Controls.Add(txtAmount);
            amountPanel.Controls.Add(txtAmountLine);
            amountPanel.Dock = DockStyle.Fill;
            amountPanel.Location = new Point(241, 10);
            amountPanel.Margin = new Padding(0);
            amountPanel.Name = "amountPanel";
            amountPanel.Padding = new Padding(0, 5, 0, 0);
            amountPanel.Size = new Size(332, 26);
            amountPanel.TabIndex = 6;
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.FromArgb(36, 36, 36);
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Dock = DockStyle.Fill;
            txtAmount.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.FromArgb(241, 241, 241);
            txtAmount.Location = new Point(0, 5);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(332, 19);
            txtAmount.TabIndex = 0;
            // 
            // txtAmountLine
            // 
            txtAmountLine.BackColor = Color.FromArgb(241, 241, 241);
            txtAmountLine.Dock = DockStyle.Bottom;
            txtAmountLine.Location = new Point(0, 25);
            txtAmountLine.Name = "txtAmountLine";
            txtAmountLine.Size = new Size(332, 1);
            txtAmountLine.TabIndex = 1;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.FromArgb(36, 36, 36);
            lblAmount.Dock = DockStyle.Left;
            lblAmount.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.FromArgb(241, 241, 241);
            lblAmount.Location = new Point(23, 10);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(117, 26);
            lblAmount.TabIndex = 0;
            lblAmount.Text = "Enter Amount:";
            lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Dock = DockStyle.Left;
            lblCardNumber.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCardNumber.ForeColor = Color.FromArgb(241, 241, 241);
            lblCardNumber.Location = new Point(23, 51);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(116, 26);
            lblCardNumber.TabIndex = 1;
            lblCardNumber.Text = "Card Number:";
            lblCardNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpDate
            // 
            lblExpDate.AutoSize = true;
            lblExpDate.Dock = DockStyle.Left;
            lblExpDate.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpDate.ForeColor = Color.FromArgb(241, 241, 241);
            lblExpDate.Location = new Point(23, 97);
            lblExpDate.Name = "lblExpDate";
            lblExpDate.Size = new Size(182, 26);
            lblExpDate.TabIndex = 2;
            lblExpDate.Text = "Expiry Date (MM/YY):";
            lblExpDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCVV
            // 
            lblCVV.AutoSize = true;
            lblCVV.Dock = DockStyle.Left;
            lblCVV.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCVV.ForeColor = Color.FromArgb(241, 241, 241);
            lblCVV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCVV.Location = new Point(23, 144);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(52, 26);
            lblCVV.TabIndex = 3;
            lblCVV.Text = "CVV:";
            lblCVV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardNumPanel
            // 
            cardNumPanel.Controls.Add(txtCardNumber);
            cardNumPanel.Controls.Add(txtCardNumLine);
            cardNumPanel.Dock = DockStyle.Fill;
            cardNumPanel.Location = new Point(241, 51);
            cardNumPanel.Margin = new Padding(0);
            cardNumPanel.Name = "cardNumPanel";
            cardNumPanel.Padding = new Padding(0, 5, 0, 0);
            cardNumPanel.Size = new Size(332, 26);
            cardNumPanel.TabIndex = 5;
            // 
            // txtCardNumber
            // 
            txtCardNumber.BackColor = Color.FromArgb(36, 36, 36);
            txtCardNumber.BorderStyle = BorderStyle.None;
            txtCardNumber.Dock = DockStyle.Fill;
            txtCardNumber.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCardNumber.ForeColor = Color.FromArgb(241, 241, 241);
            txtCardNumber.Location = new Point(0, 5);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(332, 19);
            txtCardNumber.TabIndex = 0;
            // 
            // txtCardNumLine
            // 
            txtCardNumLine.BackColor = Color.FromArgb(241, 241, 241);
            txtCardNumLine.Dock = DockStyle.Bottom;
            txtCardNumLine.Location = new Point(0, 25);
            txtCardNumLine.Name = "txtCardNumLine";
            txtCardNumLine.Size = new Size(332, 1);
            txtCardNumLine.TabIndex = 1;
            // 
            // lblAmountError
            // 
            lblAmountError.AutoSize = true;
            lblAmountError.Dock = DockStyle.Fill;
            lblAmountError.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountError.ForeColor = Color.Firebrick;
            lblAmountError.Location = new Point(244, 36);
            lblAmountError.Name = "lblAmountError";
            lblAmountError.Size = new Size(326, 15);
            lblAmountError.TabIndex = 10;
            lblAmountError.Text = "amount error";
            lblAmountError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            lblBalance.Dock = DockStyle.Top;
            lblBalance.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.FromArgb(241, 241, 241);
            lblBalance.Location = new Point(5, 65);
            lblBalance.Margin = new Padding(0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(593, 35);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "Current Balance: $ 1,000.50 ";
            lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // walletIcon
            // 
            walletIcon.Dock = DockStyle.Top;
            walletIcon.Image = Properties.Resources.wallet;
            walletIcon.Location = new Point(5, 5);
            walletIcon.Name = "walletIcon";
            walletIcon.Size = new Size(593, 60);
            walletIcon.SizeMode = PictureBoxSizeMode.Zoom;
            walletIcon.TabIndex = 0;
            walletIcon.TabStop = false;
            // 
            // DepositMoneyPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 372);
            Controls.Add(backgroundPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "DepositMoneyPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DepositMoneyPopup";
            backgroundPanel.ResumeLayout(false);
            btnPanel.ResumeLayout(false);
            errorPanel.ResumeLayout(false);
            errorPanel.PerformLayout();
            entriesLayout.ResumeLayout(false);
            entriesLayout.PerformLayout();
            cvvPanel.ResumeLayout(false);
            cvvPanel.PerformLayout();
            expDatePanel.ResumeLayout(false);
            expDatePanel.PerformLayout();
            amountPanel.ResumeLayout(false);
            amountPanel.PerformLayout();
            cardNumPanel.ResumeLayout(false);
            cardNumPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)walletIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel backgroundPanel;
        private Label lblBalance;
        private PictureBox walletIcon;
        private TableLayoutPanel entriesLayout;
        private Label lblAmount;
        private Label lblCardNumber;
        private Label lblExpDate;
        private Label lblCVV;
       
        private Panel cardNumPanel;
        private TextBox txtCardNumber;
        private Panel txtCardNumLine;
        private Panel expDatePanel;
        private Panel amountPanel;
        private TextBox txtAmount;
        private Panel txtAmountLine;
        private Panel btnPanel;
        private Panel cvvPanel;
        private TextBox txtCvv;
        private Panel txtCvvLine;
        private Button depositBtn;
        private MaskedTextBox txtExpDate;
        private Label lblCardNumError;
        private Label lblAmountError;
        private Label lblCvvError;
        private Label lblExpDateError;
        private Panel errorPanel;
        private Label lblDepositError;
    }
}