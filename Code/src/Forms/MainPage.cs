using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BettingSystem.Forms
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            matchesFlowLayoutPanel.SizeChanged += updateMatchesPanelWidth;
            updateMatchesPanelWidth(null, null);
        }

        private void championsLeagueImg_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void seeBetBtn_Click(object sender, EventArgs e)
        {
            noMatchSelectedPanel.Hide();
        }

        //update width of matchesPanel dynamically
        private void updateMatchesPanelWidth(object sender, EventArgs e)
        {
            foreach (Control matchPanel in matchesFlowLayoutPanel.Controls)
            {
                matchPanel.Width = matchesFlowLayoutPanel.ClientSize.Width - matchesFlowLayoutPanel.Padding.Horizontal;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void laliguaImg_Click(object sender, EventArgs e)
        {
            leagueLbl.Text = "La Ligua";
        }
    }
}
