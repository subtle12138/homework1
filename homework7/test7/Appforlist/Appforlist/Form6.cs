using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using List;

namespace Appforlist
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public  List<Order> orders = new List<Order>();
        public  void myList()
        {

            OrderDetails od1 = new OrderDetails
            {
                GoodsName = "salt",
                GoodsNumber = 5,
                Money = 10.0
            };
            Order order1 = new Order
            {
                OrderNumber = 111,
                CustomerName = "Tony"
            };
            order1.ListOfDetails.Add(od1);
            orders.Add(order1);

            OrderDetails od2 = new OrderDetails
            {
                GoodsName = "paper",
                GoodsNumber = 4,
                Money = 1.0
            };
            Order order2 = new Order
            {
                OrderNumber = 112,
                CustomerName = "Lily"
            };
            order2.ListOfDetails.Add(od2);
            orders.Add(order2);

            OrderDetails od3 = new OrderDetails
            {
                GoodsName = "pen",
                GoodsNumber = 16,
                Money = 5.0
            };
            Order order3 = new Order
            {
                OrderNumber = 113,
                CustomerName = "Mary"
            };
            order3.ListOfDetails.Add(od3);
            orders.Add(order3);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = "您输入的订单号不存在！";
            myList();
            int ch = int.Parse(textBox1.Text);
            foreach (Order od in orders)
            {
                if (od.OrderNumber==ch)
                    foreach (OrderDetails d in od.ListOfDetails)
                    {
                        textBox2.Text = Convert.ToString(od.OrderNumber) + " "
                                        + od.CustomerName + " " + d.GoodsName + " " +
                                        d.GoodsNumber + " " + d.Money;
                    }           
                
            }
        }
    }
}
