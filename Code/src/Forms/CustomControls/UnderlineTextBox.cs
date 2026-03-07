using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BettingSystem
{
    public class UnderlineTextBox : TextBox
    {
        private static readonly Color DefaultLineColor = ColorTranslator.FromHtml("#f1f1f1");
        private static readonly Color DefaultFocusColor = ColorTranslator.FromHtml("#f1f1f1");

        private Color _lineColor = DefaultLineColor;
        private Color _focusColor = DefaultFocusColor;
        private bool _isFocused = false;

        [Browsable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LineColor
        {
            get => _lineColor;
            set { _lineColor = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FocusColor
        {
            get => _focusColor;
            set { _focusColor = value; Invalidate(); }
        }

        public UnderlineTextBox()
        {
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(48, 48, 48);
            ForeColor = Color.White;
            Font = new Font("Times New Roman", 11f);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnEnter(EventArgs e)
        {
            _isFocused = true;
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            _isFocused = false;
            Invalidate();
            base.OnLeave(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF || m.Msg == 0x85)
                DrawUnderline();
        }

        private void DrawUnderline()
        {
            using var g = Graphics.FromHwnd(Handle);
            using var pen = new Pen(_isFocused ? _focusColor : _lineColor, 2f);
            g.DrawLine(pen, 0, Height - 1, Width, Height - 1);
        }

        // Designer serialization helpers
        public bool ShouldSerializeLineColor() => _lineColor != DefaultLineColor;
        public void ResetLineColor() => LineColor = DefaultLineColor;

        public bool ShouldSerializeFocusColor() => _focusColor != DefaultFocusColor;
        public void ResetFocusColor() => FocusColor = DefaultFocusColor;
    }

}
