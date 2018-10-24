using System.Collections.Generic;
using System;
namespace HomeWork4._2
{
    public class Order
    {
        public List<OrderDetails> ListOfProduct = new List<OrderDetails>();
        public String OrderNum { set; get; }
        public String Customer { set; get; }
    }
    public class OrderDetails
    {
        public String TypeOfProduct { set; get; }
        public int AmountOfProduct { set; get; }
    }
    public class OrderService
    {
        public List<Order> ListOfOrder = new List<Order>();

        //添加新订单
        private void NewOrder()
        {
            Order temp = new Order();
            Console.Write("输入客户名： ");
            temp.Customer = Console.ReadLine();
            Console.Write("输入订单号： ");
            temp.OrderNum = Console.ReadLine();
            int Type = 0;
            Console.Write("请输入订单中商品种类： ");
            while (Type == 0)
            {
                try
                {
                    Type = int.Parse(Console.ReadLine());
                    if (Type <= 0) throw new System.FormatException();
                }
                catch (System.FormatException e)
                {
                    Type = 0;
                    Console.Write(e.Message);
                    Console.WriteLine("请重新输入： ");
                }
            }

            for (int nType = 0; nType < Type; nType++)
            {
                OrderDetails detail = new OrderDetails();
                Console.Write("请输入第" + (nType + 1) + "种商品名称： ");
                detail.TypeOfProduct = Console.ReadLine();
                Console.Write("请输入商品数目： ");
                detail.AmountOfProduct = -1;
                while (detail.AmountOfProduct == -1)
                {
                    try
                    {
                        detail.AmountOfProduct = int.Parse(Console.ReadLine());
                        if (detail.AmountOfProduct <= 0) throw new System.FormatException();
                    }
                    catch (System.FormatException e)
                    {
                        detail.AmountOfProduct = -1;
                        Console.Write(e.Message);
                        Console.WriteLine("请重新输入：");
                    }
                }

                temp.ListOfProduct.Add(detail);
            }
            ListOfOrder.Add(temp);
        }

        //根据客户查找
        private List<Order> SearchByCustomer(String NameOfCustomer)
        {
            List<Order> result = new List<Order>();
            foreach (Order ele in ListOfOrder)
            {
                if (ele.Customer == NameOfCustomer) result.Add(ele);
            }
            return result;
        }
        //根据订单号查找
        private List<Order> SearchByNum(String NumOfPro)
        {
            List<Order> result = new List<Order>();
            foreach (Order ele in ListOfOrder)
            {
                if (ele.OrderNum == NumOfPro) result.Add(ele);
            }
            return result;
        }
        //根据产品种类查找
        private List<Order> SearchByPro(String NameOfProduct)
        {
            List<Order> result = new List<Order>();
            foreach (Order ele in ListOfOrder)
            {
                foreach (OrderDetails product in ele.ListOfProduct)
                    if (product.TypeOfProduct == NameOfProduct) result.Add(ele);
            }
            return result;
        }

