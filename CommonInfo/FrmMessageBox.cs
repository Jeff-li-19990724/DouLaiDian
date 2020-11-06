using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonInfo
{
    public partial class FrmMessageBox : Form
    {
        MessageBoxStyle style;
        string Mima;
        public FrmMessageBox(string message, string title, MessageBoxStyle style)
        {
            InitializeComponent();
            this.style = style;
            this.Text = title;
            labinfo.Text = message;
            labinfo.Visible = true;
            label1.Visible = false;
            textBox1.Visible = false;
            switch (style)
            {
                case MessageBoxStyle.error://报错
                    ButCancel.Visible = false;
                    ButOK.Location = ButCancel.Location;
                    picICO.Image = new Bitmap(Application.StartupPath + "\\Image\\error.png");
                    break;
                case MessageBoxStyle.info://详细信息
                    ButCancel.Visible = false;
                    ButOK.Location = ButCancel.Location;
                    picICO.Image = new Bitmap(Application.StartupPath + "\\Image\\info.png");
                    break;
                case MessageBoxStyle.question://出问题
                    picICO.Image = new Bitmap(Application.StartupPath + "\\Image\\question.png");
                    break;
                case MessageBoxStyle.right://正确
                    ButCancel.Visible = false;
                    ButOK.Location = ButCancel.Location;
                    picICO.Image = new Bitmap(Application.StartupPath + "\\Image\\right.png");
                    break;
                case MessageBoxStyle.mima://输入密码模式
                    picICO.Image = new Bitmap(Application.StartupPath + "\\Image\\question.png");
                    label1.Visible = true;
                    textBox1.Visible = true;
                    break;
            }

        }
        //public FrmMessageBox(string message,string title,MessageBoxStyle style,string mima):this(message, title, style)
        //{
        //    InitializeComponent();
        //    this.Mima = mima;
        //}

        private void ButOK_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text);
            if (this.style == MessageBoxStyle.mima && textBox1.Text.Equals("88888888"))
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (style == MessageBoxStyle.mima)
                {
                    MessageBox.Show("密码错误。");
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            // this.BackColor = Color.Red;
            // panelEx1.CanvasColor = Color.Transparent;
            textBox1.Focus();
            textBox1.GetType();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public enum MessageBoxStyle
    {
        info = 0,
        question = 1,
        right = 2,
        error = 3,
        mima = 4
    }
}
