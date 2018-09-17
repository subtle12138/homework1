using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhishu123
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数:");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("它的素数因子有：");
            for (int i = 2; i <= number; i++)
                {
                    while (0 == number % i)
                    {
                        Console.WriteLine("" + i);
                        number = number / i;
                    }
                }
        }
    }
}
