namespace BettingSystem.Forms
{
    public enum NotificationType { Success, Error, Warning, Info }
    public partial class Notification : Form
    {

        private Form _owner;

        private System.Windows.Forms.Timer _animationTimer;
        private int _targetX;
        private int _hiddenX;

        private bool _slidingIn = true;
        private int _displayTime = 1000;
        //private int _elapsed = 0;
        private DateTime _shownTime;

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

            _targetX = ownerScreenPosition.X + owner.ClientSize.Width - this.Width - 20;
            //_hiddenX = ownerScreenPosition.X + owner.ClientSize.Width - this.Width;
            _hiddenX = ownerScreenPosition.X + owner.ClientSize.Width + 10;
            this.Location = new Point(_hiddenX, y);

            this.Show(owner);
            this.BringToFront();

            // setup animation timer
            _animationTimer = new System.Windows.Forms.Timer();
            _animationTimer.Interval = 10;
            _animationTimer.Tick += Animate;
            _animationTimer.Start();
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
            int speed = 15; // ADDED

            if (_slidingIn)
            {
                if (this.Left > _targetX)
                {
                    //this.Left -= 10;
                    this.Left = Math.Max(this.Left - speed, _targetX);
                }
                else
                {
                    _slidingIn = false;
                    _shownTime = DateTime.Now; // ADDED
                }
            }
            else
            {
                //_elapsed += _animationTimer.Interval;
                //if (_elapsed >= _displayTime)

                if ((DateTime.Now - _shownTime).TotalMilliseconds >= _displayTime) // ADDED
                {
                    if (this.Left < _hiddenX)
                    {
                        //this.Left += 10;
                        this.Left = Math.Min(this.Left + speed, _hiddenX);
                    }
                    else
                    {
                        _animationTimer.Stop();
                        this.Close();
                    }
                }
            }
        }
    }
}