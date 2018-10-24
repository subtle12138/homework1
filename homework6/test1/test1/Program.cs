using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Program1
{
    public class Order
    {
        public string OrderNum { set; get; }
        public string ClientName { set; get; }
        public int ProductCategory { set; get; }
        public int TotalPrice { set; get; }
        public List<OrderDetails> ListOfDetails = new List<OrderDetails>();
    }
    public class OrderDetails
    {
        public string ProductName { set; get; }
        public int NumOfProduct { set; get; }
        public int PriceOfProduct { set; get; }
    }
    public class OrderService
    {
        public List<Order> ListOfOrder = new List<Order>();
        public int num = 0;
        public void DisplayOrder(Order order)
        {
            Console.Write($"订单号:{order.OrderNum}  ");
            Console.WriteLine($"用户名:{order.ClientName}");
            foreach (OrderDetails o in order.ListOfDetails)
            {
                Console.Write($"产品名:{o.ProductName}  ");
                Console.Write($"产品单价:{o.PriceOfProduct}元  ");
                Console.WriteLine($"产品数量:{o.NumOfProduct}件");
            }
            Console.WriteLine($"订单总价为{order.TotalPrice}元");
        }
        public void DisplayOrderList(List<Order> orders)
        {
            foreach (Order o in orders)
                DisplayOrder(o);
        }
        public void DisplayAll()
        {
            int i = 1;
            foreach (Order o in ListOfOrder)
            {
                Console.WriteLine($"{i}.");
                DisplayOrder(o);
                i++;
            }
        }
        public void AddOrder()
        {
            Order newOrder = new Order();
            Console.Write("请输入订单号:");
            string s = Console.ReadLine();
            while (CheckNum(s) != true || CheckRepeat(s) != true)
            {
                Console.Write("请重新输入订单号:");
                s = Console.ReadLine();
            }
            newOrder.OrderNum = s;
            Console.Write("请输入用户名:");
            newOrder.ClientName = Console.ReadLine();
            Console.Write("请输入产品种类数:");
            s = Console.ReadLine();
            while (CheckNum(s) != true)
            {
                Console.Write("请重新输入产品种类数:");
                s = Console.ReadLine();
            }
            newOrder.ProductCategory = int.Parse(s);
            for (int i = 0; i < newOrder.ProductCategory; i++)
            {
                OrderDetails o = new OrderDetails();
                Console.Write($"请输入第{i + 1}种产品的产品名:");
                o.ProductName = Console.ReadLine();
                Console.Write("请输入该产品单价:");
                s = Console.ReadLine();
                while (CheckNum(s) != true)
                {
                    Console.Write("请重新输入该产品单价:");
                    s = Console.ReadLine();
                }
                o.PriceOfProduct = int.Parse(s);
                Console.Write("请输入该产品数目:");
                s = Console.ReadLine();
                while (CheckNum(s) != true)
                {
                    Console.Write("请重新输入该产品数目:");
                    s = Console.ReadLine();
                }
                o.NumOfProduct = int.Parse(s);
                newOrder.TotalPrice += o.PriceOfProduct * o.NumOfProduct;
                newOrder.ListOfDetails.Add(o);
            }
            ListOfOrder.Add(newOrder);
            num++;
        }
        public bool CheckNum(string s)
        {
            try
            {
                int t = int.Parse(s);
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                return false;
            }
            return true;
        }
        public bool CheckRepeat(string s)
        {
            int t = int.Parse(s);
            List<Order> orders = SearchByOrderNum(t).ToList();
            foreach (Order o in orders)
            {
                if (o.OrderNum == s)
                {
                    Console.WriteLine("输入错误！");
                    return false;
                }
            }
            return true;
        }
        //序列化
        public void Import(string xmlFileName)
        {
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                FileStream fs = new FileStream(xmlFileName, FileMode.Open);
                ListOfOrder = (List<Order>)xmlser.Deserialize(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("请重新输入:");
            }
        }
        public void Export(string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream(xmlFileName, FileMode.OpenOrCreate);
            xmlser.Serialize(fs, ListOfOrder);
            fs.Close();
        }
        //使用LINQ语句进行查询操作
        public List<Order> SearchByOrderNum(int num)
        {
            var o = ListOfOrder.Where(a => int.Parse(a.OrderNum) == num);
            return o.ToList();
        }
        public List<Order> SearchByClientName(string name)
        {
            var o = ListOfOrder.Where(a => a.ClientName == name);
            return o.ToList();
        }
        public List<Order> SearchByProductName(string name)
        {
            var o = from l in ListOfOrder from a in l.ListOfDetails where a.ProductName == name select l;
            return o.ToList();
        }
        public List<Order> SearchByPriceOfProduct(int num)
        {
            var o = from l in ListOfOrder from a in l.ListOfDetails where a.PriceOfProduct == num select l;
            return o.ToList();
        }
        public List<Order> SearchByNumOfProduct(int num)
        {
            var o = from l in ListOfOrder from a in l.ListOfDetails where a.NumOfProduct == num select l;
            return o.ToList();
        }
        public List<Order> SearchByWhichTotalPriceOver(int num)
        {
            var o = from l in ListOfOrder where l.TotalPrice >= num select l;
            return o.ToList();
        }
        public int InputSearchFlag()
        {
            int tag = 0;
            Console.WriteLine("请输入要寻找的项目:1.订单号 2.用户名 3.产品名 4.产品单价 5.产品数目 6.订单金额大于某个值的");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if (!(tag >= 1 && tag <= 6))
                {
                    Console.WriteLine("输入错误！");
                    InputSearchFlag();
                }
                return tag;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputSearchFlag();
            }
            return 0;
        }
        public List<Order> Search()
        {
            DisplayAll();
            List<Order> orders = new List<Order>();
            int Flag = InputSearchFlag();
            switch (Flag)
            {
                case 1:
                    Console.Write("请输入订单号:");
                    string s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入订单号:");
                        s = Console.ReadLine();
                    }
                    orders = SearchByOrderNum(int.Parse(s));
                    break;
                case 2:
                    Console.Write("请输入用户名:");
                    orders = SearchByClientName(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("请输入产品名:");
                    orders = SearchByProductName(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("请输入产品单价:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品单价:");
                        s = Console.ReadLine();
                    }
                    orders = SearchByPriceOfProduct(int.Parse(s));
                    break;
                case 5:
                    Console.Write("请输入产品数目:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品数目:");
                        s = Console.ReadLine();
                    }
                    orders = SearchByNumOfProduct(int.Parse(s));
                    break;
                case 6:
                    Console.Write("请输入所需订单总价的下限:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入所需订单总价的下限:");
                        s = Console.ReadLine();
                    }
                    orders = SearchByWhichTotalPriceOver(int.Parse(s));
                    break;
            }
            return orders;
        }
        public int InputTag()
        {
            int temp;
            try
            {
                Console.WriteLine("请输入所需的订单序号:");
                temp = int.Parse(Console.ReadLine());
                if (!(temp >= 1 && temp <= num))
                {
                    Console.WriteLine("输入错误！");
                    InputTag();
                }
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputTag();
            }
            return 0;
        }
        public Order SearchByTag()
        {
            int tag = InputTag();
            try
            {
                return ListOfOrder[tag - 1];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("所请求的订单不存在！");
                SearchByTag();
            }
            return null;
        }
        public void DelOrderByOrderNum(int num)
        {
            Console.Write("请输入要删除的订单的订单号:");
            var o = ListOfOrder.Where(a => int.Parse(a.OrderNum) == num);
            List<Order> orders = o.ToList();
            foreach (Order t in orders)
            {
                ListOfOrder.Remove(t);
                num--;
            }
        }
        public void DelOrderByTag(int n)
        {
            ListOfOrder.Remove(ListOfOrder[n - 1]);
            num--;
        }
        public int InputChangeFlag()
        {
            int tag = 0;
            Console.WriteLine("请输入要修改的项目:1.订单号 2.用户名 3.产品名 4.产品单价 5.产品数目");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if (!(tag >= 1 && tag <= 5))
                {
                    Console.WriteLine("输入错误！");
                    InputChangeFlag();
                }
                return tag;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputChangeFlag();
            }
            return 0;
        }
        public void Change()
        {
            Order o = SearchByTag();
            int Flag = InputChangeFlag();
            switch (Flag)
            {
                case 1:
                    Console.Write("请输入订单号:");
                    string s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入订单号:");
                        s = Console.ReadLine();
                    }
                    o.OrderNum = s;
                    break;
                case 2:
                    Console.Write("请输入用户名:");
                    o.ClientName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("请输入产品名:");
                    o.ListOfDetails[0].ProductName = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("请输入产品单价:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品单价:");
                        s = Console.ReadLine();
                    }
                    o.ListOfDetails[0].PriceOfProduct = int.Parse(s);
                    break;
                case 5:
                    Console.Write("请输入产品数目:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品数目:");
                        s = Console.ReadLine();
                    }
                    o.ListOfDetails[0].NumOfProduct = int.Parse(s);
                    break;
            }
        }
        public string InputXmlFlag(int flag)
        {
            string str;
            if (flag == 0)
                str = "读取";
            else
                str = "输出";
            Console.Write($"是否需要{str}Xml文件(Y/N):");
            string s = Console.ReadLine();
            try
            {
                if (!(s == "Y" || s == "N"))
                {
                    Console.WriteLine("输入错误！");
                    InputXmlFlag(flag);
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                Console.Write("请重新输入");
                InputXmlFlag(flag);
            }
            return null;
        }
        public int InputControlFlag()
        {
            int tag = 0;
            Console.WriteLine("请选择你的操作:1.添加订单 2.删除订单 3.修改订单 4.查询订单 5.显示所有订单 6.结束操作");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if (!(tag >= 1 && tag <= 6))
                {
                    Console.WriteLine("输入错误！");
                    InputControlFlag();
                }
                return tag;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputControlFlag();
            }
            return 0;
        }
        public void Control()
        {
            int ControlFlag = InputControlFlag();
            switch (ControlFlag)
            {
                case 1:
                    AddOrder();
                    break;
                case 2:
                    foreach (Order o in Search())
                        ListOfOrder.Remove(o);
                    break;
                case 3:
                    Change();
                    break;
                case 4:
                    DisplayOrderList(Search());
                    break;
                case 5:
                    DisplayAll();
                    break;
                case 6:
                    string XmlFlag = InputXmlFlag(1);
                    if (XmlFlag == "Y")
                    {
                        Console.Write("请输入要存储的文件位置:");
                        string s = Console.ReadLine();
                        Export(s);
                        string xml = File.ReadAllText(s);
                        Console.WriteLine(xml);
                    }
                    return;
            }
            Control();
        }
        public void Run()
        {
            string XmlFlag = InputXmlFlag(0);
            if (XmlFlag == "Y")
            {
                Console.Write("请输入文件位置:");
                string s = Console.ReadLine();
                Import(s);
            }
            Control();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService o = new OrderService();
            o.Run();
            Console.ReadLine();
        }
    }
}

