namespace BettingSystem.Forms
{
    public enum NotificationType { Success, Error, Warning, Info }
    public partial class Notification : Form
    {

        private Form _owner;

        private System.Windows.Forms.Timer animationTimer;
        private int targetX;
        private int hiddenX;

        private bool slidingIn = true;
        private int displayTime = 1000;
        private int elapsed = 0;

        public Notification(string message, NotificationType type, Form owner, Point? position = null)
        {
            InitializeComponent();

            this.BackColor = Color.MediumAquamarine;
            this.TransparencyKey = Color.MediumAquamarine;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            _owner = owner;

            // set message
            lblMessage.Text = message;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Dock = DockStyle.Fill;

            // measure text size
            SizeF textSize = TextRenderer.MeasureText(message, lblMessage.Font);
            int padding = 40;
            int minWidth = 250;
            int height = 50;
            int width = Math.Max(minWidth, (int)textSize.Width + padding * 2);

            // resize form and panel to fit text
            this.Size = new Size(width, height);
            mainPanel.Size = new Size(width, height);
            mainPanel.Location = new Point(0, 0);
            mainPanel.BackColor = Color.Transparent; // Make panel transparent

            // centre label inside panel
            lblMessage.Size = new Size(width - padding, height);
            lblMessage.Location = new Point(padding / 2, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.BackColor = Color.Transparent;

            Color panelColor = type switch
            {
                NotificationType.Success => Color.FromArgb(93, 185, 64),
                NotificationType.Error => Color.FromArgb(200, 50, 50),
                NotificationType.Warning => Color.FromArgb(220, 160, 0),
                NotificationType.Info => Color.FromArgb(60, 150, 220),
                _ => Color.FromArgb(93, 185, 64)
            };

            mainPanel.BackColor = panelColor;
            MakePanelRounded(mainPanel);
            this.StartPosition = FormStartPosition.Manual;

            Point ownerScreenPosition = owner.PointToScreen(Point.Empty);
            int y = ownerScreenPosition.Y + 20;

            targetX = ownerScreenPosition.X + owner.ClientSize.Width - this.Width - 20;
            hiddenX = ownerScreenPosition.X + owner.ClientSize.Width - this.Width;
            this.Location = new Point(hiddenX, y);

            this.Show(owner);
            this.BringToFront();

            // setup animation timer
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += Animate;
            animationTimer.Start();
        }

        private void MakePanelRounded(Panel panel)
        {
            int radius = 10;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(panel.ClientRectangle.X, panel.ClientRectangle.Y, radius, radius, 180, 90);
            path.AddArc(panel.ClientRectangle.Width - radius, panel.ClientRectangle.Y, radius, radius, 270, 90);
            path.AddArc(panel.ClientRectangle.Width - radius, panel.ClientRectangle.Height - radius, radius, radius, 0, 90);
            path.AddArc(panel.ClientRectangle.X, panel.ClientRectangle.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void Animate(object sender, EventArgs e)
        {
            if (slidingIn)
            {
                if (this.Left > targetX)
                {
                    this.Left -= 10;
                }
                else
                {
                    slidingIn = false;
                }
            }
            else
            {
                elapsed += animationTimer.Interval;

                if (elapsed >= displayTime)
                {
                    if (this.Left < hiddenX)
                    {
                        this.Left += 10;
                    }
                    else
                    {
                        animationTimer.Stop();
                        this.Close();
                    }
                }
            }
        }
    }
}