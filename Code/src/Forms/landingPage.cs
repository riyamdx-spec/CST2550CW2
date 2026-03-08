using System.Drawing.Drawing2D;

namespace BettingSystem.Forms
{
    public partial class landingPage : BaseForm
    {
        public landingPage()
        {
            InitializeComponent();
            this.Load += formLoad;

            CaptureBaseLayout();

            StyleButtons();
            hoverEffects();

        }

        private void formLoad(object? sender, EventArgs e)
        {

            // Set Parent of Controls to picBackground
            picLogo.Parent = picBackground;
            lblSlogan.Parent = picBackground;
            btnCreateAccount.Parent = picBackground;
            btnLogin.Parent = picBackground;

        }

        protected override void AfterScaling()
        {
            CentreHorizontally(lblSlogan);
        }

        private void StyleButtons()
        {
            btnLogin.Paint += (s, e) =>
            {
                Button btn = (Button)s;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Set region
                btn.Region = new Region(diagonalButton(btn.ClientRectangle, 18, 1));

                using (Pen pen = new Pen(Color.White, 2))
                {
                    Rectangle r = btn.ClientRectangle;

                    r.Inflate(-1, -1);

                    using (GraphicsPath path = diagonalButton(r, 18, 1))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            };

            btnCreateAccount.Paint += (s, e) =>
            {
                Button btn = (Button)s;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Set region
                btn.Region = new Region(diagonalButton(btn.ClientRectangle, 18, 1));

                using (Pen pen = new Pen(Color.White, 2))
                {
                    Rectangle r = btn.ClientRectangle;

                    r.Inflate(-1, -1);

                    using (GraphicsPath path = diagonalButton(r, 18, 1))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            };
        }

        private GraphicsPath diagonalButton(Rectangle r, int slant, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int d = radius * 2;

            path.AddLine(r.Left + slant, r.Top, r.Right, r.Top);
            path.AddLine(r.Right, r.Top, r.Right - slant, r.Bottom);
            path.AddLine(r.Right - slant, r.Bottom, r.Left, r.Bottom);
            path.AddLine(r.Left, r.Bottom, r.Left + slant, r.Top);

            path.CloseFigure();
            return path;
        }

        private void hoverEffects()
        {
            // Create Account button hover effects
            btnCreateAccount.MouseEnter += (s, e) =>
            {
                btnCreateAccount.Cursor = Cursors.Hand;
                btnCreateAccount.BackColor = Color.FromArgb(100, 28, 94, 28);
            };

            btnCreateAccount.MouseLeave += (s, e) =>
            {
                btnCreateAccount.BackColor = Color.Transparent;
            };

            // Login button hover effects
            btnLogin.MouseEnter += (s, e) =>
            {
                btnLogin.Cursor = Cursors.Hand;
                btnLogin.BackColor = Color.FromArgb(100, 28, 94, 28);
            };

            btnLogin.MouseLeave += (s, e) =>
            {
                btnLogin.BackColor = Color.FromArgb(93, 185, 64);
            };
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var form = new RegisterLoginForm(ViewPanel.SignUp);
            form.Size = this.Size;
            form.FormClosed += (s, args) =>
            {
                if (form.NavigatingBack)
                {
                    this.Size = form.Size;
                    this.Show();
                }
            };
            form.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var form = new RegisterLoginForm(ViewPanel.Login);
            form.Size = this.Size;
            form.FormClosed += (s, args) =>
            {
                if (form.NavigatingBack)
                {
                    this.Size = form.Size;
                    this.Show();
                }
            };
            form.Show();
            this.Hide();
        }
    }
}
