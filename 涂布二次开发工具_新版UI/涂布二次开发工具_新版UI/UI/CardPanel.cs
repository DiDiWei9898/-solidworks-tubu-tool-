using System;
using System.Drawing;
using System.Windows.Forms;

namespace 涂布二次开发工具.UI
{
    public class CardPanel : Panel
    {
        private string _title = "";
        private Color _titleColor = Color.FromArgb(30, 136, 229);
        private Color _borderColor = Color.LightGray;

        public string CardTitle
        {
            get { return _title; }
            set
            {
                _title = value;
                this.Invalidate();
            }
        }

        public Color TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public CardPanel()
        {
            this.BackColor = Color.White;
            this.Padding = new Padding(15, 45, 15, 15);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制标题栏背景
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(245, 247, 250)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, this.Width, 35);
            }

            // 绘制标题文字
            if (!string.IsNullOrEmpty(_title))
            {
                using (SolidBrush brush = new SolidBrush(_titleColor))
                using (Font font = new Font("微软雅黑", 10.5f, FontStyle.Bold))
                {
                    e.Graphics.DrawString(_title, font, brush, 15, 8);
                }
            }

            // 绘制标题栏底部横线
            using (Pen pen = new Pen(Color.FromArgb(220, 225, 230), 1))
            {
                e.Graphics.DrawLine(pen, 0, 35, this.Width, 35);
            }

            // 绘制边框
            using (Pen pen = new Pen(_borderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
