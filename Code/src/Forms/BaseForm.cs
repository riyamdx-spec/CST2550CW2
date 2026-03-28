using BettingSystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BettingSystem
{
    public class BaseForm : Form
    {
        private SizeF _baseFormSize;
        private MyDictionary<Control, RectangleF> _baseRects = new();
        private MyDictionary<Control, float> _baseFontSizes = new();

        protected void CaptureBaseLayout()
        {
            if (DesignMode) return;

            _baseFormSize = new SizeF(ClientSize.Width, ClientSize.Height);
            void Capture(Control parent)
            {
                // store initial position and size 
                foreach (Control c in parent.Controls)
                {
                    _baseRects[c] = new RectangleF(c.Left, c.Top, c.Width, c.Height);
                    if (c.Font != null) _baseFontSizes[c] = c.Font.Size;
                    if (c.HasChildren) Capture(c);
                }
            }
            Capture(this);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e); // to make sure form resizes first
            if (DesignMode) return;
            if (_baseRects.Count == 0) return;

            float sx = ClientSize.Width / _baseFormSize.Width;
            float sy = ClientSize.Height / _baseFormSize.Height;
            void Scale(Control parent)
            {

                // loop through controls to resize and reposition
                foreach (Control c in parent.Controls)
                {
                    if (!_baseRects.TryGetValue(c, out RectangleF b)) continue;
                    c.Location = new Point((int)(b.X * sx), (int)(b.Y * sy));
                    c.Size = new Size((int)(b.Width * sx), (int)(b.Height * sy));
                    if (_baseFontSizes.TryGetValue(c, out float fs))
                        c.Font = new Font(c.Font.FontFamily, Math.Max(6f, fs * sy));
                    if (c.HasChildren) Scale(c);
                }
            }
            Scale(this);
            AfterScaling();
        }


        // to allow centering after scaling
        protected virtual void AfterScaling() { }

        protected void CentreHorizontally(Control ctrl)
        {
            ctrl.Location = new Point(
                (ctrl.Parent.Width - ctrl.Width) / 2,
                ctrl.Location.Y);
        }
    }
}