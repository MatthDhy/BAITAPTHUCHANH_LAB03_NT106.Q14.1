using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bai04
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Định nghĩa 2 màu Gradient tối (Dark Mode)
            Color color1 = Color.FromArgb(25, 25, 30);
            Color color2 = Color.FromArgb(45, 48, 58);

            Rectangle rect = this.ClientRectangle;

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }
    }
}
