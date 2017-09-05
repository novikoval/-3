using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_задание_3
{
    class Program
    {
        static double ReadDouble()
        {
            double number = 0; bool ok = false;
            do
            {
                //проверяем формат
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
            double X, Y;
            Console.WriteLine("Input X:");
            X = ReadDouble();
            Console.WriteLine("Input Y:");
            Y = ReadDouble();
            bool rez = (Y <= 2 - Math.Abs(2 * X)) && (Y >= -1);
            Console.WriteLine(rez);
        }
    }
}
