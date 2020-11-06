namespace _Calculator
{
    partial class history
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.num1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jieguo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num1,
            this.fuhao,
            this.num2,
            this.jieguo});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(444, 223);
            this.dataGridView1.TabIndex = 0;
            // 
            // num1
            // 
            this.num1.DataPropertyName = "num1";
            this.num1.HeaderText = "num1";
            this.num1.Name = "num1";
            this.num1.ReadOnly = true;
            // 
            // fuhao
            // 
            this.fuhao.DataPropertyName = "fuhao";
            this.fuhao.HeaderText = "符号";
            this.fuhao.Name = "fuhao";
            this.fuhao.ReadOnly = true;
            // 
            // num2
            // 
            this.num2.DataPropertyName = "num2";
            this.num2.HeaderText = "num2";
            this.num2.Name = "num2";
            this.num2.ReadOnly = true;
            // 
            // jieguo
            // 
            this.jieguo.DataPropertyName = "jieguo";
            this.jieguo.HeaderText = "jieguo";
            this.jieguo.Name = "jieguo";
            this.jieguo.ReadOnly = true;
            // 
            // history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 223);
            this.Controls.Add(this.dataGridView1);
            this.Name = "history";
            this.Text = "history";
            this.Load += new System.EventHandler(this.history_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn num2;
        private System.Windows.Forms.DataGridViewTextBoxColumn jieguo;
    }
}