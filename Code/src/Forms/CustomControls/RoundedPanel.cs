using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BettingSystem
{
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 20;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Radius of rounded corners.")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                if (value == _cornerRadius) return;
                _cornerRadius = value;
                Invalidate();
                // Update region so designer preview reflects the change
                using var path = GetRoundedRect(ClientRectangle, _cornerRadius);
                Region = new Region(path);
            }
        }

        
        public bool ShouldSerializeCornerRadius() => _cornerRadius != 20;
        public void ResetCornerRadius() => CornerRadius = 20;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = GetRoundedRect(ClientRectangle, CornerRadius);
            using var brush = new SolidBrush(BackColor);
            e.Graphics.FillPath(brush, path);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using var path = GetRoundedRect(ClientRectangle, CornerRadius);
            Region = new Region(path);
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
