using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_9
{
    class Point1
    {
        public int data;//информационное поле
        public Point1 next;//адресное поле
        public Point1()//конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public Point1(int d)//конструктор с параметрами
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

        static Point1 MakePoint1(int d)
        {
            Point1 p = new Point1(d);
            return p;
        }
        static Point1 MakeListToEnd(int size) //добавление в конец
        {
            Random rnd = new Random();
            int info = rnd.Next(-1, 2);
            Point1 run = MakePoint1(info);//первый элемент
            Point1 r = run;//переменная хранит адрес конца списка 
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(-1, 1);
                //создаем элемент и добавляем в конец списка
                Point1 p = MakePoint1(info);
                r.next = p;
                r = p;
            }
            return run;
        }
        static Point1 AddPoint(Point1 beg, int info)
        {
            //создаем новый элемент
            Point1 NewPoint = MakePoint1(info);
            if (beg == null)//если список пустой, добавляем первый элемент
            {
                beg = NewPoint;
                return beg;
            }

                //вспом. переменная для прохода по списку
                Point1 p = beg;
            //p.next = beg.next;
                ////ищем конец списка
                //for (int i = 0; p.next == null; i++)
                //{
                //    p = p.next;
                //}
            //добавляем новый элемент
                NewPoint.next = p.next;
            p.next = NewPoint;
            //p.next = NewPoint;
           // p = p.next;
            return beg;
        }
        static void ShowList1(Point1 beg)
        {
            Point1 p = beg;
            while (p != null)
            {
                Console.Write(p.data.ToString());
                p = p.next;
            }
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            int size = ReadInt("Input the size of list", "Ypur list will be empty. Please, try again", 1000);
            Point1 beg = MakeListToEnd(size);
            Point1 pos = null;
            Point1 neg = null;
            Point1 p = beg;
            bool notfirst = false;
            //if (p.data > 0) AddPoint(pos, p.data);
            //else AddPoint(neg, p.data);
            ////исключаем элемент из исходного списка
            //p= p.next;
            //обходим исходный список

            for (int i = 1; p != null; i++)
            {
                if (!notfirst)
                {
                    if (p.data != 0)//если элемент не 0 
                    {
                        if (p.data > 0) pos = AddPoint(pos, p.data);
                        else neg = AddPoint(neg, p.data);
                        //исключаем элемент из исходного списка
                        beg = p.next;
                    }
                    else { /*p = p.next;*/ notfirst = true; }
                    }
                else
                {
                    Point1 pbeg = beg;
                    if (p.data != 0)//если элемент не 0 
                    {
                        if (p.data > 0) AddPoint(pos, p.data);
                        else AddPoint(neg, p.data);
                        //исключаем элемент из исходного списка
                        pbeg.next = pbeg.next.next;
                        //p = p.next;
                        p = pbeg;
                    }                 
                }
                p = p.next;
            }

            Console.WriteLine("The old list:");
            ShowList1(beg);
            Console.WriteLine("The new positive list:");
            ShowList1(pos);
            Console.WriteLine("The new negative list:");
            ShowList1(neg);
        }
    }
}
