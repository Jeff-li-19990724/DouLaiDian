using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clock
{
    public partial class UserControl1 : UserControl
    {
        const int screenWidth = 200; //屏幕宽度
        const int screenHeight = 200; //屏幕高度
        public UserControl1()
        {
            InitializeComponent();

            this.Width = screenWidth + 1;//防贴边
            this.Height = screenHeight + 1;
            this.DoubleBuffered = true; //控件缓冲，避免闪烁——解决重绘频闪
            this.SetStyle(ControlStyles.ResizeRedraw, true);
          //  this.SetStyle(ControlStyles.Do, true);
            timer1.Start();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //窗体重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            string dayOfWeek = dtNow.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));//星期几
            Brush brush = new SolidBrush(Color.Black); //填充图形
            Pen pen = new Pen(Color.Black); //画笔
            Font hourFont = new Font("隶书", 10, FontStyle.Bold);//时钟数字的字体
            Font dateFont = new Font("楷体", 9); //日期的字体Arial
            int dialRadius = Math.Min(screenWidth, screenHeight) / 2; //圆的半径——获取宽高之中较小的一个为直径

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//去除锯齿

            //默认坐标系统原点是左上角，现在把原点移到屏幕中心, 右下左上对应的轴：x,y,-x,-y
            g.TranslateTransform(dialRadius, dialRadius);

            //画时钟最外层的圆线(pen,x,y,width,height)
            //圆的中心点坐标计算：(width/2+x,height/2+y),据此可得出要使圆在坐标原点(0,0)的x,y坐标值
            //原点在屏幕中心，确定起点在屏幕左上方点
            g.DrawEllipse(pen, -screenWidth / 2, -dialRadius, screenWidth, screenHeight);

            GraphicsState state = g.Save();//标记画笔位置等状态
           // Gra
            //画矩形、日期、星期几       
            int rectWidth = 70;
            int rectHeight = 30;
            g.DrawRectangle(pen, -rectWidth / 2, rectHeight, rectWidth, rectHeight);
            g.DrawString(dtNow.ToString("yyyy-MM-dd"), dateFont, brush, -rectWidth / 2, rectHeight + 2);
            g.DrawString(dayOfWeek.PadLeft(8, ' '), dateFont, brush, -rectWidth / 2, rectHeight + 15);
            g.Restore(state);//画笔复位

            // 画时钟的60个圆点
            //Save(),Restore(state)配合使用，使得平移、缩放、旋转等操作只对它们作用域之间的代码有效，
            //save开始到restore之间这绘画，就像有绘制了一个图层，restore之后将两个图层放到一起
            state = g.Save();
            for (int i = 0; i < 60; i++)
            {
                int w = i % 5 == 0 ? 5 : 3;//判断是否是5的倍数
                g.FillEllipse(brush, 0, -dialRadius, w, w);
                //围绕指定点按照顺时针方向旋转角度360 / 60 = 6度
                g.RotateTransform(6);
            }
            g.Restore(state);

            //画时钟的12个数字，如果用上面RotateTransform方法则数字会倾斜、倒立，故不用
            state = g.Save();
            for (int i = 0; i < 12; i++)
            {
                //已知圆中心占坐标(x0,y0),半径r，角度a0,则圆上任一点坐标（x,y）计算：
                //x = x0 + r * cos(ao * 3.14 /180) 
                //y = y0 + r * sin(ao * 3.14 /180) 
                Point point = new Point(-6, -6); //当为(0,0)时全部数字偏右下移，故手动调整
                double dd = Math.PI / 180 * i * (360 / 12); //每次转360/12度
                float x = point.X + (float)((dialRadius - 12) * Math.Cos(dd));
                float y = point.Y + (float)((dialRadius - 12) * Math.Sin(dd));

                //因为是从顺时钟3点钟开始画，所以索引i需要加上3
                int j = i + 3;
                if (j > 12)
                    j -= 12;
                g.DrawString(j.ToString(), hourFont, brush, x, y);
            }
            g.Restore(state);

            // 画时针的图形
            state = g.Save();

            g.RotateTransform((dtNow.Hour - 12 + dtNow.Minute / 60f) * 360f / 12f);//旋转一定的角度——计算当前小时与当前分钟——每小时三十度
            //时钟指针默认指向12点钟方向,分钟指针也一样
            g.DrawPolygon(new Pen(brush), new Point[]
            {
                new Point(0,  20), new Point( 10, 0),
                new Point(0, -60), new Point(-10, 0)
            });
            g.Restore(state);

            // 画分针的图形
            state = g.Save();
            g.RotateTransform((dtNow.Minute + dtNow.Second / 60f) * 360f / 60f);//旋转一定的角度——每分钟6度
            g.DrawPolygon(new Pen(brush), new Point[]
            {
                new Point(0,  20), new Point( 6, 0),
                new Point(0, -80), new Point(-6, 0)
            });
            g.Restore(state);
           
            // 画秒针的图形
            state = g.Save();
            g.RotateTransform(dtNow.Second * 360f / 60f);
            g.FillRectangle(brush, -1, -dialRadius + 10, 2, dialRadius);
            g.Restore(state);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();//时刻调动窗体重绘
        }
    }
}
