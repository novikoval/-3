using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_6
{
    class Program
    {
        static int ReadInt(string msg, string msg1, long border)
        {
            int size = 0; bool ok;
            do
            {
                Console.WriteLine(msg);
                //проверяем формат
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                    if (size == 0) { Console.WriteLine(msg1); Console.WriteLine(); }
                    else if ((size < 4) || (size > border))
                    {
                        Console.WriteLine("Input error. Please, try again. N should be more than 4");
                        Console.WriteLine();
                    };
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input error. Please, try again");
                    Console.WriteLine();
                    ok = false;
                }

            } while ((!ok) || (size <= 0) || (size > border));
            return size;
        }

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

        static double a1, a2, a3;

        static double F(int N)
        {
           

            if (N == 1)
            {
                return a1;
            }

            if (N == 2)
            {
                return a2;
            }

            if (N == 3)
            {
                return a3;
            }

            return 13 * F(N - 1) - 10 * F(N - 2) + F(N - 3);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input a1:");
            a1 = ReadDouble();
            Console.WriteLine("Input a2:");
            a2 = ReadDouble();
            Console.WriteLine("Input a3:");
            a3 = ReadDouble();
            int N = ReadInt("Input N", "Consequence cannot be empty", 10000000000);

            bool incr = true;
            double ch = a2; //переменная для хранения элемента с четным индексом для сравнения со следующим четным

            for (int i = 1; i <= N; i++)
            {
                double an = F(i);
                Console.WriteLine("a{0} = {1}", i, an);
                if (i%2==0 && an < ch)
                {
                    incr = false;
                    ch = an;
                }
            }

            if (incr) Console.WriteLine("The sequence is increasing");
            else Console.WriteLine("The sequence is not increasing");
        }
    }
}
