using CommonInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WelCome : Form
    {
        public WelCome()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体
            this.skinEngine1.SkinFile = "WarmColor2.ssk";
            x = this.Width;
            y = this.Height;
            setTag(this);

        }
        public static int PageTime;

        [Obsolete]
        private void WelCome_Load(object sender, EventArgs e)
        {
            timer1.Start();
            PageTime = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["PageTime"]) * 1000;
        }// System.Configuration.ConfigurationManager.AppSettings["PageTime"]
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

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Process.Start(@"C:\windows\system32\osk.exe");
            // System.Diagnostics.Process.Start(@"%windir%\system32\osk.exe");
            HideInputPanel();
            ShowInputPanel();
            CommonInfo.FrmMessageBox fm = new CommonInfo.FrmMessageBox("请输入密码", "管理员提示：", MessageBoxStyle.mima);
            //fm.ShowDialog();
            if (DialogResult.Cancel == fm.ShowDialog())
                return;
            //ShowInputPanel();
            HideInputPanel();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LabTime.Text = DateTime.Now.ToString("F");
            if (DateTime.Now.ToString("HH:mm:ss") == "06:00:00")//每天六点重启
            {
                Application.Restart();
            }
        }
        private const Int32 WM_SYSCOMMAND = 274;
        private const UInt32 SC_CLOSE = 61536;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegisterWindowMessage(string lpString);

        //显示屏幕键盘
        public static int ShowInputPanel()
        {
            try
            {
                dynamic file = "C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe";
                if (!System.IO.File.Exists(file))
                    return -1;
                Process.Start(file);
                //return SetUnDock(); //不知SetUnDock()是什么，所以直接注释返回1
                return 1;
            }
            catch (Exception)
            {
                return 255;
            }
        }

        //隐藏屏幕键盘
        public static void HideInputPanel()
        {
            IntPtr TouchhWnd = new IntPtr(0);
            TouchhWnd = FindWindow("IPTip_Main_Window", null);
            if (TouchhWnd == IntPtr.Zero)
                return;
            PostMessage(TouchhWnd, WM_SYSCOMMAND, SC_CLOSE, 0);
        }
        MDF_DouLaiDian db = new MDF_DouLaiDian();
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            WelCome.HideInputPanel();
            WelCome.ShowInputPanel();
            bool fl = true;
            string result = null;
            while (fl)
            {
                result = Microsoft.VisualBasic.Interaction.InputBox("请输入餐桌号", "锁定餐桌", "", 0, this.Top);
                if (string.IsNullOrEmpty(result))
                {
                    var A = MessageBox.Show("请重新输入，不可为空值", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.No == A)
                    {
                        fl = false;
                    }
                }
                else
                {
                    var i = db.FoodTable.Where(m => m.TableName.Equals(result));
                    if (i.Count() > 0)
                    {
                        MessageBox.Show("更改成功");
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
            WriteStart(result);
        }
        public static void WriteStart(string strMessage)
        {
            string fileFullPath = "Table.txt";//每日文件
            StringBuilder str = new StringBuilder();//定义字符串数据集

            str.Append(strMessage);//定义书写内容
            StreamWriter sw;
            sw = File.CreateText(fileFullPath);//创建这个文件

            sw.WriteLine(str.ToString(), Encoding.UTF8);//追加响应数据
            sw.Close();//数据流关闭
        }

    }
}
