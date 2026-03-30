namespace BettingSystem.Forms
{
    partial class AdminUsersPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            adminNavBar1 = new CustomControls.AdminNavBar();
            lblTitle = new Label();
            pnlContent = new Panel();
            dgvUsers = new DataGridView();

            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // adminNavBar1
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Size = new Size(1200, 85);
            adminNavBar1.TabIndex = 0;

            // lblTitle
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTitle.Height = 50;
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Users";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.TabIndex = 1;

            // pnlContent
            pnlContent.Controls.Add(dgvUsers);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(30, 15, 30, 15);
            pnlContent.TabIndex = 2;

            // dgvUsers
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(26, 26, 26);
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.GridColor = Color.FromArgb(50, 50, 50);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 50;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.TabIndex = 0;
            //dgvUsers.CellClick += dgvUsers_CellClick;

            // style
            dgvUsers.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.FromArgb(180, 180, 180),
                Font = new Font("Times New Roman", 10F, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(40, 40, 40),
                SelectionForeColor = Color.FromArgb(180, 180, 180),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(5)
            };

            dgvUsers.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(31, 31, 31),
                ForeColor = Color.FromArgb(241, 241, 241),
                Font = new Font("Times New Roman", 10F),
                SelectionBackColor = Color.FromArgb(50, 50, 50),
                SelectionForeColor = Color.FromArgb(241, 241, 241),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(5)
            };

            dgvUsers.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(36, 36, 36),
                ForeColor = Color.FromArgb(241, 241, 241),
                Font = new Font("Times New Roman", 10F),
                SelectionBackColor = Color.FromArgb(50, 50, 50),
                SelectionForeColor = Color.FromArgb(241, 241, 241),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(5)
            };

            // AdminUsersPage
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(pnlContent);
            Controls.Add(lblTitle);
            Controls.Add(adminNavBar1);
            MinimumSize = new Size(1200, 750);
            Name = "AdminUsersPage";
            Text = "Users";

            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        private CustomControls.AdminNavBar adminNavBar1;
        private Label lblTitle;
        private Panel pnlContent;
        private DataGridView dgvUsers;
    }
}