using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;

namespace CommonInfo
{
    public class Win32
    {
       /// <summary>
       /// 图片虚化
       /// </summary>
       /// <param name="newpath"></param>
       /// <returns></returns>
        public Bitmap GetBitmap(string newpath)
        {
            string path = newpath;
            Bitmap img;
            if (File.Exists(path))
            {
                img = new Bitmap(path);
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

                        bmpcolor = Color.FromArgb(130, R, Gt, B);
                        bmp.SetPixel(i, j, bmpcolor);
                    }
                }
                return bmp;
            }
            return null;
        }
        /// <summary>
        /// 读出自定义文字
        /// </summary>
        /// <param name="str">文字内容</param>
        public static void Voiced(string str)
        {
            SpeechSynthesizer hello = new SpeechSynthesizer();
            //hello.SetOutputToWaveFile(str);
            hello.Speak(str);
            hello.SetOutputToDefaultAudioDevice();
        }
        public void PassFile(string vbsFile)
        {
            //模拟单击文件
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(Application.StartupPath + vbsFile);//调用VBS文件实现语音提示
            p.WaitForExit();
        }
        /// Win32.AnimateWindow(this.Handle, 3000, Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_BLEND);//窗体淡出
        ///  Win32.AnimateWindow(this.Handle, 1500, Win32.AW_BLEND);//窗体淡入
        /// <summary>
        /// 窗体居中
        /// </summary>
        /// <param name="form">窗体是哪个一般情况话等于this就可以</param>
        public static void SetMid(Form form)
        {
            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
                (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
                form.Width, form.Height, BoundsSpecified.Location);
        }//窗体居中交互方法
        public const Int32 AW_HOR_POSITIVE = 0x00000001; // 从左到右打开窗口
        public const Int32 AW_HOR_NEGATIVE = 0x00000002; // 从右到左打开窗口
        public const Int32 AW_VER_POSITIVE = 0x00000004; // 从上到下打开窗口
        public const Int32 AW_VER_NEGATIVE = 0x00000008; // 从下到上打开窗口
        public const Int32 AW_CENTER = 0x00000010; //若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        public const Int32 AW_HIDE = 0x00010000; //隐藏窗口，缺省则显示窗口。
        public const Int32 AW_ACTIVATE = 0x00020000; //激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
        public const Int32 AW_SLIDE = 0x00040000; //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        public const Int32 AW_BLEND = 0x00080000; //使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(
      IntPtr hwnd, // handle to window
          int dwTime, // duration of animation
          int dwFlags // animation type
          );

    }
}
