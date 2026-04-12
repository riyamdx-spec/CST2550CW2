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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            adminNavBar1 = new BettingSystem.Forms.CustomControls.AdminNavBar();
            lblTitle = new Label();
            pnlContent = new Panel();
            dgvUsers = new DataGridView();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // adminNavBar1
            // 
            adminNavBar1.Dock = DockStyle.Top;
            adminNavBar1.Location = new Point(0, 0);
            adminNavBar1.Name = "adminNavBar1";
            adminNavBar1.Size = new Size(1184, 85);
            adminNavBar1.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(241, 241, 241);
            lblTitle.Location = new Point(0, 85);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1184, 62);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Users";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(dgvUsers);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 147);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(30, 15, 30, 15);
            pnlContent.Size = new Size(1184, 564);
            pnlContent.TabIndex = 2;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(26, 26, 26);
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.GridColor = Color.FromArgb(50, 50, 50);
            dgvUsers.Location = new Point(30, 15);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 50;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1124, 534);
            dgvUsers.TabIndex = 0;
            // 
            // AdminUsersPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1184, 711);
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