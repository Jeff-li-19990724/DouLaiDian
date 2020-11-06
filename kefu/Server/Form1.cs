using SanNiuSignal;
using SocketClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ITxServer server = null;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                server = TxStart.startServer(int.Parse(textBox_port.Text));
                server.AcceptString += new TxDelegate<IPEndPoint, string>(acceptString);
                server.AcceptByte += new TxDelegate<IPEndPoint, byte[]>(acceptBytes);
                server.Connect += new TxDelegate<IPEndPoint>(connect);
                server.dateSuccess += new TxDelegate<IPEndPoint>(dateSuccess);
                server.Disconnection += new TxDelegate<IPEndPoint, string>(disconnection);
                server.EngineClose += new TxDelegate(engineClose);
                server.EngineLost += new TxDelegate<string>(engineLost);
                //server.BufferSize=12048;
                //server.FileLog = "C:\\test.txt";
                server.StartEngine();
                this.button1.Enabled = false;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void engineLost(string str)
        { MessageBox.Show(str); }

        private void dateSuccess(IPEndPoint ipEndPoint)
        {
            textBox_msg.Text = "已向" + ipEndPoint.ToString() + "发送成功";
        }
        private void disconnection(IPEndPoint ipEndPoint, string str)
        {
            show(ipEndPoint, "下线");
        }
        private void engineClose()
        {
            MessageBox.Show("服务器已关闭");
        }

        private void show(IPEndPoint ipEndPoint, string str)
        {
            label_zt.Text = ipEndPoint.ToString() + ":" + str;
            label_all.Text = "当前在线人数:" + this.server.ClientNumber.ToString();
        }

        private void connect(IPEndPoint ipEndPoint)
        {
            show(ipEndPoint, "上线");
        }

        private void acceptString(IPEndPoint ipEndPoint, string str)
        {
            //if()
            if(str.EndsWith("发来呼叫"))
            {
                CommonInfo.Win32.Voiced(str);
                WorkMusic();
            }
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), ipEndPoint.ToString(), str });
            this.listView1.Items.Insert(0, item);
        }
        public static void WorkMusic()
        {
            SoundPlayer sound = new SoundPlayer(Application.StartupPath + @"\风铃.wav");

            sound.Play();
        }
        private void acceptBytes(IPEndPoint ipEndPoint, byte[] bytes)
        {
            //MessageBox.Show(bytes.Length.ToString());
            //this.pictureBox1.Image = objectByte.ReadImage(bytes);
            //ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), ipEndPoint.ToString(), str });
            //this.listView1.Items.Insert(0, item);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPEndPoint client = (IPEndPoint)this.comboBox1.SelectedItem;
            if (client == null)
            {
                MessageBox.Show("没有选中任何在线客户端！");
                return;
            }

            if (!this.server.clientCheck(client))
            {
                MessageBox.Show("目标客户端不在线！");
                return;
            }
            server.clientClose(client);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint client = (IPEndPoint)this.comboBox1.SelectedItem;
                if (client == null)
                {
                    MessageBox.Show("没有选中任何在线客户端！");
                    return;
                }

                if (!this.server.clientCheck(client))
                {
                    MessageBox.Show("目标客户端不在线！");
                    return;
                }
                server.sendMessage(client, textBox_msg.Text);
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                List<IPEndPoint> list = this.server.ClientAll;
                this.comboBox1.DataSource = list;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Hide();
           // this.skinEngine1.SkinFile = "XPGreen.ssk";
            //this.skinEngine1.SkinFile = "MidsummerColor3.ssk";
            // this.skinEngine1.SkinFile = "WarmColor2.ssk";
        }
    }
}
