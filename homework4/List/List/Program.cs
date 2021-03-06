﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            {   GoodsName = "salt",
                GoodsNumber = 5,
                Money = 10.0 };
            Order order1 = new Order
            {   OrderNumber = 111,
                CustomerName = "Tony" };
            order1.ListOfDetails.Add(od1);
            orders.Add(order1);

            OrderDetails od2 = new OrderDetails
            {   GoodsName = "paper",
                GoodsNumber = 4,
                Money = 1.0 };
            Order order2 = new Order
            {   OrderNumber = 112,
                CustomerName = "Lily" };
            order2.ListOfDetails.Add(od2);
            orders.Add(order2);

            OrderDetails od3 = new OrderDetails
            {   GoodsName = "pen",
                GoodsNumber = 2,
                Money = 5.0 };
            Order order3 = new Order
            {   OrderNumber = 113,
                CustomerName = "Mary" };
            order3.ListOfDetails.Add(od3);
            orders.Add(order3);
        }
        //系统启动
        public void fun()
        {
            Console.WriteLine("1.增加订单 2.删除订单 3.修改订单 4.查询订单");
            int i = int.Parse(Console.ReadLine());
            switch(i)
            {
                case 1:
                    this.NewOrder();
                    break;
                case 2:
                    this.DeleteOrder();
                    break;
                case 3:
                    this.CorrectOrder();
                    break;
                case 4:
                    this.QueryOrder();
                    break;
                default:
                    Console.WriteLine("输入有误！");
                    fun();
                    break;
            }
        }
        //增加订单
        private void NewOrder()
        {
            Console.WriteLine("请输入订单号:");
            int s1 = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入顾客名称:");
            string s2 = Console.ReadLine();
            Console.WriteLine("请输入商品名称:");
            string s3 = Console.ReadLine();
            Console.WriteLine("请输入商品数目:");
            int s4 = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入商品单价:");
            int s5 = int.Parse(Console.ReadLine());
            Order order4 = new Order
            {
                OrderNumber =s1,
                CustomerName = "s2"
            };
            OrderDetails od4 = new OrderDetails
            {
                GoodsName = "s3",
                GoodsNumber = s4 ,
                Money = s5
            };
            order4.ListOfDetails.Add(od4);
            orders.Add(order4);
            Console.WriteLine("订单添加成功！");
            fun();
        }
        //删除订单
        private void DeleteOrder()
        {
            Console.WriteLine("请输入您要删除的订单号:");
            int num = int.Parse(Console.ReadLine());
            foreach(Order od in orders)
            {
                if (od.OrderNumber==num)
                {
                    orders.Remove(od);
                    Console.WriteLine("删除成功！");
                    break;
                }
                else
                {
                    Console.WriteLine("订单号不存在");
                    DeleteOrder();
                    break;
                }
            }
            fun();
        }
        //修改订单
        private void CorrectOrder()
        {
            Console.WriteLine("请输入想要修改的订单号:");
            int num = int.Parse(Console.ReadLine());
            foreach(Order od in orders)
            {
                if(od.OrderNumber==num)
                {
                    Console.WriteLine("请选择想要修改的信息:1.订单号 2.客户名 3.订单内容");
                    int k=int.Parse(Console.ReadLine());
                    switch(k)
                    {
                        case 1:int s1 = int.Parse(Console.ReadLine());
                            od.OrderNumber = s1; break;
                        case 2:string s2 = Console.ReadLine();
                            od.CustomerName = s2; break;
                        case 3: Console.WriteLine("请选择想要修改的信息:1.商品名称 2.商品数目 3.商品单价");
                            int ch = int.Parse(Console.ReadLine());
                            foreach (OrderDetails d in od.ListOfDetails)
                            {
                                switch (ch)
                                {
                                    case 1:
                                        Console.WriteLine("请输入修改后的商品名称:");
                                        string s3 = Console.ReadLine();
                                        d.GoodsName= s3;
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
                                    default: Console.WriteLine("输入错误！");break;
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
            fun();
        }
        //查询订单
        private void QueryOrder()
        {
            try {
                bool b = false;
                Console.WriteLine("请选择你要查询的方法：1.订单号查询 2.客户名查询");
                int k = int.Parse(Console.ReadLine());
                switch(k)
                {
                    case 1:
                        Console.WriteLine("请输入订单号：");
                        int s1 = int.Parse(Console.ReadLine());
                        foreach (Order od in orders)
                        {
                            if (od.OrderNumber==s1)
                            {
                                b = true;
                                show(od);
                                Console.WriteLine("该订单存在！");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("请输入客户名：");
                        string s2 = Console.ReadLine();
                        foreach (Order od in orders)
                        {
                            if (od.CustomerName == s2)
                            {
                                b = true;
                                Console.WriteLine("该订单存在！");

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
            fun();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("您好，这里是订单服务系统");
            Console.WriteLine("请您选择需要的服务:");
            OrderService os = new OrderService();
            os.cin();
            os.fun();
        }
    }
}
