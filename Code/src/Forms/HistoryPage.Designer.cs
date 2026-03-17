namespace BettingSystem.Forms
{
    partial class HistoryPage
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
            bgPanel = new Panel();
            slipsFlowLayoutPanel = new FlowLayoutPanel();
            filterBtnBgPanel = new Panel();
            roundedPanel2 = new RoundedPanel();
            filterStatusPanel = new Panel();
            filterStatusBtnPanel = new Panel();
            pendingRadioBtn = new RadioButton();
            lostRadioBtn = new RadioButton();
            wonRadioBtn = new RadioButton();
            allRadioBtn = new RadioButton();
            filterStatusLbl = new Label();
            applyBtnPanel = new Panel();
            applyFilterBtn = new RoundedButton();
            sortDatePanel = new Panel();
            SortDateBtnPanel = new Panel();
            oldestRadioBtn = new RadioButton();
            newestRadioBtn = new RadioButton();
            sortDateLbl = new Label();
            historyPageLbl = new Label();
            navBar1 = new NavBar();
            bgPanel.SuspendLayout();
            filterBtnBgPanel.SuspendLayout();
            roundedPanel2.SuspendLayout();
            filterStatusPanel.SuspendLayout();
            filterStatusBtnPanel.SuspendLayout();
            applyBtnPanel.SuspendLayout();
            sortDatePanel.SuspendLayout();
            SortDateBtnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // bgPanel
            // 
            bgPanel.Controls.Add(slipsFlowLayoutPanel);
            bgPanel.Controls.Add(filterBtnBgPanel);
            bgPanel.Controls.Add(historyPageLbl);
            bgPanel.Controls.Add(navBar1);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Name = "bgPanel";
            bgPanel.Padding = new Padding(0, 0, 0, 20);
            bgPanel.Size = new Size(1184, 711);
            bgPanel.TabIndex = 0;
            // 
            // slipsFlowLayoutPanel
            // 
            slipsFlowLayoutPanel.AutoScroll = true;
            slipsFlowLayoutPanel.Dock = DockStyle.Fill;
            slipsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            slipsFlowLayoutPanel.Location = new Point(0, 237);
            slipsFlowLayoutPanel.Name = "slipsFlowLayoutPanel";
            slipsFlowLayoutPanel.Padding = new Padding(40, 10, 40, 5);
            slipsFlowLayoutPanel.Size = new Size(1184, 454);
            slipsFlowLayoutPanel.TabIndex = 4;
            slipsFlowLayoutPanel.WrapContents = false;
            // 
            // filterBtnBgPanel
            // 
            filterBtnBgPanel.BackColor = Color.Transparent;
            filterBtnBgPanel.Controls.Add(roundedPanel2);
            filterBtnBgPanel.Dock = DockStyle.Top;
            filterBtnBgPanel.Location = new Point(0, 150);
            filterBtnBgPanel.Name = "filterBtnBgPanel";
            filterBtnBgPanel.Padding = new Padding(170, 30, 170, 10);
            filterBtnBgPanel.Size = new Size(1184, 87);
            filterBtnBgPanel.TabIndex = 3;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.FromArgb(68, 123, 60);
            roundedPanel2.BorderStyle = BorderStyle.FixedSingle;
            roundedPanel2.Controls.Add(filterStatusPanel);
            roundedPanel2.Controls.Add(applyBtnPanel);
            roundedPanel2.Controls.Add(sortDatePanel);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.Location = new Point(170, 30);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Padding = new Padding(10, 0, 10, 0);
            roundedPanel2.Size = new Size(844, 47);
            roundedPanel2.TabIndex = 0;
            // 
            // filterStatusPanel
            // 
            filterStatusPanel.Controls.Add(filterStatusBtnPanel);
            filterStatusPanel.Controls.Add(filterStatusLbl);
            filterStatusPanel.Dock = DockStyle.Fill;
            filterStatusPanel.Location = new Point(332, 0);
            filterStatusPanel.Name = "filterStatusPanel";
            filterStatusPanel.Size = new Size(378, 45);
            filterStatusPanel.TabIndex = 3;
            // 
            // filterStatusBtnPanel
            // 
            filterStatusBtnPanel.Controls.Add(pendingRadioBtn);
            filterStatusBtnPanel.Controls.Add(lostRadioBtn);
            filterStatusBtnPanel.Controls.Add(wonRadioBtn);
            filterStatusBtnPanel.Controls.Add(allRadioBtn);
            filterStatusBtnPanel.Dock = DockStyle.Fill;
            filterStatusBtnPanel.Location = new Point(129, 0);
            filterStatusBtnPanel.Name = "filterStatusBtnPanel";
            filterStatusBtnPanel.Size = new Size(249, 45);
            filterStatusBtnPanel.TabIndex = 3;
            // 
            // pendingRadioBtn
            // 
            pendingRadioBtn.AutoSize = true;
            pendingRadioBtn.Cursor = Cursors.Hand;
            pendingRadioBtn.Dock = DockStyle.Left;
            pendingRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pendingRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            pendingRadioBtn.Location = new Point(161, 0);
            pendingRadioBtn.Name = "pendingRadioBtn";
            pendingRadioBtn.Padding = new Padding(10, 0, 0, 0);
            pendingRadioBtn.Size = new Size(80, 45);
            pendingRadioBtn.TabIndex = 4;
            pendingRadioBtn.TabStop = true;
            pendingRadioBtn.Text = "Pending";
            pendingRadioBtn.UseVisualStyleBackColor = true;
            // 
            // lostRadioBtn
            // 
            lostRadioBtn.AutoSize = true;
            lostRadioBtn.Cursor = Cursors.Hand;
            lostRadioBtn.Dock = DockStyle.Left;
            lostRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lostRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            lostRadioBtn.Location = new Point(101, 0);
            lostRadioBtn.Name = "lostRadioBtn";
            lostRadioBtn.Padding = new Padding(10, 0, 0, 0);
            lostRadioBtn.Size = new Size(60, 45);
            lostRadioBtn.TabIndex = 3;
            lostRadioBtn.TabStop = true;
            lostRadioBtn.Text = "Lost";
            lostRadioBtn.UseVisualStyleBackColor = true;
            // 
            // wonRadioBtn
            // 
            wonRadioBtn.AutoSize = true;
            wonRadioBtn.Cursor = Cursors.Hand;
            wonRadioBtn.Dock = DockStyle.Left;
            wonRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            wonRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            wonRadioBtn.Location = new Point(40, 0);
            wonRadioBtn.Name = "wonRadioBtn";
            wonRadioBtn.Padding = new Padding(10, 0, 0, 0);
            wonRadioBtn.Size = new Size(61, 45);
            wonRadioBtn.TabIndex = 2;
            wonRadioBtn.TabStop = true;
            wonRadioBtn.Text = "Won";
            wonRadioBtn.UseVisualStyleBackColor = true;
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
            filterStatusLbl.Text = "Filter by Status:";
            filterStatusLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyBtnPanel
            // 
            applyBtnPanel.Controls.Add(applyFilterBtn);
            applyBtnPanel.Dock = DockStyle.Right;
            applyBtnPanel.Location = new Point(710, 0);
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
            // sortDatePanel
            // 
            sortDatePanel.Controls.Add(SortDateBtnPanel);
            sortDatePanel.Controls.Add(sortDateLbl);
            sortDatePanel.Dock = DockStyle.Left;
            sortDatePanel.Location = new Point(10, 0);
            sortDatePanel.Name = "sortDatePanel";
            sortDatePanel.Size = new Size(322, 45);
            sortDatePanel.TabIndex = 0;
            // 
            // SortDateBtnPanel
            // 
            SortDateBtnPanel.Controls.Add(oldestRadioBtn);
            SortDateBtnPanel.Controls.Add(newestRadioBtn);
            SortDateBtnPanel.Dock = DockStyle.Fill;
            SortDateBtnPanel.Location = new Point(113, 0);
            SortDateBtnPanel.Name = "SortDateBtnPanel";
            SortDateBtnPanel.Size = new Size(209, 45);
            SortDateBtnPanel.TabIndex = 5;
            // 
            // oldestRadioBtn
            // 
            oldestRadioBtn.AutoSize = true;
            oldestRadioBtn.Cursor = Cursors.Hand;
            oldestRadioBtn.Dock = DockStyle.Left;
            oldestRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            oldestRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            oldestRadioBtn.Location = new Point(68, 0);
            oldestRadioBtn.Name = "oldestRadioBtn";
            oldestRadioBtn.Padding = new Padding(10, 0, 0, 0);
            oldestRadioBtn.Size = new Size(71, 45);
            oldestRadioBtn.TabIndex = 4;
            oldestRadioBtn.TabStop = true;
            oldestRadioBtn.Text = "Oldest";
            oldestRadioBtn.UseVisualStyleBackColor = true;
            // 
            // newestRadioBtn
            // 
            newestRadioBtn.AutoSize = true;
            newestRadioBtn.Cursor = Cursors.Hand;
            newestRadioBtn.Dock = DockStyle.Left;
            newestRadioBtn.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newestRadioBtn.ForeColor = Color.FromArgb(241, 241, 241);
            newestRadioBtn.Location = new Point(0, 0);
            newestRadioBtn.Name = "newestRadioBtn";
            newestRadioBtn.Size = new Size(68, 45);
            newestRadioBtn.TabIndex = 3;
            newestRadioBtn.TabStop = true;
            newestRadioBtn.Text = "Newest";
            newestRadioBtn.UseVisualStyleBackColor = true;
            // 
            // sortDateLbl
            // 
            sortDateLbl.Dock = DockStyle.Left;
            sortDateLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sortDateLbl.ForeColor = Color.FromArgb(241, 241, 241);
            sortDateLbl.Location = new Point(0, 0);
            sortDateLbl.Name = "sortDateLbl";
            sortDateLbl.Size = new Size(113, 45);
            sortDateLbl.TabIndex = 2;
            sortDateLbl.Text = "Sort by Date:";
            sortDateLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // historyPageLbl
            // 
            historyPageLbl.BackColor = Color.Transparent;
            historyPageLbl.Dock = DockStyle.Top;
            historyPageLbl.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historyPageLbl.ForeColor = Color.FromArgb(241, 241, 241);
            historyPageLbl.Location = new Point(0, 85);
            historyPageLbl.Name = "historyPageLbl";
            historyPageLbl.Padding = new Padding(0, 10, 0, 0);
            historyPageLbl.Size = new Size(1184, 65);
            historyPageLbl.TabIndex = 2;
            historyPageLbl.Text = "My Bet History";
            historyPageLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // navBar1
            // 
            navBar1.Dock = DockStyle.Top;
            navBar1.Location = new Point(0, 0);
            navBar1.Name = "navBar1";
            navBar1.Size = new Size(1184, 85);
            navBar1.TabIndex = 0;
            // 
            // HistoryPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 36, 36);
            ClientSize = new Size(1184, 711);
            Controls.Add(bgPanel);
            Name = "HistoryPage";
            Text = "HistoryPage";
            bgPanel.ResumeLayout(false);
            filterBtnBgPanel.ResumeLayout(false);
            roundedPanel2.ResumeLayout(false);
            filterStatusPanel.ResumeLayout(false);
            filterStatusBtnPanel.ResumeLayout(false);
            filterStatusBtnPanel.PerformLayout();
            applyBtnPanel.ResumeLayout(false);
            sortDatePanel.ResumeLayout(false);
            SortDateBtnPanel.ResumeLayout(false);
            SortDateBtnPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel bgPanel;
        private Label historyPageLbl;
        private NavBar navBar1;
        private Panel filterBtnBgPanel;
        private RoundedPanel roundedPanel2;
        private Panel sortDatePanel;
        private Label sortDateLbl;
        private RadioButton oldestRadioBtn;
        private RadioButton newestRadioBtn;
        private FlowLayoutPanel slipsFlowLayoutPanel;
        private Panel applyBtnPanel;
        private Panel filterStatusPanel;
        private Panel filterStatusBtnPanel;
        private RadioButton pendingRadioBtn;
        private RadioButton lostRadioBtn;
        private RadioButton wonRadioBtn;
        private RadioButton allRadioBtn;
        private Label filterStatusLbl;
        private RoundedButton applyFilterBtn;
        private Panel SortDateBtnPanel;
    }
}