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

        //static double Fn(int N)
        //{
        //    double res = 13*Fn(N-1)-10*Fn(N-2)+Fn(N-3);
        //    return  res;
        //}

        //static double Fn(int N, double a1, double a2, double a3)
        //{
        //    double res = 13 * a3 - 10 * a2 + a1;
        //    return res;
        //}

        //static double Fn(int N, double a2, double a3)
        //{
        //    double res = 13 * Fn(N - 1) - 10 * a3 + a2;
        //    return res;
        //}
        static double a1, a2, a3;



        static double Fn(double an1, double an2, double an3, ref bool incr, int N)
        {
            double res = 0;
            for (int i = 4; i <= N; i++)
            {
                res = Fn(an1, an2, an3, ref incr, N);
                Console.WriteLine("a{0} = {1}", i, res);
                if (an2 >= res) incr = false;
                an3 = an2;
                an2 = an1;
            }
            return res;
        }

        static double F(int N)
        {


            //Console.WriteLine("a{0} = {1}", i, res);
           

            if (N == 1)
            {
                Console.WriteLine("a{0} = {1}", N, a1);
                return a1;
            }

            if (N == 2)
            {
                Console.WriteLine("a{0} = {1}", N, a2);
                return a2;
            }

            if (N == 3)
            {
                Console.WriteLine("a{0} = {1}", N, a3);
                return a3;
            }

            
            double an = 13 * F(N - 1) - 10 * F(N - 2) + F(N - 3);

            return an;
        }

        static void Main(string[] args)
        {
            double a1, a2, a3;
            a1 = ReadDouble();
            a2 = ReadDouble();
            a3 = ReadDouble();
            int N = ReadInt("Input N", "Consequence cannot be empty", 10000000000);

            bool incr = true;
            Console.WriteLine("a1 = {0}", a1);
            Console.WriteLine("a2 = {0}", a2);
            Console.WriteLine("a3 = {0}", a3);
            double an1 = a3, an2 = a2, an3 = a1;
            //double an = Fn(an1, an2, an3);
            //Console.WriteLine("a{0} = {1}", n, an);

            //double an = F(N);
            //an1 = an;

            Console.WriteLine("a{0} = {1}", N, F(N));

            if (incr) Console.WriteLine("The sequence is increasing");
            else Console.WriteLine("The sequence is not increasing");
        }
    }
}
