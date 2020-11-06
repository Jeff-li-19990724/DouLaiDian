using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Calculator
{
    public partial class history : Form
    {
        private List<Data> list;
        
        public history(List<Data> list)
        {
            this.list = list;
            InitializeComponent();
        }
        private void history_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = list;
        }
    }
}
