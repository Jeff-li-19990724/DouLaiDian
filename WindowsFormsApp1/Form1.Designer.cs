namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonX1 = new CommonInfo.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.userControl11 = new Clock.UserControl1();
            this.shopCar8 = new WindowsFormsApp1.ShopCar();
            this.shopCar7 = new WindowsFormsApp1.ShopCar();
            this.shopCar6 = new WindowsFormsApp1.ShopCar();
            this.shopCar5 = new WindowsFormsApp1.ShopCar();
            this.shopCar4 = new WindowsFormsApp1.ShopCar();
            this.shopCar3 = new WindowsFormsApp1.ShopCar();
            this.shopCar2 = new WindowsFormsApp1.ShopCar();
            this.shopCar1 = new WindowsFormsApp1.ShopCar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 891);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "首页";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 891);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "尾页";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 891);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "上一页";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(763, 891);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "下一页";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(691, 891);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1540, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "川菜";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Type_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1669, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "苏菜";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Type_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1540, 143);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 15;
            this.button3.Text = "粤菜";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Type_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1669, 143);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 29);
            this.button4.TabIndex = 16;
            this.button4.Text = "闽菜";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Type_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1648, 279);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 29);
            this.button5.TabIndex = 17;
            this.button5.Text = "其他菜品查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1540, 285);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 23);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1528, 330);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 25);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1669, 326);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(127, 29);
            this.button6.TabIndex = 20;
            this.button6.Text = "菜品名称查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(916, 888);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 25);
            this.textBox2.TabIndex = 21;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1077, 885);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 29);
            this.button7.TabIndex = 22;
            this.button7.Text = "跳转";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1540, 54);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(229, 29);
            this.button8.TabIndex = 23;
            this.button8.Text = "全部菜品";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.Location = new System.Drawing.Point(1528, 700);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(268, 112);
            this.button9.TabIndex = 24;
            this.button9.Text = "购物清单";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.BackColor = System.Drawing.Color.Transparent;
            this.buttonX1.Checked = false;
            this.buttonX1.FlatAppearance.BorderSize = 0;
            this.buttonX1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonX1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonX1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX1.ForeColor = System.Drawing.Color.Black;
            this.buttonX1.Location = new System.Drawing.Point(1603, 15);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(100, 29);
            this.buttonX1.TabIndex = 25;
            this.buttonX1.Text = "一键占用";
            this.buttonX1.UseVisualStyleBackColor = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1528, 840);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 100);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1669, 217);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 29);
            this.button10.TabIndex = 31;
            this.button10.Text = "鲁菜";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Type_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1540, 217);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 29);
            this.button11.TabIndex = 30;
            this.button11.Text = "徽菜";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Type_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(1669, 180);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(100, 29);
            this.button12.TabIndex = 29;
            this.button12.Text = "湘菜";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Type_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1540, 180);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(100, 29);
            this.button13.TabIndex = 28;
            this.button13.Text = "浙菜";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Type_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(1528, 397);
            this.userControl11.Margin = new System.Windows.Forms.Padding(5);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(268, 251);
            this.userControl11.TabIndex = 26;
            // 
            // shopCar8
            // 
            this.shopCar8.Location = new System.Drawing.Point(1131, 431);
            this.shopCar8.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar8.Name = "shopCar8";
            this.shopCar8.Size = new System.Drawing.Size(355, 409);
            this.shopCar8.TabIndex = 7;
            // 
            // shopCar7
            // 
            this.shopCar7.Location = new System.Drawing.Point(768, 431);
            this.shopCar7.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar7.Name = "shopCar7";
            this.shopCar7.Size = new System.Drawing.Size(355, 409);
            this.shopCar7.TabIndex = 6;
            // 
            // shopCar6
            // 
            this.shopCar6.Location = new System.Drawing.Point(405, 431);
            this.shopCar6.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar6.Name = "shopCar6";
            this.shopCar6.Size = new System.Drawing.Size(355, 409);
            this.shopCar6.TabIndex = 5;
            // 
            // shopCar5
            // 
            this.shopCar5.Location = new System.Drawing.Point(16, 431);
            this.shopCar5.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar5.Name = "shopCar5";
            this.shopCar5.Size = new System.Drawing.Size(355, 409);
            this.shopCar5.TabIndex = 4;
            // 
            // shopCar4
            // 
            this.shopCar4.Location = new System.Drawing.Point(1131, 15);
            this.shopCar4.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar4.Name = "shopCar4";
            this.shopCar4.Size = new System.Drawing.Size(355, 409);
            this.shopCar4.TabIndex = 3;
            // 
            // shopCar3
            // 
            this.shopCar3.Location = new System.Drawing.Point(768, 15);
            this.shopCar3.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar3.Name = "shopCar3";
            this.shopCar3.Size = new System.Drawing.Size(355, 409);
            this.shopCar3.TabIndex = 2;
            // 
            // shopCar2
            // 
            this.shopCar2.Location = new System.Drawing.Point(405, 15);
            this.shopCar2.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar2.Name = "shopCar2";
            this.shopCar2.Size = new System.Drawing.Size(355, 409);
            this.shopCar2.TabIndex = 1;
            // 
            // shopCar1
            // 
            this.shopCar1.Location = new System.Drawing.Point(16, 15);
            this.shopCar1.Margin = new System.Windows.Forms.Padding(5);
            this.shopCar1.Name = "shopCar1";
            this.shopCar1.Size = new System.Drawing.Size(355, 409);
            this.shopCar1.TabIndex = 0;
            this.shopCar1.Load += new System.EventHandler(this.shopCar1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 941);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shopCar8);
            this.Controls.Add(this.shopCar7);
            this.Controls.Add(this.shopCar6);
            this.Controls.Add(this.shopCar5);
            this.Controls.Add(this.shopCar4);
            this.Controls.Add(this.shopCar3);
            this.Controls.Add(this.shopCar2);
            this.Controls.Add(this.shopCar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "菜品清单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ShopCar shopCar1;
        private ShopCar shopCar2;
        private ShopCar shopCar3;
        private ShopCar shopCar4;
        private ShopCar shopCar5;
        private ShopCar shopCar6;
        private ShopCar shopCar7;
        private ShopCar shopCar8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        public CommonInfo.ButtonX buttonX1;
        private Clock.UserControl1 userControl11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
    }
}

