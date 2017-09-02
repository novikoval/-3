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
            u1 = ReadDouble();
            u2 = ReadDouble();
            v1 = ReadDouble();
            v2 = ReadDouble();
            w1 = ReadDouble();
            w2 = ReadDouble();

            Complex u = new Complex(u1, u2);
            Complex v = new Complex(v1, v2);
            Complex w = new Complex(w1, w2);
            Complex res = 2 * u + (3 * u * w) / (2 + w - v) - 7;
            res.Show();
        }
    }
}
