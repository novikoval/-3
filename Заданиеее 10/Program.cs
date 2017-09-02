using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Заданиеее_10
{
    class Point1
    {
        public double data;//информационное поле
        public Point1 next;//адресное поле
        public Point1()//конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public Point1(double d)//конструктор с параметрами
        {
            data = d;
            next = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }

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
                    else if ((size < 2) || (size > border))
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

            } while ((!ok) || (size < 2) || (size > border));
            return size;
        }
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

        static Point1 MakePoint1(double d)
        {
            Point1 p = new Point1(d);
            return p;
        }
        static Point1 MakeListToEnd(int size) //добавление в конец
        {
            double info = ReadDouble();
            Point1 run = MakePoint1(info);//первый элемент
            Point1 r = run;//переменная хранит адрес конца списка 
            for (int i = 1; i < size; i++)
            {
                info = ReadDouble();
                //создаем элемент и добавляем в конец списка
                Point1 p = MakePoint1(info);
                r.next = p;
                r = p;
            }
            return run;
        }
        static void ShowList1(Point1 beg)
        {
            Point1 p = beg;
            while (p != null)
            {
                Console.Write(p.data.ToString() + " ");
                p = p.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int size = ReadInt("Input the size of list", "Your list will be empty. Please, try again", 1000);
            Console.WriteLine("Input {0} elements:", size);

            double info = ReadDouble();
            Point1 beg = MakePoint1(info);//первый элемент
            Point1 r = beg;//переменная хранит адрес конца списка 
            for (int i = 1; i < size; i++)
            {
                info = ReadDouble();
                //создаем элемент и добавляем в конец списка
                Point1 p = MakePoint1(info);
                r.next = p;
                r = p;
            } 

            Point1 n = beg;
            while (n.next.next != null)  //обход введенного списка до предпоследнего элемента
            {
                n.data = n.data - r.data;
                n = n.next;
            }
            n.next = null; //удаляем последний элемент
            n.data = n.data - r.data; //обрабатываем предпоследний

            Console.WriteLine("Your sequence is: ");
            ShowList1(beg);
        }
    }
}
