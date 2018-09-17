using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuzu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组元素个数：");
            int Number = int.Parse(Console.ReadLine());
            Console.WriteLine("输入数组元素：");
            double [] numbers = new double[Number];
            for(int i=0;i<Number;i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }

            ////求平均数.和
            double sum = 0, average = 0;
            for (int i = 0; i < Number; i++)
            {
                sum += numbers[i];
            }
            average = sum / Number;
            Console.WriteLine("它们的和是：" + sum);
            Console.WriteLine("数组的平均值是：" + average);

            //求最值
            for (int i = 1; i < Number; i++)
            {
                if (numbers[i-1] < numbers[i])
                {
                    double c = numbers[i - 1];
                    numbers[i - 1] = numbers[i];
                    numbers[i] = c;
                }
            }
            Console.WriteLine("它们中的最小值是：" + numbers[Number - 1]);
            for (int i = 1; i < Number; i++)
            {
                if (numbers[i-1] > numbers[i])
                {
                    double c = numbers[i-1];
                    numbers[i-1] = numbers[i];
                    numbers[i] = c;
                }
            }
            Console.WriteLine("它们中的最大值是：" + numbers[Number - 1]);
        }
    }
}
