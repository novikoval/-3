using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        static double[,] MatrInput(int a)
        {
            double[,] matr = new double[a, a];
            Console.WriteLine("Input {0} elements from left to right", a*a);
            for (int i = 0; i < a; i++)
                for (int j = 0; j < a; j++)
                    matr[i, j] = ReadDouble();
            return matr;
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
                    else if ((size < 0) || (size > border))
                    {
                        Console.WriteLine("Input error. Please, try again");
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

        static void MatrOutput(string msg, double[,] mas)
        {
            Console.WriteLine(msg);
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            bool ravn = true;
            int size = ReadInt("Input the size of your matr", "The matr cannot be empty", 100);
            double[,] matr = new double[size, size];
            matr = MatrInput(size);
            double max = -100000000000000;
            //обход нужных элементов для нахождения максимума
            for (int i = size / 2; i < size; i++)
                for (int j = size - i - 1; j < i + 1; j++)
                 if (matr[i, j] > max)
                        max = matr[i, j];

            //обход нужных элементов для проверки, не равные ли они
            for (int i = size / 2; i < size; i++)
                for (int j = size - i - 1; j < i + 1; j++)
                    if (matr[i, j] != max)
                        ravn = false;
            // else
            MatrOutput("Your matr", matr);
            if (ravn) Console.WriteLine("No maximum value");
            else 
            Console.WriteLine("The max value is {0}", max);
        }
    }
}
