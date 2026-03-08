using System.Windows.Forms.VisualStyles;
using BettingSystem.Forms.Properties;

namespace BettingSystem.Forms
{
    partial class WalletPopup
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
            btnTableLayoutPanel = new TableLayoutPanel();
            confirmTransactionBtn = new RoundedButton();
            cancelBtn = new RoundedButton();
            transactionErrorMsg = new Label();
            entriesLayout = new TableLayoutPanel();
            cvvTextbox = new UnderlineTextBox();
            cardNumTextbox = new UnderlineTextBox();
            lblCvvError = new Label();
            lblExpDateError = new Label();
            lblCardNumError = new Label();
            expDatePanel = new Panel();
            txtExpDate = new MaskedTextBox();
            lblAmount = new Label();
            lblCardNumber = new Label();
            lblExpDate = new Label();
            lblCVV = new Label();
            lblAmountError = new Label();
            lblBalance = new Label();
            walletIcon = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            amountTextbox = new UnderlineTextBox();
            backgroundPanel.SuspendLayout();
            btnPanel.SuspendLayout();
            btnTableLayoutPanel.SuspendLayout();
            entriesLayout.SuspendLayout();
            expDatePanel.SuspendLayout();
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
            backgroundPanel.Size = new Size(603, 392);
            backgroundPanel.TabIndex = 0;
            // 
            // btnPanel
            // 
            btnPanel.Controls.Add(btnTableLayoutPanel);
            btnPanel.Controls.Add(transactionErrorMsg);
            btnPanel.Dock = DockStyle.Fill;
            btnPanel.Location = new Point(5, 303);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(593, 84);
            btnPanel.TabIndex = 3;
            // 
            // btnTableLayoutPanel
            // 
            btnTableLayoutPanel.ColumnCount = 2;
            btnTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            btnTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            btnTableLayoutPanel.Controls.Add(confirmTransactionBtn, 1, 0);
            btnTableLayoutPanel.Controls.Add(cancelBtn, 0, 0);
            btnTableLayoutPanel.Dock = DockStyle.Bottom;
            btnTableLayoutPanel.Location = new Point(0, 20);
            btnTableLayoutPanel.Name = "btnTableLayoutPanel";
            btnTableLayoutPanel.RowCount = 1;
            btnTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            btnTableLayoutPanel.Size = new Size(593, 64);
            btnTableLayoutPanel.TabIndex = 3;
            // 
            // confirmTransactionBtn
            // 
            confirmTransactionBtn.Anchor = AnchorStyles.None;
            confirmTransactionBtn.BackColor = Color.FromArgb(93, 185, 64);
            confirmTransactionBtn.CornerRadius = 12;
            confirmTransactionBtn.Cursor = Cursors.Hand;
            confirmTransactionBtn.FlatAppearance.BorderSize = 0;
            confirmTransactionBtn.FlatStyle = FlatStyle.Flat;
            confirmTransactionBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmTransactionBtn.ForeColor = Color.FromArgb(241, 241, 241);
            confirmTransactionBtn.Location = new Point(362, 10);
            confirmTransactionBtn.Name = "confirmTransactionBtn";
            confirmTransactionBtn.Size = new Size(165, 43);
            confirmTransactionBtn.TabIndex = 2;
            confirmTransactionBtn.TabStop = false;
            confirmTransactionBtn.UseVisualStyleBackColor = false;
            confirmTransactionBtn.Click += confirmTransactionBtn_Click;
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
            cancelBtn.Location = new Point(65, 10);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(165, 43);
            cancelBtn.TabIndex = 1;
            cancelBtn.TabStop = false;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // transactionErrorMsg
            // 
            transactionErrorMsg.Dock = DockStyle.Top;
            transactionErrorMsg.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            transactionErrorMsg.ForeColor = Color.Firebrick;
            transactionErrorMsg.Location = new Point(0, 0);
            transactionErrorMsg.Name = "transactionErrorMsg";
            transactionErrorMsg.Size = new Size(593, 20);
            transactionErrorMsg.TabIndex = 23;
            transactionErrorMsg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // entriesLayout
            // 
            entriesLayout.ColumnCount = 2;
            entriesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            entriesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            entriesLayout.Controls.Add(amountTextbox, 1, 0);
            entriesLayout.Controls.Add(cvvTextbox, 1, 6);
            entriesLayout.Controls.Add(cardNumTextbox, 1, 2);
            entriesLayout.Controls.Add(lblCvvError, 1, 7);
            entriesLayout.Controls.Add(lblExpDateError, 1, 5);
            entriesLayout.Controls.Add(lblCardNumError, 1, 3);
            entriesLayout.Controls.Add(expDatePanel, 1, 4);
            entriesLayout.Controls.Add(lblAmount, 0, 0);
            entriesLayout.Controls.Add(lblCardNumber, 0, 2);
            entriesLayout.Controls.Add(lblExpDate, 0, 4);
            entriesLayout.Controls.Add(lblCVV, 0, 6);
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
            entriesLayout.RowStyles.Add(new RowStyle());
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle());
            entriesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            entriesLayout.RowStyles.Add(new RowStyle());
            entriesLayout.Size = new Size(593, 203);
            entriesLayout.TabIndex = 2;
            // 
            // cvvTextbox
            // 
            cvvTextbox.BackColor = Color.FromArgb(36, 36, 36);
            cvvTextbox.BorderStyle = BorderStyle.None;
            cvvTextbox.Dock = DockStyle.Bottom;
            cvvTextbox.Font = new Font("Times New Roman", 11F);
            cvvTextbox.ForeColor = Color.FromArgb(241, 241, 241);
            cvvTextbox.Location = new Point(244, 154);
            cvvTextbox.Name = "cvvTextbox";
            cvvTextbox.Size = new Size(326, 17);
            cvvTextbox.TabIndex = 26;
            // 
            // cardNumTextbox
            // 
            cardNumTextbox.BackColor = Color.FromArgb(36, 36, 36);
            cardNumTextbox.BorderStyle = BorderStyle.None;
            cardNumTextbox.Dock = DockStyle.Bottom;
            cardNumTextbox.Font = new Font("Times New Roman", 11F);
            cardNumTextbox.ForeColor = Color.FromArgb(241, 241, 241);
            cardNumTextbox.Location = new Point(244, 64);
            cardNumTextbox.Name = "cardNumTextbox";
            cardNumTextbox.Size = new Size(326, 17);
            cardNumTextbox.TabIndex = 23;
            // 
            // lblCvvError
            // 
            lblCvvError.AutoSize = true;
            lblCvvError.Dock = DockStyle.Bottom;
            lblCvvError.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCvvError.ForeColor = Color.Firebrick;
            lblCvvError.Location = new Point(244, 177);
            lblCvvError.Name = "lblCvvError";
            lblCvvError.Size = new Size(326, 16);
            lblCvvError.TabIndex = 20;
            lblCvvError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpDateError
            // 
            lblExpDateError.AutoSize = true;
            lblExpDateError.Dock = DockStyle.Fill;
            lblExpDateError.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpDateError.ForeColor = Color.Firebrick;
            lblExpDateError.Location = new Point(244, 129);
            lblExpDateError.Name = "lblExpDateError";
            lblExpDateError.Size = new Size(326, 16);
            lblExpDateError.TabIndex = 18;
            lblExpDateError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardNumError
            // 
            lblCardNumError.AutoSize = true;
            lblCardNumError.Dock = DockStyle.Bottom;
            lblCardNumError.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCardNumError.ForeColor = Color.Firebrick;
            lblCardNumError.Location = new Point(244, 84);
            lblCardNumError.Name = "lblCardNumError";
            lblCardNumError.Size = new Size(326, 16);
            lblCardNumError.TabIndex = 16;
            lblCardNumError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDatePanel
            // 
            expDatePanel.Controls.Add(txtExpDate);
            expDatePanel.Dock = DockStyle.Fill;
            expDatePanel.Location = new Point(241, 100);
            expDatePanel.Margin = new Padding(0);
            expDatePanel.Name = "expDatePanel";
            expDatePanel.Padding = new Padding(0, 5, 0, 0);
            expDatePanel.Size = new Size(332, 29);
            expDatePanel.TabIndex = 8;
            // 
            // txtExpDate
            // 
            txtExpDate.BackColor = Color.FromArgb(36, 36, 36);
            txtExpDate.BorderStyle = BorderStyle.None;
            txtExpDate.Dock = DockStyle.Bottom;
            txtExpDate.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtExpDate.ForeColor = Color.FromArgb(241, 241, 241);
            txtExpDate.Location = new Point(0, 10);
            txtExpDate.Mask = "00/00";
            txtExpDate.Name = "txtExpDate";
            txtExpDate.Size = new Size(332, 19);
            txtExpDate.TabIndex = 3;
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
            lblAmount.Size = new Size(117, 29);
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
            lblCardNumber.Location = new Point(23, 55);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(116, 29);
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
            lblExpDate.Location = new Point(23, 100);
            lblExpDate.Name = "lblExpDate";
            lblExpDate.Size = new Size(182, 29);
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
            lblCVV.Location = new Point(23, 145);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(52, 29);
            lblCVV.TabIndex = 3;
            lblCVV.Text = "CVV:";
            lblCVV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmountError
            // 
            lblAmountError.AutoSize = true;
            lblAmountError.Dock = DockStyle.Bottom;
            lblAmountError.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountError.ForeColor = Color.Firebrick;
            lblAmountError.Location = new Point(244, 39);
            lblAmountError.Name = "lblAmountError";
            lblAmountError.Size = new Size(326, 16);
            lblAmountError.TabIndex = 10;
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
            walletIcon.Image = Resources.wallet;
            walletIcon.Location = new Point(5, 5);
            walletIcon.Name = "walletIcon";
            walletIcon.Size = new Size(593, 60);
            walletIcon.SizeMode = PictureBoxSizeMode.Zoom;
            walletIcon.TabIndex = 0;
            walletIcon.TabStop = false;
            // 
            // amountTextbox
            // 
            amountTextbox.BackColor = Color.FromArgb(36, 36, 36);
            amountTextbox.BorderStyle = BorderStyle.None;
            amountTextbox.Dock = DockStyle.Bottom;
            amountTextbox.Font = new Font("Times New Roman", 11F);
            amountTextbox.ForeColor = Color.FromArgb(241, 241, 241);
            amountTextbox.Location = new Point(244, 19);
            amountTextbox.Name = "amountTextbox";
            amountTextbox.Size = new Size(326, 17);
            amountTextbox.TabIndex = 27;
            // 
            // WalletPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 392);
            Controls.Add(backgroundPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WalletPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DepositMoneyPopup";
            backgroundPanel.ResumeLayout(false);
            btnPanel.ResumeLayout(false);
            btnTableLayoutPanel.ResumeLayout(false);
            entriesLayout.ResumeLayout(false);
            entriesLayout.PerformLayout();
            expDatePanel.ResumeLayout(false);
            expDatePanel.PerformLayout();
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
        private Panel expDatePanel;
        private Panel btnPanel;
        private MaskedTextBox txtExpDate;
        private Label lblCardNumError;
        private Label lblAmountError;
        private Label lblCvvError;
        private Label lblExpDateError;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TableLayoutPanel btnTableLayoutPanel;
        private RoundedButton cancelBtn;
        private RoundedButton confirmTransactionBtn;
        private UnderlineTextBox cvvTextbox;
        private UnderlineTextBox cardNumTextbox;
        private Label transactionErrorMsg;
        private Panel panel1;
        private UnderlineTextBox amountTextbox;
    }
}