using SanNiuSignal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketClient;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ITxClient TxClient = null;
        private void sendSuccess(IPEndPoint end)
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), "接收", "数据发送成功" });
            this.listView1.Items.Insert(0, item);

            //textBox1.Text = "数据发送成功";
        }
        private void accptString(IPEndPoint end, string str)
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), end.ToString(), str });
            this.listView1.Items.Insert(0, item);
            //textBox1.Text = str;
        }
        private void engineClose()
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(),"接收", "客户端已经关闭" });
            this.listView1.Items.Insert(0, item);
           // textBox1.Text = "客户端已经关闭";
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }
        private void engineLost(string str)
        {
            MessageBox.Show(str);
        }
        private void reconnectionStart()
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), "接收", "10秒后自动重连开始" });
            this.listView1.Items.Insert(0, item);

            //textBox1.Text = "10秒后自动重连开始";
        }
        private void startResult(bool b, string str)
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), "接收", str });
            this.listView1.Items.Insert(0, item);
           // textBox1.Text = str;
            if (b)
            {
                this.button1.Enabled = true;
                this.button2.Enabled = false;
            }
            else
            {
                this.button1.Enabled = false;
                this.button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TxClient = TxStart.startClient(textBox2.Text, int.Parse(textBox3.Text));
                TxClient.AcceptString += new TxDelegate<IPEndPoint, string>(accptString);//当收到文本数据的时候
                TxClient.dateSuccess += new TxDelegate<IPEndPoint>(sendSuccess);//当对方已经成功收到我数据的时候
                TxClient.EngineClose += new TxDelegate(engineClose);//当客户端引擎完全关闭释放资源的时候
                TxClient.EngineLost += new TxDelegate<string>(engineLost);//当客户端非正常原因断开的时候
                TxClient.ReconnectionStart += new TxDelegate(reconnectionStart);//当自动重连开始的时候
                TxClient.StartResult += new TxDelegate<bool, string>(startResult);//当登录完成的时候
                //TxClient.BufferSize = 12048;//这里大小自己设置，默认为1KB，也就是1024个字节
                TxClient.StartEngine();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), "发送", textBox1.Text });
            this.listView1.Items.Insert(0, item);
            TxClient.sendMessage(textBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), "发送", "呼叫" });
            this.listView1.Items.Insert(0, item);
            //Image im = pictureBox1.Image;
            //byte[] bytes = objectByte.ConvertImage(im);
            //TxClient.sendMessage(bytes);
            TxClient.sendMessage(tablenum+"号桌发来呼叫");
        }
        public static void WriteStart(string strMessage)
        {
            //// string path = AppDomain.CurrentDomain.BaseDirectory + @"马\";//创建公有登录文件夹
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);//判断路径存在性
            //DateTime time = DateTime.Now;
            string fileFullPath ="Table.txt";//每日文件
            StringBuilder str = new StringBuilder();//定义字符串数据集

            str.Append(strMessage);//定义书写内容
            StreamWriter sw;


            sw = File.CreateText(fileFullPath);//创建这个文件

            sw.WriteLine(str.ToString());//追加响应数据
            sw.Close();//数据流关闭
        }
        List<String> Ro = new List<string>(File.ReadAllLines("Table.txt"));
        string tablenum;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "WarmColor2.ssk";
            if (!File.Exists("Table.txt"))
            {
                string result = Microsoft.VisualBasic.Interaction.InputBox("请输入餐桌号", "锁定餐桌", "", this.Left, this.Top);
                WriteStart(result);
            }
            tablenum=Ro[0];
            pictureBox1.Hide();
        }
    }
}
