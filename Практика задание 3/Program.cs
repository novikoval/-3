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
            X = ReadDouble();
            Y = ReadDouble();
            bool rez = (Math.Pow(X - 5, 2) <= 25 - Math.Pow(Y, 2)) || (X <= 2 - Math.Abs(2 * X)) && (X >= 0);
            Console.WriteLine(rez);
        }
    }
}
