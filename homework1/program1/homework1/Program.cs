using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "";
            double a = 0;
            Console.Write("please input the first number:");
            s1 = Console.ReadLine();
            a = Double.Parse(s1);
            string s2 = "";
            double b = 0;
            Console.Write("please input the second number:");
            s2 = Console.ReadLine();
            b = Double.Parse(s2);
            Console.WriteLine("Their product is:" + (a * b));
        }
    }
}
