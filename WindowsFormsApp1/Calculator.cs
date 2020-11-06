using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// 下载于www.mycodes.net
namespace _Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.menuStrip1.Hide();
           textBox1.Text = "0";
           list = new List<Data>();
        } 
        string flag;
        string[] strArr1 = new string[2];
        List<Data> list;
        string lastBtn;
        bool Flag = false; bool flagg = true; //bool firTime = true; double c;
     
        #region 数字键 
        private void btn7_Click(object sender, EventArgs e)
        {
            if (Flag )
            { textBox1.Text = "7"; Flag = false;  }
            else if (textBox1.Text != "0")
             textBox1.Text += "7"; 
            else textBox1.Text = "7";
            lastBtn = "666";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (Flag )
            { textBox1.Text = "8"; Flag = false; } 
            else if (textBox1.Text != "0")
            textBox1.Text += "8";
            else  textBox1.Text = "8";
            lastBtn = "666";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (Flag)
            { textBox1.Text = "9"; Flag = false; } 
            else    if (textBox1.Text != "0")
            textBox1.Text += "9";
            else  textBox1.Text = "9";
            lastBtn = "666";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (Flag )
            { textBox1.Text = "4"; Flag = false; } 
            else  if (textBox1.Text != "0")
                textBox1.Text += "4";
                else textBox1.Text = "4";
            lastBtn = "666";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (Flag)
            { textBox1.Text = "5"; Flag = false; } 
            else  if (textBox1.Text != "0")
              textBox1.Text += "5";
            else textBox1.Text = "5";
            lastBtn = "666";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (Flag)
            { textBox1.Text = "6"; Flag = false; } 
            else  if (textBox1.Text != "0")
                textBox1.Text += "6";
            else  textBox1.Text = "6";
            lastBtn = "666";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (Flag )
            { textBox1.Text = "1"; Flag = false; } 
            else if (textBox1.Text != "0")
                textBox1.Text += "1";
                else textBox1.Text = "1";
            lastBtn = "666";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (Flag)
            { textBox1.Text = "2"; Flag = false; } 
            else if (textBox1.Text != "0")
                textBox1.Text += "2";
                else textBox1.Text = "2";
            lastBtn = "666";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (Flag)
            { textBox1.Text = "3"; Flag = false; } 
            else  if (textBox1.Text != "0")
                textBox1.Text += "3";
            else textBox1.Text = "3";
            lastBtn = "666";
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if (Flag )
            { textBox1.Text = "0"; Flag = false; } 
            else if (textBox1.Text != "0")
              textBox1.Text += "0";
            lastBtn = "666";
        }
        #endregion  
        #region 小数点、取相反数及归0键
        private void btnDot_Click(object sender, EventArgs e)
        {
            while (textBox1.Text.IndexOf(".") <= -1)
                textBox1.Text += ".";
            lastBtn = "666";
        }
        private void btn加正负号_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) > 0)//如果数据窗口中的数据大于0则添加负号
            {
                textBox1.Text = "-" + textBox1.Text;//添加负号
            }
            else if (Convert.ToDouble(textBox1.Text) < 0)//如果数据窗口中的数据小于0则去掉负号
            {
                textBox1.Text = textBox1.Text.Substring(1);//取子串
            }
            lastBtn = "666";
        }
        private void btnC_Click(object sender, EventArgs e)
        {

            textBox1.Text = "0";
            string[] strArr1 = new string[2];
            Flag = false; flagg = true;
            lastBtn = "666";
        }
        #endregion  
        #region 加法   
        private void btnadd_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            switch (flag)
            {
                default:
                case "+":

                    if (lastBtn == "10086") return;//多次按+号只响应一次的操作
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) + Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "+";
                            list.Add(data);
                        }
                        flag = "+";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "-":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) - Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "-";
                            list.Add(data);
                        }
                        flag = "+";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "×":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) * Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "×";
                            list.Add(data);
                        }
                        flag = "+";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "÷":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) / Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "÷";
                                list.Add(data);
                            }
                        }
                        flag = "+";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "%":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; MessageBox.Show("除数不能为0！"); }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) % Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "%";
                                list.Add(data);
                            }
                        }
                        flag = "+";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
            }

            //if (diyici)
            //{
            //    c = Convert.ToDouble(textBox1.Text);//置操作数1
            //    diyici = false;//置运算符为非第一次单击
            //}
            //else
            //{
            //    c += Convert.ToDouble(textBox1.Text);//执行加功能
            //    textBox1.Text = c.ToString();//显示结果
            //}
            //flag = "+";
        }
        #endregion
        #region 减法   
        private void btnsubtract_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            switch (flag)
            {
                default:
                case "-":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) - Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "-";
                            list.Add(data);
                        }
                        flag = "-";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "+":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) + Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "+";
                            list.Add(data);
                        }
                        flag = "-";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "×":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) * Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "×";
                            list.Add(data);
                        }
                        flag = "-";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "÷":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) / Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "÷";
                                list.Add(data);
                            }
                        }
                        flag = "-";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "%":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; MessageBox.Show("除数不能为0！"); }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) % Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "%";
                                list.Add(data);
                            }
                        }
                        flag = "-";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
            }
        }
        #endregion
        #region 乘法   
        private void btnmultiplication_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            switch (flag)
            {
                default:
                case "×":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) * Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "×";
                            list.Add(data);
                        }
                        flag = "×";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "÷":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) / Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "÷";
                            list.Add(data);
                        }
                        flag = "×";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "+":

                    if (lastBtn == "10086") return;//多次按+号只响应一次的操作
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) + Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "+";
                            list.Add(data);
                        }
                        flag = "×";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "-":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) - Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "-";
                            list.Add(data);
                        }
                        flag = "×";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "%":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; MessageBox.Show("除数不能为0！"); }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) % Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "%";
                                list.Add(data);
                            }
                        }
                        flag = "×";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
            }
        }
       
        #endregion
        #region 除法   
        private void btndevision_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            switch (flag)
            {
                default:
                case "÷":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) / Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "÷";
                                list.Add(data);
                            }
                        }
                        flag = "÷";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "×":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) * Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "×";
                                list.Add(data);
                            }
                        }
                        flag = "÷";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "+":

                    if (lastBtn == "10086") return;//多次按+号只响应一次的操作
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) + Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "+";
                            list.Add(data);
                        }
                        flag = "÷";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "-":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) - Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "-";
                            list.Add(data);
                        }
                        flag = "÷";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "%":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; MessageBox.Show("除数不能为0！"); }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) % Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "%";
                                list.Add(data);
                            }
                        }
                        flag = "÷";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
            }
        }
        #endregion      
        #region 取余   
        private void btn取余_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            switch (flag)
            {
                default:
                case "%":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; MessageBox.Show("除数不能为0！"); }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) % Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "%";
                                list.Add(data);
                            }
                        }
                        flag = "%";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "÷":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) / Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "÷";
                                list.Add(data);
                            }
                        }
                        flag = "%";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "×":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            if (textBox1.Text == "0") { strArr1[1] = strArr1[0]; textBox1.Text = "除数不能为0！"; }
                            else
                            {
                                textBox1.Text = (Convert.ToDouble(strArr1[0]) * Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                                strArr1[1] = textBox1.Text;
                                data.Fuhao = "×";
                                list.Add(data);
                            }
                        }
                        flag = "%";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "+":

                    if (lastBtn == "10086") return;//多次按+号只响应一次的操作
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) + Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "+";
                            list.Add(data);
                        }
                        flag = "%";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
                case "-":
                    if (lastBtn == "10086") return;
                    else
                    {
                        Flag = true;
                        if (flagg)
                        {
                            strArr1[1] = textBox1.Text;
                            flagg = false;
                        }
                        else
                        {
                            strArr1[0] = strArr1[1]; data.Num1 = strArr1[0];
                            strArr1[1] = textBox1.Text; data.Num2 = strArr1[1];
                            textBox1.Text = (Convert.ToDouble(strArr1[0]) - Convert.ToDouble(strArr1[1])).ToString(); data.Jieguo = textBox1.Text;
                            strArr1[1] = textBox1.Text;
                            data.Fuhao = "-";
                            list.Add(data);
                        }
                        flag = "%";
                        Flag = true;//按符号后下一次输入清空
                        lastBtn = "10086";
                    }
                    break;
            }

        }
        
        #endregion
        #region 等于号 
        private void btnEqual_Click(object sender, EventArgs e)
        {
           
            switch (flag)
            {
                case "+": btnadd_Click(sender, e); break;
                case "-": btnsubtract_Click(sender, e); break;
                case "×": btnmultiplication_Click(sender, e); break;
                case "÷":btndevision_Click(sender,  e);break;
                case "%": btn取余_Click(sender, e); break;
            }
            flagg = true; //重置第一次输入
            lastBtn = "666";//判断按键不重复

        }
        #endregion
        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
       {
            history his = new history(list);
            his.ShowDialog();
        }





































        #region boring
        //string a, b;
        //private void Form1_KeyDown(object sender, KeyEventArgs e)//定义两个label临时显示lb_01,lb_02
        //{

        //    if (e.KeyCode == Keys.Add)
        //    {
        //        flag = "1"; //lb_01.Text 
        //        a = textBox1.Text;
        //        textBox1.Text = (int.Parse(//lb_01.Text
        //           a) + int.Parse(//lb_02.Text
        //          b)).ToString();//lb_02.Text
        //        b = textBox1.Text;
        //    }
        //    else
        //    {
        //        if (flag == "1") { textBox1.Text = ""; }
        //        textBox1.Text += ((char)e.KeyValue).ToString();
        //    }
        //}

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//******
        //{
        //    if ((int)e.KeyChar <= 32)  // 特殊键(含空格), 不处理
        //    {
        //        return;
        //    }
        //    if (!char.IsDigit(e.KeyChar))  // 非数字键, 放弃该输入
        //    {
        //        e.Handled = true;
        //        return;
        //    }
        //}
        #endregion

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
