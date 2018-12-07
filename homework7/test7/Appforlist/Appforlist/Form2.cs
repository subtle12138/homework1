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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public List<Order> orders = new List<Order>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool b = false;
                OrderService os = new OrderService();
                os.cin();
                int s1 = int.Parse(textBox1.Text);
                string s2 = textBox2.Text;
                string s3 = textBox3.Text;
                int s4 = int.Parse(textBox4.Text);
                double s5 = double.Parse(textBox5.Text);
                Order order4 = new Order
                {
                    OrderNumber = s1,
                    CustomerName = "s2"
                };
                OrderDetails od4 = new OrderDetails
                {
                    GoodsName = "s3",
                    GoodsNumber = s4,
                    Money = s5
                };
                order4.ListOfDetails.Add(od4);
                orders.Add(order4);
                b = true;
                label7.Text = "添加成功!";
                if (b == false)
                {
                    throw new MyException();
                }
            }
            catch (MyException)
            {
                label7.Text="信息输入有误，请重试！";
            }
        }
    }
}
