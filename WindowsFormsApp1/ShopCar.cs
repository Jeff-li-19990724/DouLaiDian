using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QT;

namespace WindowsFormsApp1
{
    public partial class ShopCar : UserControl
    {
        public ShopCar()
        {
            InitializeComponent();
        }

        private void ShopCar_Load(object sender, EventArgs e)
        {

        }
        MDF_DouLaiDian dian = new MDF_DouLaiDian();
        private void button2_Click(object sender, EventArgs e)
        {
            var order = Form1.listsorder.FirstOrDefault(i => i.foodname == label1.Text && i.price == int.Parse(label2.Text));
            if (order!=null)
            {
                order.num++;
                return;
            }
            order = new OrderFoodList();
            var food = dian.FoodList.Find(int.Parse(label4.Text));
            // order.OrderID=
            order.price = food.Price;
            order.foodname = food.FoodName;
            order.num = 1;
            Form1.listsorder.Add(order);
            //label4.Text = label2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FoodInfo foodInfo = new FoodInfo(label4.Text);
            foodInfo.Show();
        }
    }
    public class OrderFoodList
    {
        [DisplayName("菜名")]
        public string foodname { get; set; }
        [DisplayName("单价")]
        public double price { set; get; }
        [DisplayName("数量")]
        public int num { get; set; }
    }
}
