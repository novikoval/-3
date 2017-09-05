using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static double ReadDouble()
        {
            double number = 0; bool ok = false;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input error. Please, try again");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        static void Main(string[] args)
        {
            double u1, u2, v1, v2, w1, w2;
            Console.WriteLine("Input u1");
            u1 = ReadDouble();
            Console.WriteLine("Input u2");
            u2 = ReadDouble();
            Console.WriteLine("Input v1");
            v1 = ReadDouble();
            Console.WriteLine("Input v2");
            v2 = ReadDouble();
            Console.WriteLine("Input w1");
            w1 = ReadDouble();
            Console.WriteLine("Input w2");
            w2 = ReadDouble();

            Complex u = new Complex(u1, u2); 
            Complex v = new Complex(v1, v2);
            Complex w = new Complex(w1, w2);
            Complex res1 = 2 * u;
            Complex res2 =  (3 * u * w) ;
            Complex res3 =  (2 + w - v) ;
            Complex res = res1 + res2 / res3 - 7;
            res.Show();
        }
    }
}
