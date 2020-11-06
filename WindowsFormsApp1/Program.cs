using CommonInfo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmMessageBox frm;
            string fileName = Application.StartupPath + "\\authorize.txt";
           //
            if (!File.Exists(fileName))
            {
                frm = new FrmMessageBox("尚未授权！", "系统提示", MessageBoxStyle.error);
                frm.ShowDialog();
                return;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string txt = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            //string str1 = CommonInfo.DESEncrypt.DesDecrypt(txt);
           // str1 = CommonInfo.MD5Hashing.MD5Decrypt(str1, "hbsrfid1");
            if (string.IsNullOrWhiteSpace(txt))
            {
                frm = new FrmMessageBox("该设备没有授权！", "系统提示", MessageBoxStyle.error);
                frm.ShowDialog();
                return;
            }
            if (!IsRegeditItemExist("software", "DouLaiDian"))//不存在该注册表项
            {
                frm = new FrmMessageBox("该设备没有授权！", "系统提示", MessageBoxStyle.error);
                frm.ShowDialog();
                return;
            }
            string registry= ReadFromRegistry();
            if(DESEncrypt.DesDecrypt(txt.Trim()).Equals(DESEncrypt.DesDecrypt(registry.Trim())))
            {
                Application.Run(new WelCome());
            }
            else
            {
                frm = new FrmMessageBox("该设备没有授权！", "系统提示", MessageBoxStyle.error);
                frm.ShowDialog();
                return;
            }
        }
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
        private static string ReadFromRegistry()
        {
            try
            {
                if (!IsRegeditItemExist("software", "DouLaiDian"))//不存在该注册表项
                {
                    return string.Empty;
                }
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"software\DouLaiDian", true);
                string info = rk.GetValue("DouLaiDian").ToString();
                return info;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
