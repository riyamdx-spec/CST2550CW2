using BettingSystem.Data;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class AdminUsersPage : BaseForm
    {
        private AppUser _currentAdmin;
        private SessionManager _currentSession;
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private List<AppUser> _users = new List<AppUser>();

        public AdminUsersPage(AppUser admin, SessionManager session)
        {
            InitializeComponent();
            dgvUsers.ReadOnly = false; // added to show dropdown

            _currentAdmin = admin;
            _currentSession = session;

            adminNavBar1.SetAdmin(_currentAdmin);
            adminNavBar1.UsersPageClicked += (s, e) => _currentSession.OpenAdminViewUsersPage(this);
            adminNavBar1.SearchMatchesPageClicked += (s, e) => _currentSession.OpenAdminMatchPage(this);
            adminNavBar1.AddMatchesPageClicked += (s, e) => _currentSession.OpenAdminAddMatchPage(this);
            adminNavBar1.FinancialPageClicked += (s, e) => _currentSession.OpenAdminFinancialPage(this);
            adminNavBar1.LogoutClicked += (s, e) => _currentSession.LogOut(this);

            this.Load += AdminUsersPage_Load;
            this.FormClosing += AdminUsersPage_FormClosing;
        }

        private async void AdminUsersPage_Load(object sender, EventArgs e)
        {
            AddColumnHeaders();
            CaptureBaseLayout();
            await LoadUsers();

            dgvUsers.CellValueChanged += DgvUsers_CellValueChanged;
            dgvUsers.CurrentCellDirtyStateChanged += DgvUsers_CurrentCellDirtyStateChanged;
            dgvUsers.CellBeginEdit += OnCellBeginEdit;
        }

        private async Task LoadUsers()
        {
            _users = await _dbManager.FetchAllUsersAsync();
            PopulateGrid();
        }

        public async Task ReloadPage()
        {
            await LoadUsers();
        }

        private void AdminUsersPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false, true);
                if (closingPopup.ShowDialog() == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _currentSession.IsExiting = true;
                    Application.Exit();
                }
            }
        }

        private void AdminNavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!_currentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true, true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                    _currentSession.LogOut(this);
            }
        }

        private void AddColumnHeaders()
        {
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", FillWeight = 40 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFirstName", HeaderText = "First Name", FillWeight = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLastName", HeaderText = "Last Name", FillWeight = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDob", HeaderText = "Date of Birth", FillWeight = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", FillWeight = 140 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBalance", HeaderText = "Balance", FillWeight = 70 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "Role", FillWeight = 60 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRegistration", HeaderText = "Registered", FillWeight = 90 });

            var statusCol = new DataGridViewComboBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                FillWeight = 70,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                ReadOnly = false,
                AutoComplete = false
            };
            statusCol.Items.AddRange("Active", "Suspended", "Banned");
            dgvUsers.Columns.Add(statusCol);
        }

        private void PopulateGrid()
        {
            dgvUsers.Rows.Clear();

            foreach (AppUser user in _users)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.UserID,
                    user.FirstName,
                    user.LastName,
                    user.Dob.ToString("dd/MM/yyyy"),
                    user.Email,
                    $"${user.WalletBalance:F2}",
                    user.Role,
                    user.RegistrationDate.ToString("dd/MM/yyyy"),
                    user.Status
                );

                DataGridViewRow row = dgvUsers.Rows[rowIndex];
                StyleStatusCell(row, user.Status);
            }
        }

        private void OnCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check if status column is being edited
            if (dgvUsers.Columns[e.ColumnIndex].Name == "colStatus")
            {
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colId"].Value);
                AppUser selectedUser = _users.First(u => u.UserID == userId);

                // if status is banned, prevent editing
                if (selectedUser.Status == "Banned")
                {
                    e.Cancel = true;
                    new Notification("Cannot modify banned users", NotificationType.Warning, this);
                }
            }
        }

        private void StyleStatusCell(DataGridViewRow row, string status)
        {
            var cell = row.Cells["colStatus"];
            cell.Style.ForeColor = status switch
            {
                "Active" => Color.FromArgb(93, 185, 64),
                "Suspended" => Color.FromArgb(255, 165, 0),
                "Banned" => Color.FromArgb(220, 53, 53),
                _ => Color.FromArgb(241, 241, 241)
            };
            cell.Style.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
        }

        // ensure changes in dropdown are committed immediately
        private void DgvUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvUsers.IsCurrentCellDirty)
                dgvUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // handle status change when dropdown value changes
        private async void DgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUsers.Columns[e.ColumnIndex].Name != "colStatus") return;

            int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colId"].Value);
            AppUser selectedUser = _users.First(u => u.UserID == userId);
            string newStatus = dgvUsers.Rows[e.RowIndex].Cells["colStatus"].Value.ToString()!;

            if (newStatus == selectedUser.Status) return;

            await UpdateUserStatus(selectedUser, newStatus);
            StyleStatusCell(dgvUsers.Rows[e.RowIndex], newStatus);
        }

        private async Task UpdateUserStatus(AppUser user, string newStatus)
        {
            (bool success, string message) = await _dbManager.UpdateUserStatusAsync(user.UserID, newStatus);

            if (success)
            {
                user.Status = newStatus;
                new Notification(message, NotificationType.Success, this);
            }
            else
            {
                new Notification(message, NotificationType.Error, this);
            }
        }
    }
}