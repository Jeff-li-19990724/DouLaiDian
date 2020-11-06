using CommonInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButOK_Click(object sender, EventArgs e)
        {
            string RoList = textBox1.Text.Trim() + Ro[int.Parse(textBox2.Text.Trim())].Trim();
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK)
            {
                string path = dilog.SelectedPath;
                WriteStart(DESEncrypt.DesEncrypt(RoList),  path);
               // File.WriteAllLines(path + "horse.txt", (DESEncrypt.DesEncrypt(RoleList)));//单次比赛，每次覆盖


            }
            //SaveFileDialog op = new SaveFileDialog();
            //op.FileName = "authorize.txt";
            //op.pa
            //SaveRenewWaysToRegistry(DESEncrypt.DesEncrypt(RoleList));
           // FrmMessageBox frm = new FrmMessageBox("已完成授权，请联系管理员进行获取授权文件授权密钥为！" + comboBox1.Text.Trim() + x.ToString(), "系统提示", MessageBoxStyle.error);
           // frm.ShowDialog();
        }
        private static string RoleList = Application.StartupPath + "\\RoleList.txt";
        
        List<String> Ro = new List<string>(File.ReadAllLines(RoleList));
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void WriteStart(string strMessage,string path)
        {
           // string path = AppDomain.CurrentDomain.BaseDirectory + @"马\";//创建公有登录文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);//判断路径存在性
            //DateTime time = DateTime.Now;
            string fileFullPath = path+@"\"  + "authorize.txt";//每日文件
            StringBuilder str = new StringBuilder();//定义字符串数据集

            str.Append(strMessage);//定义书写内容
            StreamWriter sw;
            
            
            sw = File.CreateText(fileFullPath);//创建这个文件
           
            sw.WriteLine(str.ToString());//追加响应数据
            sw.Close();//数据流关闭
        }

    }
}
