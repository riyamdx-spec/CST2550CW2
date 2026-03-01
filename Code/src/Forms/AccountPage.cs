using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BettingSystem
{
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
            loadAccountPage();

        }

        private void loadAccountPage()
        {
            navDropdownBtn.Text = $"Full Name \n $1,200.50";

        }
        private void navDropdownBtn_Click(object sender, EventArgs e)
        {
            dropdownList.Show(navDropdownBtn, 0, navDropdownBtn.Height);
        }

        private void dobPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void walletDepositBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
