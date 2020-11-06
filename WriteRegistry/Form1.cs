using CommonInfo;
using Microsoft.Win32;
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

namespace WriteRegistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string RoleList = Application.StartupPath + "\\RoleList.txt";
        private int x;
        List<String> Ro =new List<string>(File.ReadAllLines(RoleList));
        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            x = random.Next(0,Ro.Count()-1);
            
            List<string> list = CommonInfo.MACString.GetMacByIPConfig();
            comboBox1.DataSource = list;
            //foreach (string str in list)
            //{
            //    comboBox1.Items.Add(str.ToString());
            //}
        }
        private  void SaveRenewWaysToRegistry(string value)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser; //RegistryKey rk = Registry.LocalMachine;

                if (!IsRegeditItemExist("software", "DouLaiDian"))//如果不存在该注册表项则创建

                {

                    RegistryKey software = rk.CreateSubKey(@"software\DouLaiDian");
                    // rk.DeleteSubKey(@"software\UpdateMode");

                }
                //else
                //{
                //    rk.DeleteSubKey(@"software\DouLaiDian");
                //    RegistryKey software = rk.CreateSubKey(@"software\DouLaiDian");
                //}

                RegistryKey srk = rk.OpenSubKey(@"software\DouLaiDian", true);//.CreateSubKey(@"software\UpdateMode");

                srk.SetValue("DouLaiDian", value);
               
                //Console.WriteLine("注册表书写成功");
            }
            catch (Exception e)

            {
                Console.WriteLine(e.Message);
            }
        }
        //String value = this.ReadFromRegistry();//读取注册表项UpdateMode的内容

        private static bool IsRegeditItemExist(string subKey, string value)

        {

            string[] subkeyNames;

            RegistryKey hkml = Registry.CurrentUser;

            RegistryKey software = hkml.OpenSubKey(subKey);

            //RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);

            subkeyNames = software.GetSubKeyNames();

            //取得该项下所有子项的名称的序列，并传递给预定的数组中

            foreach (string keyName in subkeyNames)

            //遍历整个数组

            {

                if (keyName.Equals(value))

                //判断子项的名称

                {
                    hkml.Close();
                    return true;
                }
            }

            hkml.Close();

            return false;

        }
        private void ButOK_Click(object sender, EventArgs e)
        {
            string RoList = comboBox1.Text.Trim() + Ro[x].Trim();
            SaveRenewWaysToRegistry(DESEncrypt.DesEncrypt(RoList));
            FrmMessageBox frm = new FrmMessageBox("已完成授权，请联系管理员进行获取授权文件授权密钥为！" + comboBox1.Text.Trim()+"\t"+ x.ToString(), "系统提示", MessageBoxStyle.right);
            frm.ShowDialog();
        }
    }
}
