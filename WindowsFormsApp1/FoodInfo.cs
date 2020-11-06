using QT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp1
{
    public partial class FoodInfo : Form
    {
        AutoAdaptWindowsSize autoAdaptSize;
        public FoodInfo()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            setTag(this);

        }
        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt16(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            setTag(this);
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            x = this.Width;
            y = this.Height;
        }

        #endregion

        MDF_DouLaiDian db = new MDF_DouLaiDian();
        public FoodInfo(string FoodID)
        {
            InitializeComponent();
            FoodList food = db.FoodList.Find(int.Parse(FoodID));
            pictureBox4.Load(food.imageUrl);
            label7.Text = db.FoodType.Find(food.FoodTypeID).FoodTypeName;
            label4.Text = food.FoodName;
            label5.Text = food.Price.ToString()+"元";
            textBoxLabel1.Text = food.introduce;
            //textBoxLabel1.ScrollBars = true;
            //label6.Text = food.introduce;
           // FoodInfo
        }

        private void FoodInfo_Load(object sender, EventArgs e)
        {
            x = this.Width;
            y = this.Height;
            setTag(this);
            pictureBox1.Load("flower.gif");
            pictureBox2.Load("flower.gif");
            pictureBox3.Load("order_detials_bg.png");
           // textBoxLabel1.BackColor = Color.Transparent;
        }
    }
    public class TextBoxLabel : System.Windows.Forms.TextBox
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32", EntryPoint = "ShowCaret")]
        private static extern bool ShowCaret(IntPtr hWnd);

        public TextBoxLabel() : base()
        {

            this.TabStop = false;
            this.SetStyle(ControlStyles.Selectable, false);
            this.Cursor = Cursors.Default;
            this.ReadOnly = true;
            this.ShortcutsEnabled = false;
            this.HideSelection = true;
            this.GotFocus += new EventHandler(TextBoxLabel_GotFocus);
            this.MouseMove += new MouseEventHandler(TextBoxLabel_MouseMove);
        }

        private void TextBoxLabel_GotFocus(Object sender, System.EventArgs e)
        {
            if (ShowCaret(((TextBox)sender).Handle))
            {
                HideCaret(((TextBox)sender).Handle);
            }
        }

        private void TextBoxLabel_MouseMove(Object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).SelectedText.Length > 0)
            {
                ((TextBox)sender).SelectionLength = 0;
            }
        }
    }


}
