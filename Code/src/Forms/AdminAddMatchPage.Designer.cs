namespace BettingSystem.Forms
{
    partial class AdminAddMatchPage
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
            contentPanel = new Panel();
            addMatchFormBg = new RoundedPanel();
            addMatchTable = new TableLayoutPanel();
            dateLbl = new Label();
            awayTeamComboBox = new ComboBox();
            awayTeamLbl = new Label();
            homeTeamComboBox = new ComboBox();
            homeTeamLbl = new Label();
            leagueLbl = new Label();
            leagueComboBox = new ComboBox();
            selectedMatchDate = new DateTimePicker();
            ConfirmationBtntableLayoutPanel = new TableLayoutPanel();
            addMatchBtn = new RoundedButton();
            clearBtn = new RoundedButton();
            addPageLbl = new Label();
            adminNavBar1 = new BettingSystem.Forms.CustomControls.AdminNavBar();
            panelBg.SuspendLayout();
            contentPanel.SuspendLayout();
            addMatchFormBg.SuspendLayout();
            addMatchTable.SuspendLayout();
            ConfirmationBtntableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelBg
            // 
            panelBg.BackColor = Color.FromArgb(36, 36, 36);
            panelBg.Controls.Add(contentPanel);
            panelBg.Controls.Add(addPageLbl);
            panelBg.Controls.Add(adminNavBar1);
            panelBg.Dock = DockStyle.Fill;
            panelBg.Location = new Point(0, 0);
            panelBg.Name = "panelBg";
            panelBg.Size = new Size(1184, 711);
            panelBg.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.Controls.Add(addMatchFormBg);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 161);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(200, 40, 200, 20);
            contentPanel.Size = new Size(1184, 550);
            contentPanel.TabIndex = 9;
            // 
            // addMatchFormBg
            // 
            addMatchFormBg.Anchor = AnchorStyles.Top;
            addMatchFormBg.BackColor = Color.FromArgb(31, 31, 31);
            addMatchFormBg.Controls.Add(addMatchTable);
            addMatchFormBg.Controls.Add(ConfirmationBtntableLayoutPanel);
            addMatchFormBg.Location = new Point(208, 40);
            addMatchFormBg.Name = "addMatchFormBg";
            addMatchFormBg.Size = new Size(800, 465);
            addMatchFormBg.TabIndex = 0;
            // 
            // addMatchTable
            // 
            addMatchTable.ColumnCount = 2;
            addMatchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            addMatchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            addMatchTable.Controls.Add(dateLbl, 0, 3);
            addMatchTable.Controls.Add(awayTeamComboBox, 1, 2);
            addMatchTable.Controls.Add(awayTeamLbl, 0, 2);
            addMatchTable.Controls.Add(homeTeamComboBox, 1, 1);
            addMatchTable.Controls.Add(homeTeamLbl, 0, 1);
            addMatchTable.Controls.Add(leagueLbl, 0, 0);
            addMatchTable.Controls.Add(leagueComboBox, 1, 0);
            addMatchTable.Controls.Add(selectedMatchDate, 1, 3);
            addMatchTable.Dock = DockStyle.Fill;
            addMatchTable.Location = new Point(0, 0);
            addMatchTable.Name = "addMatchTable";
            addMatchTable.RowCount = 4;
            addMatchTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            addMatchTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            addMatchTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            addMatchTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            addMatchTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            addMatchTable.Size = new Size(800, 401);
            addMatchTable.TabIndex = 10;
            // 
            // dateLbl
            // 
            dateLbl.Dock = DockStyle.Fill;
            dateLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            dateLbl.Location = new Point(3, 300);
            dateLbl.Name = "dateLbl";
            dateLbl.Padding = new Padding(20, 0, 0, 0);
            dateLbl.Size = new Size(294, 101);
            dateLbl.TabIndex = 6;
            dateLbl.Text = "Select Match Date:";
            dateLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // awayTeamComboBox
            // 
            awayTeamComboBox.Anchor = AnchorStyles.Left;
            awayTeamComboBox.Font = new Font("Times New Roman", 10.125F);
            awayTeamComboBox.FormattingEnabled = true;
            awayTeamComboBox.Location = new Point(303, 238);
            awayTeamComboBox.Name = "awayTeamComboBox";
            awayTeamComboBox.Size = new Size(389, 23);
            awayTeamComboBox.TabIndex = 5;
            // 
            // awayTeamLbl
            // 
            awayTeamLbl.Dock = DockStyle.Fill;
            awayTeamLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            awayTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            awayTeamLbl.Location = new Point(3, 200);
            awayTeamLbl.Name = "awayTeamLbl";
            awayTeamLbl.Padding = new Padding(20, 0, 0, 0);
            awayTeamLbl.Size = new Size(294, 100);
            awayTeamLbl.TabIndex = 4;
            awayTeamLbl.Text = "Select Away Team:";
            awayTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // homeTeamComboBox
            // 
            homeTeamComboBox.Anchor = AnchorStyles.Left;
            homeTeamComboBox.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeTeamComboBox.FormattingEnabled = true;
            homeTeamComboBox.Location = new Point(303, 138);
            homeTeamComboBox.Name = "homeTeamComboBox";
            homeTeamComboBox.Size = new Size(389, 23);
            homeTeamComboBox.TabIndex = 3;
            // 
            // homeTeamLbl
            // 
            homeTeamLbl.Dock = DockStyle.Fill;
            homeTeamLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeTeamLbl.ForeColor = Color.FromArgb(241, 241, 241);
            homeTeamLbl.Location = new Point(3, 100);
            homeTeamLbl.Name = "homeTeamLbl";
            homeTeamLbl.Padding = new Padding(20, 0, 0, 0);
            homeTeamLbl.Size = new Size(294, 100);
            homeTeamLbl.TabIndex = 2;
            homeTeamLbl.Text = "Select Home Team:";
            homeTeamLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // leagueLbl
            // 
            leagueLbl.Dock = DockStyle.Fill;
            leagueLbl.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leagueLbl.ForeColor = Color.FromArgb(241, 241, 241);
            leagueLbl.Location = new Point(3, 0);
            leagueLbl.Name = "leagueLbl";
            leagueLbl.Padding = new Padding(20, 0, 0, 0);
            leagueLbl.Size = new Size(294, 100);
            leagueLbl.TabIndex = 0;
            leagueLbl.Text = "Select a League First:";
            leagueLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // leagueComboBox
            // 
            leagueComboBox.Anchor = AnchorStyles.Left;
            leagueComboBox.Font = new Font("Times New Roman", 10.125F);
            leagueComboBox.FormattingEnabled = true;
            leagueComboBox.Location = new Point(303, 38);
            leagueComboBox.Name = "leagueComboBox";
            leagueComboBox.Size = new Size(389, 23);
            leagueComboBox.TabIndex = 1;
            // 
            // selectedMatchDate
            // 
            selectedMatchDate.Anchor = AnchorStyles.Left;
            selectedMatchDate.CalendarFont = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectedMatchDate.Location = new Point(303, 339);
            selectedMatchDate.Name = "selectedMatchDate";
            selectedMatchDate.Size = new Size(214, 23);
            selectedMatchDate.TabIndex = 7;
            selectedMatchDate.Format = DateTimePickerFormat.Custom;
            selectedMatchDate.CustomFormat = "dd/MM/yyyy HH:mm";
            selectedMatchDate.ShowUpDown = false;
            // 
            // ConfirmationBtntableLayoutPanel
            // 
            ConfirmationBtntableLayoutPanel.ColumnCount = 2;
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Controls.Add(addMatchBtn, 1, 0);
            ConfirmationBtntableLayoutPanel.Controls.Add(clearBtn, 0, 0);
            ConfirmationBtntableLayoutPanel.Dock = DockStyle.Bottom;
            ConfirmationBtntableLayoutPanel.Location = new Point(0, 401);
            ConfirmationBtntableLayoutPanel.Name = "ConfirmationBtntableLayoutPanel";
            ConfirmationBtntableLayoutPanel.RowCount = 1;
            ConfirmationBtntableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ConfirmationBtntableLayoutPanel.Size = new Size(800, 64);
            ConfirmationBtntableLayoutPanel.TabIndex = 9;
            // 
            // addMatchBtn
            // 
            addMatchBtn.Anchor = AnchorStyles.None;
            addMatchBtn.BackColor = Color.FromArgb(93, 185, 64);
            addMatchBtn.CornerRadius = 12;
            addMatchBtn.Cursor = Cursors.Hand;
            addMatchBtn.FlatAppearance.BorderSize = 0;
            addMatchBtn.FlatStyle = FlatStyle.Flat;
            addMatchBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addMatchBtn.ForeColor = Color.FromArgb(241, 241, 241);
            addMatchBtn.Location = new Point(517, 9);
            addMatchBtn.Name = "addMatchBtn";
            addMatchBtn.Size = new Size(165, 45);
            addMatchBtn.TabIndex = 1;
            addMatchBtn.TabStop = false;
            addMatchBtn.Text = "Add Match";
            addMatchBtn.UseVisualStyleBackColor = false;
            addMatchBtn.Click += addMatchBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.Anchor = AnchorStyles.None;
            clearBtn.BackColor = Color.FromArgb(241, 241, 241);
            clearBtn.CornerRadius = 12;
            clearBtn.Cursor = Cursors.Hand;
            clearBtn.FlatAppearance.BorderSize = 0;
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearBtn.ForeColor = Color.FromArgb(26, 26, 26);
            clearBtn.Location = new Point(117, 9);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(165, 45);
            clearBtn.TabIndex = 0;
            clearBtn.TabStop = false;
            clearBtn.Text = "Clear Fields";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += cancelBtn_Click;
            // 
            // addPageLbl
            // 
            addPageLbl.Dock = DockStyle.Top;
            addPageLbl.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addPageLbl.ForeColor = Color.FromArgb(241, 241, 241);
            addPageLbl.Location = new Point(0, 85);
            addPageLbl.Name = "addPageLbl";
            addPageLbl.Padding = new Padding(0, 10, 0, 0);
            addPageLbl.Size = new Size(1184, 76);
            addPageLbl.TabIndex = 7;
            addPageLbl.Text = "Add a New Match";
            addPageLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminNavBar1
            // 
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Size = new Size(1184, 85);
            adminNavBar1.TabIndex = 0;
            // 
            // AdminAddMatchPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            Controls.Add(panelBg);
            MinimumSize = new Size(1200, 750);
            Name = "AdminAddMatchPage";
            Text = "AddMatchPage";
            panelBg.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            addMatchFormBg.ResumeLayout(false);
            addMatchTable.ResumeLayout(false);
            ConfirmationBtntableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBg;
        private CustomControls.AdminNavBar adminNavBar1;
        private Label addPageLbl;
        private Panel contentPanel;
        private RoundedPanel addMatchFormBg;
        private TableLayoutPanel addMatchTable;
        private Label dateLbl;
        private ComboBox awayTeamComboBox;
        private Label awayTeamLbl;
        private ComboBox homeTeamComboBox;
        private Label homeTeamLbl;
        private Label leagueLbl;
        private ComboBox leagueComboBox;
        private DateTimePicker selectedMatchDate;
        private TableLayoutPanel ConfirmationBtntableLayoutPanel;
        private RoundedButton addMatchBtn;
        private RoundedButton clearBtn;
    }
}