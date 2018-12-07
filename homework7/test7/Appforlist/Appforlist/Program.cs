using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace List
{
    //异常类
    class MyException : ApplicationException { }
    public class Order
    {
        //订单号 客户名称 订单明细
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public List<OrderDetails> ListOfDetails = new List<OrderDetails>();
    }

    public class OrderDetails
    {
        // 商品名称 商品数目 商品单价
        public string GoodsName { get; set; }
        public int GoodsNumber { get; set; }
        public double Money { get; set; }
    }

    public class OrderService
    {
        //订单增加 删减 修改 查询 异常处理
        public List<Order> orders = new List<Order>();
        //输入订单及明细
        public void cin()
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
        //显示订单
        public void show(Order od)
        {
            Console.WriteLine("订单号:" + od.OrderNumber);
            Console.WriteLine("客户名称:" + od.CustomerName);
            foreach (OrderDetails d in od.ListOfDetails)
            {
                Console.WriteLine("商品名称:" + d.GoodsName);
                Console.WriteLine("商品数目:" + d.GoodsNumber);
                Console.WriteLine("商品单价:" + d.Money);
            }
        }
        //修改订单
        private void CorrectOrder()
        {
            Console.WriteLine("请输入想要修改的订单号:");
            int num = int.Parse(Console.ReadLine());
            foreach (Order od in orders)
            {
                if (od.OrderNumber == num)
                {
                    Console.WriteLine("请选择想要修改的信息:1.订单号 2.客户名 3.订单内容");
                    int k = int.Parse(Console.ReadLine());
                    switch (k)
                    {
                        case 1:
                            int s1 = int.Parse(Console.ReadLine());
                            od.OrderNumber = s1; break;
                        case 2:
                            string s2 = Console.ReadLine();
                            od.CustomerName = s2; break;
                        case 3:
                            Console.WriteLine("请选择想要修改的信息:1.商品名称 2.商品数目 3.商品单价");
                            int ch = int.Parse(Console.ReadLine());
                            foreach (OrderDetails d in od.ListOfDetails)
                            {
                                switch (ch)
                                {
                                    case 1:
                                        Console.WriteLine("请输入修改后的商品名称:");
                                        string s3 = Console.ReadLine();
                                        d.GoodsName = s3;
                                        Console.WriteLine("修改成功!"); break;
                                    case 2:
                                        Console.WriteLine("请输入修改后的商品数目:");
                                        int s4 = int.Parse(Console.ReadLine());
                                        d.GoodsNumber = s4;
                                        Console.WriteLine("修改成功!"); break;
                                    case 3:
                                        Console.WriteLine("请输入修改后的商品价格:");
                                        double s5 = double.Parse(Console.ReadLine());
                                        d.Money = s5;
                                        Console.WriteLine("修改成功!"); break;
                                    default: Console.WriteLine("输入错误！"); break;
                                }
                            }
                            break;
                        default: Console.WriteLine("输入错误！"); break;
                    }

                }
                else
                {
                    Console.WriteLine("订单号不存在！");
                    CorrectOrder();
                }
            }
        }
        //查询订单
        private void QueryOrder()
        {
            try
            {
                bool b = false;
                Console.WriteLine("请选择你要查询的方法：1.订单号查询 2.客户名查询 3.查询总价50以上的订单");
                int k = int.Parse(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        Console.WriteLine("请输入订单号：");
                        int s1 = int.Parse(Console.ReadLine());
                        var m1 = from n in orders where n.OrderNumber == s1 select n;
                        foreach (var n in m1)
                        {
                            b = true;
                            this.show(n);
                        }
                        break;
                    case 2:
                        Console.WriteLine("请输入客户名：");
                        string s2 = Console.ReadLine();
                        var m2 = from n in orders where n.CustomerName == s2 select n;
                        foreach (var n in m2)
                        {
                            b = true;
                            this.show(n);
                        }
                        break;
                    case 3:
                        Console.WriteLine("总价超过50的订单号详情分别是:");
                        var m3 = from n in orders where n != null select n;
                        foreach (var n in m3)
                        {
                            var m4 = from m in n.ListOfDetails where m.GoodsNumber * m.Money > 50 select m;
                            foreach (var m in m4)
                            {
                                b = true;
                                this.show(n);
                                Console.WriteLine("\n");
                            }
                        }
                        break;
                }
                if (b == false)
                {
                    throw new MyException();
                }
            }
            catch (MyException)
            {
                Console.WriteLine("不存在该订单，请重试");
                this.QueryOrder();
            }
        }
    }

}
namespace Appforlist
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
