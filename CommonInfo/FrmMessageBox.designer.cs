namespace CommonInfo
{
    partial class FrmMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageBox));
            this.picICO = new System.Windows.Forms.PictureBox();
            this.labinfo = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.ButCancel = new CommonInfo.ButtonX();
            this.ButOK = new CommonInfo.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picICO
            // 
            this.picICO.BackColor = System.Drawing.Color.Transparent;
            this.picICO.Image = ((System.Drawing.Image)(resources.GetObject("picICO.Image")));
            this.picICO.Location = new System.Drawing.Point(19, 76);
            this.picICO.Name = "picICO";
            this.picICO.Size = new System.Drawing.Size(103, 100);
            this.picICO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picICO.TabIndex = 0;
            this.picICO.TabStop = false;
            // 
            // labinfo
            // 
            this.labinfo.BackColor = System.Drawing.Color.Transparent;
            this.labinfo.Font = new System.Drawing.Font("楷体", 21.75F);
            this.labinfo.ForeColor = System.Drawing.Color.Black;
            this.labinfo.Location = new System.Drawing.Point(127, 30);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(392, 92);
            this.labinfo.TabIndex = 41;
            this.labinfo.Text = "请输入密码";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.Controls.Add(this.ButCancel);
            this.panelEx1.Controls.Add(this.ButOK);
            this.panelEx1.Controls.Add(this.picICO);
            this.panelEx1.Controls.Add(this.labinfo);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(539, 295);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.SkyBlue;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 42;
            // 
            // ButCancel
            // 
            this.ButCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButCancel.BackColor = System.Drawing.Color.Transparent;
            this.ButCancel.Checked = false;
            this.ButCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButCancel.FlatAppearance.BorderSize = 0;
            this.ButCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ButCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ButCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButCancel.Font = new System.Drawing.Font("宋体", 16F);
            this.ButCancel.ForeColor = System.Drawing.Color.Black;
            this.ButCancel.Location = new System.Drawing.Point(360, 204);
            this.ButCancel.Name = "ButCancel";
            this.ButCancel.Size = new System.Drawing.Size(127, 61);
            this.ButCancel.TabIndex = 43;
            this.ButCancel.Text = "取消";
            this.ButCancel.UseVisualStyleBackColor = false;
            this.ButCancel.Click += new System.EventHandler(this.ButCancel_Click);
            // 
            // ButOK
            // 
            this.ButOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOK.BackColor = System.Drawing.Color.Transparent;
            this.ButOK.Checked = false;
            this.ButOK.FlatAppearance.BorderSize = 0;
            this.ButOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ButOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ButOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButOK.Font = new System.Drawing.Font("宋体", 16F);
            this.ButOK.ForeColor = System.Drawing.Color.Black;
            this.ButOK.Location = new System.Drawing.Point(131, 204);
            this.ButOK.Name = "ButOK";
            this.ButOK.Size = new System.Drawing.Size(127, 61);
            this.ButOK.TabIndex = 42;
            this.ButOK.Text = "确定";
            this.ButOK.UseVisualStyleBackColor = false;
            this.ButOK.Click += new System.EventHandler(this.ButOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(183, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "请输入密码";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(298, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 26);
            this.textBox1.TabIndex = 44;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMessageBox
            // 
            this.AcceptButton = this.ButOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButCancel;
            this.ClientSize = new System.Drawing.Size(539, 295);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picICO;
        private System.Windows.Forms.Label labinfo;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private CommonInfo.ButtonX ButCancel;
        private CommonInfo.ButtonX ButOK;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}