namespace BettingSystem.Forms
{
    partial class AdminMatchPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            bgPanel = new Panel();
            matchPanel = new Panel();
            loadingPnl = new Panel();
            loadingSpinner = new PictureBox();
            loadingLbl = new Label();
            matchDataGridView = new DataGridView();
            noMatchLbl = new Label();
            filterBtnBgPanel = new Panel();
            roundedPanel2 = new RoundedPanel();
            filterStatusPanel = new Panel();
            filterLeagueBtnPanel = new Panel();
            ligue1RadioButton = new RadioButton();
            serieAradioButton = new RadioButton();
            liguaRadioBtn = new RadioButton();
            premierRadioBtn = new RadioButton();
            championsLeagueRadioBtn = new RadioButton();
            allRadioBtn = new RadioButton();
            filterStatusLbl = new Label();
            applyBtnPanel = new Panel();
            applyFilterBtn = new RoundedButton();
            searchBarBgPanel = new Panel();
            SearchBarRoundedPanel = new RoundedPanel();
            clearSearchIcon = new PictureBox();
            searchbarTextBox = new TextBox();
            searchImg = new PictureBox();
            refreshIcon = new PictureBox();
            matchPageLbl = new Label();
            adminNavBar1 = new BettingSystem.Forms.CustomControls.AdminNavBar();
            bgPanel.SuspendLayout();
            matchPanel.SuspendLayout();
            loadingPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingSpinner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchDataGridView).BeginInit();
            filterBtnBgPanel.SuspendLayout();
            roundedPanel2.SuspendLayout();
            filterStatusPanel.SuspendLayout();
            filterLeagueBtnPanel.SuspendLayout();
            applyBtnPanel.SuspendLayout();
            searchBarBgPanel.SuspendLayout();
            SearchBarRoundedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearchIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)refreshIcon).BeginInit();
            SuspendLayout();
            // 
            // bgPanel
            // 
            bgPanel.BackColor = Color.FromArgb(36, 36, 36);
            bgPanel.Controls.Add(matchPanel);
            bgPanel.Controls.Add(filterBtnBgPanel);
            bgPanel.Controls.Add(searchBarBgPanel);
            bgPanel.Controls.Add(matchPageLbl);
            bgPanel.Controls.Add(adminNavBar1);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(1168, 672);
            bgPanel.TabIndex = 0;
            // 
            // matchPanel
            // 
            matchPanel.Controls.Add(loadingPnl);
            matchPanel.Controls.Add(matchDataGridView);
            matchPanel.Controls.Add(noMatchLbl);
            matchPanel.Dock = DockStyle.Fill;
            matchPanel.Location = new Point(0, 324);
            matchPanel.Name = "matchPanel";
            matchPanel.Padding = new Padding(50, 20, 50, 10);
            matchPanel.Size = new Size(1168, 348);
            matchPanel.TabIndex = 6;
            // 
            // loadingPnl
            // 
            loadingPnl.Controls.Add(loadingSpinner);
            loadingPnl.Controls.Add(loadingLbl);
            loadingPnl.Dock = DockStyle.Fill;
            loadingPnl.Location = new Point(50, 20);
            loadingPnl.Name = "loadingPnl";
            loadingPnl.Padding = new Padding(100);
            loadingPnl.Size = new Size(1068, 318);
            loadingPnl.TabIndex = 8;
            // 
            // loadingSpinner
            // 
            loadingSpinner.Dock = DockStyle.Fill;
            loadingSpinner.Image = Properties.Resources.loadingSpinner;
            loadingSpinner.Location = new Point(100, 100);
            loadingSpinner.Name = "loadingSpinner";
            loadingSpinner.Padding = new Padding(0, 5, 0, 5);
            loadingSpinner.Size = new Size(868, 73);
            loadingSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            loadingSpinner.TabIndex = 11;
            loadingSpinner.TabStop = false;
            // 
            // loadingLbl
            // 
            loadingLbl.Dock = DockStyle.Bottom;
            loadingLbl.Font = new Font("Times New Roman", 13.875F, FontStyle.Italic, GraphicsUnit.Point, 0);
            loadingLbl.ForeColor = Color.FromArgb(241, 241, 241);
            loadingLbl.Location = new Point(100, 173);
            loadingLbl.Name = "loadingLbl";
            loadingLbl.Padding = new Padding(0, 10, 0, 5);
            loadingLbl.Size = new Size(868, 45);
            loadingLbl.TabIndex = 10;
            loadingLbl.Text = "Loading Matches...";
            loadingLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // matchDataGridView
            // 
            matchDataGridView.AllowUserToAddRows = false;
            matchDataGridView.AllowUserToDeleteRows = false;
            matchDataGridView.AllowUserToOrderColumns = true;
            matchDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            matchDataGridView.BackgroundColor = Color.FromArgb(36, 36, 36);
            matchDataGridView.BorderStyle = BorderStyle.None;
            matchDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            matchDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(68, 123, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            matchDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            matchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(241, 241, 241);
            dataGridViewCellStyle2.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(241, 241, 241);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            matchDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            matchDataGridView.Dock = DockStyle.Fill;
            matchDataGridView.EnableHeadersVisualStyles = false;
            matchDataGridView.GridColor = Color.FromArgb(60, 60, 60);
            matchDataGridView.Location = new Point(50, 20);
            matchDataGridView.Name = "matchDataGridView";
            matchDataGridView.ReadOnly = true;
            matchDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            matchDataGridView.RowHeadersVisible = false;
            matchDataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            matchDataGridView.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 31);
            matchDataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            matchDataGridView.RowTemplate.Height = 90;
            matchDataGridView.Size = new Size(1068, 318);
            matchDataGridView.TabIndex = 7;
            matchDataGridView.Visible = false;
            // 
            // noMatchLbl
            // 
            noMatchLbl.Dock = DockStyle.Fill;
            noMatchLbl.Font = new Font("Times New Roman", 22.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            noMatchLbl.ForeColor = Color.FromArgb(241, 241, 241);
            noMatchLbl.Location = new Point(50, 20);
            noMatchLbl.Name = "noMatchLbl";
            noMatchLbl.Size = new Size(1068, 318);
            noMatchLbl.TabIndex = 0;
            noMatchLbl.Text = "No Matches Found";
            noMatchLbl.TextAlign = ContentAlignment.MiddleCenter;
            noMatchLbl.Visible = false;
            // 
            // filterBtnBgPanel
            // 
            filterBtnBgPanel.BackColor = Color.Transparent;
            filterBtnBgPanel.Controls.Add(roundedPanel2);
            filterBtnBgPanel.Dock = DockStyle.Top;
            filterBtnBgPanel.Location = new Point(0, 237);
            filterBtnBgPanel.Name = "filterBtnBgPanel";
            filterBtnBgPanel.Padding = new Padding(130, 30, 130, 10);
            filterBtnBgPanel.Size = new Size(1168, 87);
            filterBtnBgPanel.TabIndex = 4;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.FromArgb(68, 123, 60);
            roundedPanel2.BorderStyle = BorderStyle.FixedSingle;
            roundedPanel2.Controls.Add(filterStatusPanel);
            roundedPanel2.Controls.Add(applyBtnPanel);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.Location = new Point(130, 30);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Padding = new Padding(10, 0, 10, 0);
            roundedPanel2.Size = new Size(908, 47);
            roundedPanel2.TabIndex = 0;
            // 
            // filterStatusPanel
            // 
            filterStatusPanel.Controls.Add(filterLeagueBtnPanel);
            filterStatusPanel.Controls.Add(filterStatusLbl);
            filterStatusPanel.Dock = DockStyle.Fill;
            filterStatusPanel.Location = new Point(10, 0);
            filterStatusPanel.Name = "filterStatusPanel";
            filterStatusPanel.Size = new Size(764, 45);
            filterStatusPanel.TabIndex = 3;
            // 
            // filterLeagueBtnPanel
            // 
            filterLeagueBtnPanel.Controls.Add(ligue1RadioButton);
            filterLeagueBtnPanel.Controls.Add(serieAradioButton);
            filterLeagueBtnPanel.Controls.Add(liguaRadioBtn);
            filterLeagueBtnPanel.Controls.Add(premierRadioBtn);
            filterLeagueBtnPanel.Controls.Add(championsLeagueRadioBtn);
            filterLeagueBtnPanel.Controls.Add(allRadioBtn);
            filterLeagueBtnPanel.Dock = DockStyle.Fill;
            filterLeagueBtnPanel.Location = new Point(129, 0);
            filterLeagueBtnPanel.Name = "filterLeagueBtnPanel";
            filterLeagueBtnPanel.Size = new Size(635, 45);
            filterLeagueBtnPanel.TabIndex = 3;
            // 
            // ligue1RadioButton
            // 
            ligue1RadioButton.AutoSize = true;
            ligue1RadioButton.Cursor = Cursors.Hand;
            ligue1RadioButton.Dock = DockStyle.Left;
            ligue1RadioButton.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ligue1RadioButton.ForeColor = Color.FromArgb(241, 241, 241);
            ligue1RadioButton.Location = new Point(457, 0);
            ligue1RadioButton.Name = "ligue1RadioButton";
            ligue1RadioButton.Padding = new Padding(10, 0, 0, 0);
            ligue1RadioButton.Size = new Size(77, 45);
            ligue1RadioButton.TabIndex = 6;
            ligue1RadioButton.TabStop = true;
            ligue1RadioButton.Text = "Ligue 1";
            ligue1RadioButton.UseVisualStyleBackColor = true;
            // 
            // serieAradioButton
            // 
            serieAradioButton.AutoSize = true;
            serieAradioButton.Cursor = Cursors.Hand;
            serieAradioButton.Dock = DockStyle.Left;
            serieAradioButton.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            serieAradioButton.ForeColor = Color.FromArgb(241, 241, 241);
            serieAradioButton.Location = new Point(382, 0);
            serieAradioButton.Name = "serieAradioButton";
            serieAradioButton.Padding = new Padding(10, 0, 0, 0);
            serieAradioButton.Size = new Size(75, 45);
            serieAradioButton.TabIndex = 5;
            serieAradioButton.TabStop = true;
            serieAradioButton.Text = "Serie A";
            serieAradioButton.UseVisualStyleBackColor = true;
            // 
            // liguaRadioBtn
            // 
            liguaRadioBtn.AutoSize = true;
            liguaRadioBtn.Cursor = Cursors.Hand;
            liguaRadioBtn.Dock = DockStyle.Left;
            liguaRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            liguaRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            liguaRadioBtn.Location = new Point(305, 0);
            liguaRadioBtn.Name = "liguaRadioBtn";
            liguaRadioBtn.Padding = new Padding(10, 0, 0, 0);
            liguaRadioBtn.Size = new Size(77, 45);
            liguaRadioBtn.TabIndex = 4;
            liguaRadioBtn.TabStop = true;
            liguaRadioBtn.Text = "La Liga";
            liguaRadioBtn.UseVisualStyleBackColor = true;
            // 
            // premierRadioBtn
            // 
            premierRadioBtn.AutoSize = true;
            premierRadioBtn.Cursor = Cursors.Hand;
            premierRadioBtn.Dock = DockStyle.Left;
            premierRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            premierRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            premierRadioBtn.Location = new Point(182, 0);
            premierRadioBtn.Name = "premierRadioBtn";
            premierRadioBtn.Padding = new Padding(10, 0, 0, 0);
            premierRadioBtn.Size = new Size(123, 45);
            premierRadioBtn.TabIndex = 3;
            premierRadioBtn.TabStop = true;
            premierRadioBtn.Text = "Premier League";
            premierRadioBtn.UseVisualStyleBackColor = true;
            // 
            // championsLeagueRadioBtn
            // 
            championsLeagueRadioBtn.AutoSize = true;
            championsLeagueRadioBtn.Cursor = Cursors.Hand;
            championsLeagueRadioBtn.Dock = DockStyle.Left;
            championsLeagueRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            championsLeagueRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            championsLeagueRadioBtn.Location = new Point(40, 0);
            championsLeagueRadioBtn.Name = "championsLeagueRadioBtn";
            championsLeagueRadioBtn.Padding = new Padding(10, 0, 0, 0);
            championsLeagueRadioBtn.Size = new Size(142, 45);
            championsLeagueRadioBtn.TabIndex = 2;
            championsLeagueRadioBtn.TabStop = true;
            championsLeagueRadioBtn.Text = "Champions League";
            championsLeagueRadioBtn.UseVisualStyleBackColor = true;
            // 
            // allRadioBtn
            // 
            allRadioBtn.AutoSize = true;
            allRadioBtn.Cursor = Cursors.Hand;
            allRadioBtn.Dock = DockStyle.Left;
            allRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            allRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            allRadioBtn.Location = new Point(0, 0);
            allRadioBtn.Name = "allRadioBtn";
            allRadioBtn.Size = new Size(40, 45);
            allRadioBtn.TabIndex = 1;
            allRadioBtn.TabStop = true;
            allRadioBtn.Text = "All";
            allRadioBtn.UseVisualStyleBackColor = true;
            // 
            // filterStatusLbl
            // 
            filterStatusLbl.Dock = DockStyle.Left;
            filterStatusLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filterStatusLbl.ForeColor = Color.FromArgb(241, 241, 241);
            filterStatusLbl.Location = new Point(0, 0);
            filterStatusLbl.Name = "filterStatusLbl";
            filterStatusLbl.Size = new Size(129, 45);
            filterStatusLbl.TabIndex = 2;
            filterStatusLbl.Text = "Filter by League:";
            filterStatusLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyBtnPanel
            // 
            applyBtnPanel.Controls.Add(applyFilterBtn);
            applyBtnPanel.Dock = DockStyle.Right;
            applyBtnPanel.Location = new Point(774, 0);
            applyBtnPanel.Name = "applyBtnPanel";
            applyBtnPanel.Padding = new Padding(8);
            applyBtnPanel.Size = new Size(122, 45);
            applyBtnPanel.TabIndex = 2;
            // 
            // applyFilterBtn
            // 
            applyFilterBtn.BackColor = Color.FromArgb(241, 241, 241);
            applyFilterBtn.CornerRadius = 8;
            applyFilterBtn.Cursor = Cursors.Hand;
            applyFilterBtn.Dock = DockStyle.Fill;
            applyFilterBtn.Location = new Point(8, 8);
            applyFilterBtn.Name = "applyFilterBtn";
            applyFilterBtn.Size = new Size(106, 29);
            applyFilterBtn.TabIndex = 7;
            applyFilterBtn.Text = "Apply Filter";
            applyFilterBtn.UseVisualStyleBackColor = false;
            applyFilterBtn.Click += applyFilterBtn_Click;
            // 
            // searchBarBgPanel
            // 
            searchBarBgPanel.Controls.Add(SearchBarRoundedPanel);
            searchBarBgPanel.Controls.Add(refreshIcon);
            searchBarBgPanel.Dock = DockStyle.Top;
            searchBarBgPanel.Location = new Point(0, 161);
            searchBarBgPanel.Margin = new Padding(2, 1, 2, 1);
            searchBarBgPanel.Name = "searchBarBgPanel";
            searchBarBgPanel.Padding = new Padding(250, 10, 250, 10);
            searchBarBgPanel.Size = new Size(1168, 76);
            searchBarBgPanel.TabIndex = 7;
            // 
            // SearchBarRoundedPanel
            // 
            SearchBarRoundedPanel.BackColor = Color.FromArgb(48, 48, 48);
            SearchBarRoundedPanel.Controls.Add(clearSearchIcon);
            SearchBarRoundedPanel.Controls.Add(searchbarTextBox);
            SearchBarRoundedPanel.Controls.Add(searchImg);
            SearchBarRoundedPanel.Dock = DockStyle.Fill;
            SearchBarRoundedPanel.Location = new Point(250, 10);
            SearchBarRoundedPanel.Name = "SearchBarRoundedPanel";
            SearchBarRoundedPanel.Padding = new Padding(4, 0, 4, 0);
            SearchBarRoundedPanel.Size = new Size(668, 56);
            SearchBarRoundedPanel.TabIndex = 4;
            // 
            // clearSearchIcon
            // 
            clearSearchIcon.Cursor = Cursors.Hand;
            clearSearchIcon.Dock = DockStyle.Right;
            clearSearchIcon.Image = Properties.Resources.clearIcon;
            clearSearchIcon.Location = new Point(621, 0);
            clearSearchIcon.Margin = new Padding(2, 1, 2, 1);
            clearSearchIcon.Name = "clearSearchIcon";
            clearSearchIcon.Size = new Size(43, 56);
            clearSearchIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            clearSearchIcon.TabIndex = 5;
            clearSearchIcon.TabStop = false;
            clearSearchIcon.Click += clearSearchIcon_Click;
            // 
            // searchbarTextBox
            // 
            searchbarTextBox.BackColor = Color.FromArgb(48, 48, 48);
            searchbarTextBox.BorderStyle = BorderStyle.None;
            searchbarTextBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbarTextBox.ForeColor = Color.FromArgb(241, 241, 241);
            searchbarTextBox.Location = new Point(54, 17);
            searchbarTextBox.Margin = new Padding(2, 1, 2, 1);
            searchbarTextBox.Name = "searchbarTextBox";
            searchbarTextBox.PlaceholderText = "Enter a team's name";
            searchbarTextBox.Size = new Size(498, 19);
            searchbarTextBox.TabIndex = 1;
            // 
            // searchImg
            // 
            searchImg.Dock = DockStyle.Left;
            searchImg.Image = Properties.Resources.searchIcon;
            searchImg.Location = new Point(4, 0);
            searchImg.Margin = new Padding(2, 1, 2, 1);
            searchImg.Name = "searchImg";
            searchImg.Size = new Size(40, 56);
            searchImg.SizeMode = PictureBoxSizeMode.Zoom;
            searchImg.TabIndex = 3;
            searchImg.TabStop = false;
            // 
            // refreshIcon
            // 
            refreshIcon.Cursor = Cursors.Hand;
            refreshIcon.Image = Properties.Resources.reset;
            refreshIcon.Location = new Point(27, 20);
            refreshIcon.Name = "refreshIcon";
            refreshIcon.Size = new Size(42, 37);
            refreshIcon.SizeMode = PictureBoxSizeMode.Zoom;
            refreshIcon.TabIndex = 3;
            refreshIcon.TabStop = false;
            refreshIcon.Click += refreshIcon_Click;
            // 
            // matchPageLbl
            // 
            matchPageLbl.Dock = DockStyle.Top;
            matchPageLbl.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchPageLbl.ForeColor = Color.FromArgb(241, 241, 241);
            matchPageLbl.Location = new Point(0, 85);
            matchPageLbl.Name = "matchPageLbl";
            matchPageLbl.Padding = new Padding(0, 10, 0, 0);
            matchPageLbl.Size = new Size(1168, 76);
            matchPageLbl.TabIndex = 6;
            matchPageLbl.Text = "Matches";
            matchPageLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminNavBar1
            // 
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Size = new Size(1168, 85);
            adminNavBar1.TabIndex = 0;
            // 
            // AdminMatchPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 672);
            Controls.Add(bgPanel);
            Name = "AdminMatchPage";
            Text = "AdminMatchPage";
            bgPanel.ResumeLayout(false);
            matchPanel.ResumeLayout(false);
            loadingPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loadingSpinner).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchDataGridView).EndInit();
            filterBtnBgPanel.ResumeLayout(false);
            roundedPanel2.ResumeLayout(false);
            filterStatusPanel.ResumeLayout(false);
            filterLeagueBtnPanel.ResumeLayout(false);
            filterLeagueBtnPanel.PerformLayout();
            applyBtnPanel.ResumeLayout(false);
            searchBarBgPanel.ResumeLayout(false);
            SearchBarRoundedPanel.ResumeLayout(false);
            SearchBarRoundedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearchIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)refreshIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel bgPanel;
        private CustomControls.AdminNavBar adminNavBar1;
        private Panel searchBarBgPanel;
        private RoundedPanel SearchBarRoundedPanel;
        private PictureBox clearSearchIcon;
        private TextBox searchbarTextBox;
        private PictureBox searchImg;
        private PictureBox refreshIcon;
        private Label matchPageLbl;
        private Panel filterBtnBgPanel;
        private RoundedPanel roundedPanel2;
        private Panel filterStatusPanel;
        private Panel filterLeagueBtnPanel;
        private RadioButton liguaRadioBtn;
        private RadioButton premierRadioBtn;
        private RadioButton championsLeagueRadioBtn;
        private RadioButton allRadioBtn;
        private Label filterStatusLbl;
        private Panel applyBtnPanel;
        private RoundedButton applyFilterBtn;
        private Panel matchPanel;
        private RadioButton ligue1RadioButton;
        private RadioButton serieAradioButton;
        private Label noMatchLbl;
        private DataGridView matchDataGridView;
        private Panel loadingPnl;
        private Label loadingLbl;
        private PictureBox loadingSpinner;
    }
}