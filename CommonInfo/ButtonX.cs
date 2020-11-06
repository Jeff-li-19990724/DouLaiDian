using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CommonInfo
{
    public  class ButtonX : Button
    {
        Label labShow;
        public ButtonX()
        {
            this.FlatStyle = FlatStyle.Flat;//样式
            this.ForeColor = Color.Transparent;//前景
            this.BackColor = Color.Transparent;//去背景
            this.FlatAppearance.BorderSize = 0;//去边线
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下

            labShow = new Label();
            labShow.ForeColor = Color.LightGreen;
            labShow.AutoSize = true;
            labShow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        public void setLabShowText(string str)
        {
            labShow.Text = str;
            //SizeF size = labShow.CreateGraphics().MeasureString(str, labShow.Font);
            labShow.Location = new Point(this.Width /2, 1);
            this.Controls.Add(labShow);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.FlatAppearance.BorderSize = 1;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.FlatAppearance.BorderSize = 0;
            base.OnMouseLeave(e);
        }
        bool m_Checked;

        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }

    }
}
