using System;
using System.Drawing;
using System.Windows.Forms;

namespace 涂布二次开发工具.UI
{
    public class NavigationButton : Button
    {
        private bool _isSelected = false;
        private Color _normalBackColor = Color.FromArgb(45, 55, 72);
        private Color _selectedBackColor = Color.FromArgb(30, 136, 229);
        private Color _hoverBackColor = Color.FromArgb(55, 65, 85);

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.BackColor = value ? _selectedBackColor : _normalBackColor;
                this.ForeColor = Color.White;
                this.Font = new Font("微软雅黑", 10.5f, value ? FontStyle.Bold : FontStyle.Regular);
                this.Invalidate();
            }
        }

        public string IconText { get; set; } = "";

        public NavigationButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = _normalBackColor;
            this.ForeColor = Color.White;
            this.Font = new Font("微软雅黑", 10.5f);
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Padding = new Padding(20, 0, 0, 0);
            this.Cursor = Cursors.Hand;
            this.Height = 50;
            this.Dock = DockStyle.Top;

            this.FlatAppearance.MouseOverBackColor = _hoverBackColor;
            this.FlatAppearance.MouseDownBackColor = _selectedBackColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // 绘制左侧选中指示条
            if (_isSelected)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 193, 7)))
                {
                    pevent.Graphics.FillRectangle(brush, 0, 0, 4, this.Height);
                }
            }
        }
    }
}
