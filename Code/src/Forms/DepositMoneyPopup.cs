using BettingSystem.Models;
using System.Drawing.Drawing2D;


namespace BettingSystem
{
    public partial class DepositMoneyPopup : Form
    {
        public DepositMoneyPopup(AppUser currentUser)
        {
            InitializeComponent();

            //remove minimise and maximise buttons
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            StyleWalletButtons();
        }

        private void StyleWalletButtons()
        {
            depositBtn.Paint += (s, e) =>
            {
                Button btn = (Button)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Set region
                btn.Region = new Region(RoundButton(btn.ClientRectangle, 15));

            };
        }

        private GraphicsPath RoundButton(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }


       
    }
}
