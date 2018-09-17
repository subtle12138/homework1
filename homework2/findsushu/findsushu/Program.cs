using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findsushu
{
    class Program
    {
        static void Main(string[] args)
        {
            //求100以内的素数
            Console.WriteLine("2");
            Console.WriteLine("3");
            for (int i=4;i<=100;i++)
            {
                for (int j = 2; j < 10; j++)
                {
                    if ((0 == i % j) && (i != j))
                    { break; }
                    else if((0 != i % j) && (i != j)&&(j<9))
                    {
                        continue;
                     }
                    else if ((0 != i % j) && (i != j) && (j==9))
                    {
                        Console.WriteLine(i);
                    }
                   
                }
            }
        }
    }
}
