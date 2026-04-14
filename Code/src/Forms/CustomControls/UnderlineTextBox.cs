using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BettingSystem
{
    public class UnderlineTextBox : TextBox
    {
        private static readonly Color _defaultLineColor = ColorTranslator.FromHtml("#f1f1f1");
        private static readonly Color _defaultFocusColor = ColorTranslator.FromHtml("#f1f1f1");

        private Color _lineColor = _defaultLineColor;
        private Color _focusColor = _defaultFocusColor;
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
        public bool ShouldSerializeLineColor() => _lineColor != _defaultLineColor;
        public void ResetLineColor() => LineColor = _defaultLineColor;

        public bool ShouldSerializeFocusColor() => _focusColor != _defaultFocusColor;
        public void ResetFocusColor() => FocusColor = _defaultFocusColor;
    }

}
