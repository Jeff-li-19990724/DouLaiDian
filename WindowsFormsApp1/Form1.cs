using CommonInfo;
using HT;
using QT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            setTag(this);
            this.skinEngine1.SkinFile = "WarmColor2.ssk";
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
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }

        #endregion

        //private readonly MDF_DouLaiDian mDF = new MDF_DouLaiDian();
        List<ShopCar> shopCars = new List<ShopCar>();
        MDF_DouLaiDian mDF = new MDF_DouLaiDian();

        public int pageindex = 1;
        public int pagesize = 8;

        void Load_FoodList()
        {
            Foodlist = mDF.FoodList.OrderByDescending(i => i.FoodID).Select(p => p).ToList();
            DataFood(Foodlist);
        }
        void DataFood(List<FoodList> Foodlist)
        {
            label5.Text = (pageindex).ToString();
            //分页处理
            Foodlist = Foodlist.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            int q = Foodlist.Count();
            int hidd = 8 - q;
            //shopCars[q].Hide();
            try
            {
                for (int i = 0; i <= Foodlist.Count() - 1; i++)
                {
                    shopCars[i].Show();
                    shopCars[i].label2.Text = Foodlist[i].Price.ToString();
                    shopCars[i].label1.Text = Foodlist[i].FoodName.ToString();
                    shopCars[i].label4.Text = Foodlist[i].FoodID.ToString();
                    //// = O_Image;
                    try
                    {
                        shopCars[i].pictureBox1.Load(Foodlist[i].imageUrl);
                    }
                    catch
                    {

                    }
                }

                for (; q <= 7; q++)
                {
                    shopCars[q].Hide();
                }
            }
            catch
            {
                FrmMessageBox frm = new FrmMessageBox("请检测服务器开启情况", "提示", MessageBoxStyle.error);
                frm.ShowDialog();
            }
        }
        public static Bitmap GetBitmap(string newpath)
        {
            Bitmap img = (Bitmap)Image.FromStream(WebRequest.Create(newpath).GetResponse().GetResponseStream());

            Bitmap bmp = new Bitmap(img);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpcolor = bmp.GetPixel(i, j);
                    byte A = bmpcolor.A;
                    byte R = bmpcolor.R;
                    byte Gt = bmpcolor.G;
                    byte B = bmpcolor.B;

                    bmpcolor = Color.FromArgb(200, R, Gt, B);
                    bmp.SetPixel(i, j, bmpcolor);
                }
            }
            return bmp;
        }
        public static List<OrderFoodList> listsorder = new List<OrderFoodList>();
        public static string tablenum;
        public static void WriteStart(string strMessage)
        {
            //// string path = AppDomain.CurrentDomain.BaseDirectory + @"马\";//创建公有登录文件夹
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);//判断路径存在性
            //DateTime time = DateTime.Now;
            string fileFullPath = "Table.txt";//每日文件
            StringBuilder str = new StringBuilder();//定义字符串数据集

            str.Append(strMessage);//定义书写内容
            StreamWriter sw;
            sw = File.CreateText(fileFullPath);//创建这个文件

            sw.WriteLine(str.ToString(), Encoding.UTF8);//追加响应数据
            sw.Close();//数据流关闭
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CommonInfo.FrmMessageBox frm = new FrmMessageBox("是否选择共用模式", "模式选择", MessageBoxStyle.question);
            DialogResult A = frm.ShowDialog();
            if (A == DialogResult.Cancel)
            {
                buttonX1.Show();
                if (!File.Exists("Table.txt"))
                {
                    WelCome.HideInputPanel();
                    WelCome.ShowInputPanel();
                    string result;// = Microsoft.VisualBasic.Interaction.InputBox("请输入餐桌号", "锁定餐桌", "", this.Left, this.Top);
                   // WriteStart(result);
                    Boolean fl = true;
                    while (fl)
                    {
                        result = Microsoft.VisualBasic.Interaction.InputBox("请输入餐桌号", "锁定餐桌", "", this.Left, this.Top);
                        if (string.IsNullOrEmpty(result))
                        {
                            var B = MessageBox.Show("请重新输入，不可为空值", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (DialogResult.No == B)
                            {
                                fl = false;
                            }
                        }
                        else
                        {
                            var i = mDF.FoodTable.Where(m => m.TableName.Equals(result));
                            if (i.Count() > 0)
                            {
                                CommonInfo.FrmMessageBox fm = new CommonInfo.FrmMessageBox("添加成功", "管理员提示：", MessageBoxStyle.right);
                                fm.ShowDialog();
                                WriteStart(result);
                                WelCome.HideInputPanel();
                                fl = false;
                            }
                            else
                            {
                                CommonInfo.FrmMessageBox fm = new CommonInfo.FrmMessageBox("不存在该餐桌", "管理员提示：", MessageBoxStyle.question);
                                fm.ShowDialog();
                            }
                        }
                    }
                }
                List<String> Ro = new List<string>(File.ReadAllLines("Table.txt",Encoding.UTF8));
                tablenum = Ro[0];
                if(string.IsNullOrEmpty(tablenum))
                {    
                    CommonInfo.FrmMessageBox fm = new CommonInfo.FrmMessageBox("餐桌绑定失败", "管理员提示：", MessageBoxStyle.right);
                    fm.ShowDialog();
                }
            }
            else
            {
                buttonX1.Hide();
            }
            textBox2.Hide();
            button7.Hide();
            comboBox1.DataSource = mDF.FoodType.ToList();
            comboBox1.DisplayMember = "FoodTypeName";
            //comboBox1.ValueMember = "FoodTypeID";
            shopCars.Add(shopCar1);
            shopCars.Add(shopCar2);
            shopCars.Add(shopCar3);
            shopCars.Add(shopCar4);
            shopCars.Add(shopCar5);
            shopCars.Add(shopCar6);
            shopCars.Add(shopCar7);
            shopCars.Add(shopCar8);
            Load_FoodList();
        }
        // bool DJ;
        private void Type_Click(object sender, EventArgs e)
        {
            // DJ = true;
            pageindex = 1;
            var Btn = sender as Button;
            //FoodType = Btn.Text;
            Foodlist = mDF.FoodList.Where(i => i.FoodType.FoodTypeName.Equals(Btn.Text)).OrderByDescending(i => i.FoodID).Select(p => p).ToList();
            DataFood(Foodlist);
        }
        List<FoodList> Foodlist;
        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox1.Text))
            {
                // DJ = false;
                pageindex = 1;
                Foodlist = mDF.FoodList.Where(i => i.FoodType.FoodTypeName.Equals(comboBox1.Text.Trim())).OrderByDescending(i => i.FoodID).Select(p => p).ToList();
                DataFood(Foodlist);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            DataFood(Foodlist);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (pageindex == 1)
            {
                FrmMessageBox frm = new FrmMessageBox("当前是第一页", "提示", MessageBoxStyle.right);
                frm.ShowDialog();
                // MessageBox.Show("当前是第一页");
            }
            if (pageindex > 1)
            {
                pageindex--;
            }

            DataFood(Foodlist);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pageindex = 0;
            Foodlist = mDF.FoodList.OrderByDescending(i => i.FoodID).Select(p => p).ToList();
            DataFood(Foodlist);

        }
        //尾页
        private void label2_Click(object sender, EventArgs e)
        {
            if (Foodlist.Count() % 8.0 == 0)
            {
                pageindex = (Foodlist.Count() / 8);
            }
            else
            {
                pageindex = (Foodlist.Count() / 8) + 1;
            }
            DataFood(Foodlist);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            int max;
            if (Foodlist.Count() % 8.0 == 0)
            {
                max = (Foodlist.Count() / 8);
            }
            else
            {
                max = (Foodlist.Count() / 8) + 1;
            }
            if (pageindex == max)
            {
                MessageBox.Show("当前页码最大");
            }
            else
            {
                pageindex++;
                DataFood(Foodlist);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            Foodlist = mDF.FoodList.Where(i => i.FoodName.Contains(textBox1.Text.Trim())).OrderByDescending(i => i.FoodID).Select(p => p).ToList();
            DataFood(Foodlist);
        }
        购物清单 form;
        private void button9_Click(object sender, EventArgs e)
        {

            if (form == null) //如果子窗体为空则创造实例 并显示
            {
                form = new 购物清单();
                form.StartPosition = FormStartPosition.CenterScreen;//子窗体居中显示
                //form.Parent  = this.Owner;
                form.Show();
            }
            else
            {
                if (form.IsDisposed) //若子窗体关闭 则打开新子窗体 并显示
                {
                    form = new 购物清单();
                    form.StartPosition = FormStartPosition.CenterScreen;//子窗体居中显示
                    form.Show();
                }
                else
                {
                    //form.Show();
                    form.Activate(); //使子窗体获得焦点
                                     // form.MdiParent = this;
                                     //将窗口还原成普通模式
                    form.WindowState = FormWindowState.Normal;
                }
            }
            //  DJ.Show();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FoodTable table = mDF.FoodTable.FirstOrDefault(i => i.TableName.Contains(tablenum));
            if (table != null)
            {
                if (table.TableState == "占用")
                {
                    MessageBox.Show("正在占用，请联系前台");
                }
                else
                {
                    table.TableState = "占用";
                    mDF.FoodTable.AddOrUpdate(table);
                    mDF.SaveChanges();
                    MessageBox.Show("占用成功");
                }
            }
            else
            {
                MessageBox.Show("未检测到该餐桌，请联系管理员更换文件！");
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            WelCome.HideInputPanel();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            WelCome.HideInputPanel();
            WelCome.ShowInputPanel();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void shopCar1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
