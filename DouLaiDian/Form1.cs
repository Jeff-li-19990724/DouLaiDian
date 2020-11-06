using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouLaiDian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // DouLaiDian.MDF_DouLaiDian dian = new MDF_DouLaiDian();
       MDF_DouLaiDian mDF = new MDF_DouLaiDian();
        //MDF_DouLaiDian.Migrations Migrations

       // MDF_DouLaiDian mDF = new MDF_DouLaiDian();
        private void Form1_Load(object sender, EventArgs e)
        {
            Role roles = new Role();
            roles.RoleName = "chao";
            mDF.Roles.Add(roles);
            //MDF_DouLaiDian.Role 
           // mDF.Users = new MDF_DouLaiDian.MDF_DouLaiDian.User();
        }
    }
}
