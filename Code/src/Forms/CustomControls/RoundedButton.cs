using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BettingSystem
{
    public class RoundedButton : Button
    {
        private int cornerRadius = 22;

        [Category("Appearance")]
        [Description("The radius, in pixels, of the button's corners.")]
        [DefaultValue(22)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                if (value < 0) value = 0;
                if (cornerRadius == value) return;
                cornerRadius = value;
                Invalidate();
                if (IsHandleCreated)
                {
                    using var path = new GraphicsPath();
                    int d = cornerRadius * 2;
                    var r = ClientRectangle;
                    path.AddArc(r.X, r.Y, d, d, 180, 90);
                    path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                    path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                    path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();
                    Region = new Region(path);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = new GraphicsPath();
            int d = CornerRadius * 2;
            var r = ClientRectangle;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            using var brush = new SolidBrush(BackColor);
            e.Graphics.FillPath(brush, path);
            Region = new Region(path);
            TextRenderer.DrawText(e.Graphics, Text, Font, r, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