        //搜索操作
        private void SearchOrder()
        {
            List<Order> SearchResult = new List<Order>();
            Console.WriteLine
                ("选择您要进行的服务: 1.根据客户查找； 2.根据订单号查找；3.根据产品种类查找；4.返回主菜单");
            int whichFun = 0;
            while (whichFun == 0)
            {
                try
                {
                    whichFun = int.Parse(Console.ReadLine());
                    if (whichFun < 1 || whichFun > 4) throw new System.FormatException();
                }
                catch (System.FormatException e)
                {
                    whichFun = 0;
                    Console.Write(e.Message);
                    Console.WriteLine("请重新输入");
                }
            }
            switch (whichFun)
            {
                case 1:
                    Console.WriteLine("输入客户名: ");
                    String CustomerName = Console.ReadLine();
                    SearchResult = SearchByCustomer(CustomerName);
                    break;
                case 2:
                    Console.WriteLine("输入订单号: ");
                    String OrderNum = Console.ReadLine();
                    SearchResult = SearchByNum(OrderNum);
                    break;
                case 3:
                    Console.WriteLine("输入产品名: ");
                    String ProductName = Console.ReadLine();
                    SearchResult = SearchByPro(ProductName);
                    break;
                case 4:
                    return;

            }
            try
            {
                WriteResult(SearchResult);
            }
            catch (NoSearchResult e)
            {
                Console.WriteLine(e.NoResult);
            }

        }
        //输出搜索结果
        private void WriteResult(List<Order> result)
        {
            if (result != null)
            {
                foreach (Order ele in result)
                {
                    Console.WriteLine("序号：" + result.FindIndex(a => a == ele) +
                        " 客户名：" + ele.Customer + " 订单号：" + ele.OrderNum);
                    foreach (OrderDetails pro in ele.ListOfProduct)
                    {
                        Console.WriteLine("产品名：" + pro.TypeOfProduct + " 数目：" + pro.AmountOfProduct);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("选择您要进行的操作：1.删除； 2.修改； 3.返回主菜单");
                int whichFun = 0;
                while (whichFun == 0)
                {
                    try
                    {
                        whichFun = int.Parse(Console.ReadLine());
                        if (whichFun < 1 || whichFun > 3) throw new System.FormatException();
                    }
                    catch (System.FormatException e)
                    {
                        whichFun = 0;
                        Console.Write(e.Message);
                        Console.WriteLine("请重新输入");
                    }
                }
                switch (whichFun)
                {
                    case 1:
                        Console.Write("输入您要删除的订单的序号：");
                        int index = -1;
                        while (index == -1)
                        {
                            try
                            {
                                index = int.Parse(Console.ReadLine());
                                Order temp = result[index];
                            }
                            catch (System.ArgumentOutOfRangeException e)
                            {
                                index = -1;
                                Console.WriteLine("序号无效，请重新输入");
                            }
                            catch (System.FormatException e)
                            {
                                index = -1;
                                Console.Write(e.Message);
                                Console.WriteLine("请重新输入");
                            }
                        }
                        deleteOrder(result[index]);
                        break;
                    case 2:
                        Console.WriteLine("选择您要进行的操作：1.修改客户名； 2.修改订单号；3.修改产品信息  4.返回主菜单");
                        int whichChange = 0;
                        while (whichChange == 0)
                        {
                            try
                            {
                                whichChange = int.Parse(Console.ReadLine());
                                if (whichChange < 1 || whichChange > 4) throw new System.FormatException();
                            }
                            catch (System.FormatException e)
                            {
                                whichChange = 0;
                                Console.Write(e.Message);
                                Console.WriteLine("请重新输入");
                            }
                        }
                        switch (whichChange)
                        {
                            case 1:
                                Console.Write("输入您要修改的订单的序号");
                                int index1 = -1;
                                while (index1 == -1)
                                {
                                    try
                                    {
                                        index1 = int.Parse(Console.ReadLine());
                                        Order temp = result[index1];
                                    }
                                    catch (System.ArgumentOutOfRangeException e)
                                    {
                                        index1 = -1;
                                        Console.WriteLine("序号无效，请重新输入");
                                    }
                                    catch (System.FormatException e)
                                    {
                                        index1 = -1;
                                        Console.Write(e.Message);
                                        Console.WriteLine("请重新输入");
                                    }
                                }
                                if (result[index1] != null)
                                {
                                    Console.Write("原用户名为：" + result[index1].Customer);
                                }
                                Console.Write(" 输入新的客户名：");
                                changeCustomerOfOrder(result[index1], Console.ReadLine());
                                break;
                            case 2:
                                Console.Write("输入您要修改的订单的序号");
                                int index2 = -1;
                                while (index2 == -1)
                                {
                                    try
                                    {
                                        index2 = int.Parse(Console.ReadLine());
                                        Order temp = result[index2];
                                    }
                                    catch (System.ArgumentOutOfRangeException e)
                                    {
                                        index2 = -1;
                                        Console.WriteLine("序号无效，请重新输入");
                                    }
                                    catch (System.FormatException e)
                                    {
                                        index2 = -1;
                                        Console.Write(e.Message);
                                        Console.WriteLine("请重新输入");
                                    }
                                }
                                if (result[index2] != null)
                                {
                                    Console.Write("原订单号为：" + result[index2].OrderNum);
                                }
                                Console.Write(" 输入新的订单号为：");
                                changeOrderNumOfOrder(result[index2], Console.ReadLine());
                                break;
                            case 3:
                                Console.Write("输入您要修改的订单的序号");
                                int index3 = -1;
                                while (index3 == -1)
                                {
                                    try
                                    {
                                        index3 = int.Parse(Console.ReadLine());
                                        Order temp = result[index3];
                                    }
                                    catch (System.ArgumentOutOfRangeException e)
                                    {
                                        index3 = -1;
                                        Console.WriteLine("序号无效，请重新输入");
                                    }
                                    catch (System.FormatException e)
                                    {
                                        index3 = -1;
                                        Console.Write(e.Message);
                                        Console.WriteLine("请重新输入");
                                    }
                                }
                                Console.Write("请输入您要修改的产品名称");
                                changeOrderDetailOfOrder(result[index3], Console.ReadLine());
                                break;
                            case 4:
                                return;
                        }
                        break;
                    case 3:
                        return;
                }
            }
            else throw new NoSearchResult();

        }

        //删除订单
        private void deleteOrder(Order ele)
        {
            bool IfDelete = false;
            ListOfOrder.Remove(ele);
            if (IfDelete == false)
            {
                //抛出异常 
            }
        }

        //修改订单
        private void changeCustomerOfOrder(Order ele, String newCustomer)
        {
            ele.Customer = newCustomer;
        }
        private void changeOrderNumOfOrder(Order ele, String newNum)
        {
            ele.OrderNum = newNum;
        }
        //修改产品信息
        private void changeOrderDetailOfOrder(Order ele, String product)
        {
            foreach (OrderDetails pro in ele.ListOfProduct)
            {
                if (pro.TypeOfProduct == product)
                {

                    Console.WriteLine("选择您要进行的服务: 1.修改产品名称； 2.修改产品数目；3.退出；");
                    int whichFun = 0;
                    while (whichFun == 0)
                    {
                        try
                        {
                            whichFun = int.Parse(Console.ReadLine());
                            if (whichFun < 1 || whichFun > 3) throw new System.FormatException();
                        }
                        catch (System.FormatException e)
                        {
                            whichFun = 0;
                            Console.Write(e.Message);
                            Console.WriteLine("请重新输入");
                        }
                    }
                    switch (whichFun)
                    {
                        case 1:
                            pro.TypeOfProduct = Console.ReadLine();
                            break;
                        case 2:
                            pro.AmountOfProduct = -1;
                            while (pro.AmountOfProduct == -1)
                            {
                                try
                                {
                                    pro.AmountOfProduct = int.Parse(Console.ReadLine());
                                    if (pro.AmountOfProduct <= 0) throw new System.FormatException();
                                }
                                catch (System.FormatException e)
                                {
                                    pro.AmountOfProduct = -1;
                                    Console.Write(e.Message);
                                    Console.WriteLine("请重新输入：");
                                }
                            }
                            break;
                    }
                }
            }
        }

        public void init()
        {
            //调试用数据
            OrderDetails pro1 = new OrderDetails();
            pro1.TypeOfProduct = "car"; pro1.AmountOfProduct = 10;
            OrderDetails pro2 = new OrderDetails();
            pro2.TypeOfProduct = "bike"; pro2.AmountOfProduct = 50;
            OrderDetails pro3 = new OrderDetails();
            pro3.TypeOfProduct = "phone"; pro3.AmountOfProduct = 200;
            Order init1 = new Order();
            init1.Customer = "张三"; init1.OrderNum = "001"; init1.ListOfProduct.Add(pro1);
            Order init2 = new Order();
            init2.Customer = "李四"; init2.OrderNum = "002"; init2.ListOfProduct.Add(pro2);
            Order init3 = new Order();
            init3.Customer = "王五"; init3.OrderNum = "003"; init3.ListOfProduct.Add(pro3);
            ListOfOrder.Add(init1); ListOfOrder.Add(init2); ListOfOrder.Add(init3);
        }
        //入口
        public void mainService()
        {
            Console.WriteLine("选择您要进行的服务: 1.添加订单； 2.查询订单；3.打印全部订单； 4.退出；");
            int whichFunction = 0;
            while (whichFunction == 0)
            {
                try
                {
                    whichFunction = int.Parse(Console.ReadLine());
                    if (whichFunction < 1 || whichFunction > 4) throw new System.FormatException();
                }
                catch (System.FormatException e)
                {
                    whichFunction = 0;
                    Console.Write(e.Message);
                    Console.WriteLine("请重新输入");
                }
            }
            switch (whichFunction)
            {
                case 1:
                    NewOrder();
                    break;
                case 2:
                    SearchOrder();
                    break;
                case 3:
                    try
                    {
                        WriteResult(ListOfOrder);
                    }
                    catch (NoSearchResult e)
                    {
                        Console.WriteLine(e.NoResult);
                    }
                    break;
                case 4:
                    return;
                default:
                    break;
            }
            mainService();
        }
    }
    public class NoSearchResult : ApplicationException
    {
        public String NoResult = "无符合条件的结果";
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService myOrder = new OrderService();
            myOrder.init();
            myOrder.mainService();

        }
    }
}