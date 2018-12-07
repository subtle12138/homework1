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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public List<Order> orders = new List<Order>();
        public void myList()
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
            label2.Text = "您输入的订单号不存在！";
            myList();
            int ch = int.Parse(textBox1.Text);
            foreach (Order od in orders)
            {
                if (od.OrderNumber == ch)
                {
                    label2.Text = "为你找到如下订单，请在右侧输入修改后的信息:";
                    textBox2.Text = Convert.ToString(od.OrderNumber);
                    textBox3.Text = od.CustomerName;
                    foreach (OrderDetails d in od.ListOfDetails)
                    {
                        textBox4.Text = d.GoodsName;
                        textBox5.Text = Convert.ToString(d.GoodsNumber);
                        textBox6.Text = Convert.ToString(d.Money);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(textBox2.Text);
            string s2 = textBox3.Text;
            string s3 = textBox4.Text;
            int s4= int.Parse(textBox5.Text);
            double s5= int.Parse(textBox6.Text);
            myList();
            int ch = int.Parse(textBox1.Text);
            foreach (Order od in orders)
            {
                if (od.OrderNumber == ch)
                {
                    od.OrderNumber=s1;
                    od.CustomerName=s2;
                    foreach (OrderDetails d in od.ListOfDetails)
                    {
                        d.GoodsName=s3;
                        d.GoodsNumber=s4;
                        d.Money=s5;
                    }
                    label8.Text = "修改成功！";
                }
            }
        }
    }
}
