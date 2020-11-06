using CommonInfo;
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

namespace WindowsFormsApp1
{
    public partial class 购物清单 : Form
    {
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public 购物清单()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
           // SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            x = this.Width;
            y = this.Height;
            // IntPtr hDeskTop = FindWindow("Progman", "Program    Manager");
            // SetParent(this.Handle, hDeskTop);
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
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
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
        #endregion

        private void 购物清单_Load(object sender, EventArgs e)
        {
            x = this.Width;
            y = this.Height;
            setTag(this);
            this.TopMost = true;
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            pictureBox1.Load("flower.gif");
            pictureBox2.Load("flower.gif");
            pictureBox3.Load("call2.gif");
            textBoxLabel1.Text ="总计:"+ TotalPrice().ToString()+"元";
            dataGridView1.DataSource = Form1.listsorder;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // _Calculator.Form1 form = new _Calculator.Form1();
           // form.Show();
        }
        MDF_DouLaiDian db = new MDF_DouLaiDian();

        double Tal;
        Double TotalPrice()
        {
            Tal = 0;
            foreach (var i in Form1.listsorder)
            {
                Tal += i.price * i.num;
            }
            return Tal;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            if (Form1.listsorder.Count() == 0)
            {
                MessageBox.Show("当前数据为空");
                return;
            }
            WelCome.HideInputPanel();
            WelCome.ShowInputPanel();
            string result = Microsoft.VisualBasic.Interaction.InputBox("请输入手机号", "手机号", "", this.Left, this.Top);
            if (!IsPhone(result))
            {
                WelCome.HideInputPanel();
                FrmMessageBox frm = new FrmMessageBox("手机号错误", "请正确输入", MessageBoxStyle.error);
                frm.ShowDialog();
                this.TopMost = true;
                
                return;
            }
            WelCome.HideInputPanel();
            this.TopMost = true;
            Order order = new Order();
            order.Date = DateTime.Now;
            order.ISOut = false;
            if (!String.IsNullOrEmpty(Form1.tablenum))
                order.phone = result + "餐桌号:" + Form1.tablenum;
            else
                order.phone = result;
            order.TotalParse = TotalPrice();
            db.Order.Add(order);
            db.SaveChanges();
            int orderid= order.OrderID;
            _ = new List<OrderList>();
            foreach (var i in Form1.listsorder)
            {
                OrderList ord = new OrderList();
                ord.OrderID = orderid;
                ord.foodname = i.foodname;
                ord.num = i.num;
                ord.price = i.price;
                db.OrderList.Add(ord);
                db.SaveChanges();
            }
            dataGridView1.DataSource = null;
            Form1.listsorder.Clear();
            FrmMessageBox frm1;this.TopMost = false;
            if (!String.IsNullOrEmpty(Form1.tablenum))
            {
                
                frm1 = new FrmMessageBox("请熟记订单编号" + ":" + orderid, "提示", MessageBoxStyle.right);
                
            }
            else
            {  
                frm1 = new FrmMessageBox("请熟记订单编号" + ":" + orderid+";请到前台申请座位", "提示", MessageBoxStyle.right);;         
            }
            frm1.ShowDialog();
            this.TopMost = true;
            dataGridView1.DataSource = Form1.listsorder.ToList();
            textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
        }
        public static bool IsPhone(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^(0[0-9]{2,3}\-)([2-9][0-9]{6,7})?(\-[0-9]{1,4})?$|(^(13[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8}$)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.listsorder.Count()==0)
            {
                MessageBox.Show("当前数据为空");
                return;
            }
            int numHang = this.dataGridView1.CurrentRow.Index;
            //获取选中行 中 列的索引
            int numLie = this.dataGridView1.CurrentCell.ColumnIndex;
            //获取选中列的Name
            string LieName = this.dataGridView1.Columns[numLie].Name;
            //获得指定行列修改过后值
            string strInfo = this.dataGridView1.Rows[numHang].Cells[numLie].Value.ToString();
            Form1.listsorder.RemoveAt(numHang);
            dataGridView1.DataSource = Form1.listsorder.ToList();
            textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
            // dataGridView1.DataSource = Form1.listsorder.ToList();
            //textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Form1.listsorder.ToList();
            textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
        }

        private void label1_Resize(object sender, EventArgs e)
        {

        }

        private void 购物清单_Resize(object sender, EventArgs e)
        {
            try
            {
                setTag(this);
                float newx = (this.Width) / x;
                float newy = (this.Height) / y;
                setControls(newx, newy, this);
                x = this.Width;
                y = this.Height;
            }
            catch
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numHang = this.dataGridView1.CurrentRow.Index;
            //获取选中行 中 列的索引
            int numLie = this.dataGridView1.CurrentCell.ColumnIndex;
            //获取选中列的Name
            string LieName = this.dataGridView1.Columns[numLie].Name;
            //获得指定行列修改过后值
            string strInfo = this.dataGridView1.Rows[numHang].Cells[0].Value.ToString();
            var order = Form1.listsorder.FirstOrDefault(i => i.foodname == strInfo);

            if (order != null)
            {
                order.num++;
                dataGridView1.DataSource = Form1.listsorder.ToList();
                textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
                return;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numHang = this.dataGridView1.CurrentRow.Index;
            //获取选中行 中 列的索引
            int numLie = this.dataGridView1.CurrentCell.ColumnIndex;
            //获取选中列的Name
            string LieName = this.dataGridView1.Columns[numLie].Name;
            //获得指定行列修改过后值
            string strInfo = this.dataGridView1.Rows[numHang].Cells[0].Value.ToString();
            var order = Form1.listsorder.FirstOrDefault(i => i.foodname == strInfo);

            if (order != null)
            {
                order.num--;
               // return;
            }
            if (order.num == 0)
            {
                Form1.listsorder.Remove(order);
               // return;
            }
            dataGridView1.DataSource = Form1.listsorder.ToList();
            textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Form1.listsorder.ToList();
            textBoxLabel1.Text = "总计:" + TotalPrice().ToString() + "元";
        }

        private void 购物清单_Activated(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void 购物清单_Deactivate(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
    }
}
