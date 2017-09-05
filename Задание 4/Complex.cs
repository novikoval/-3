using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Complex
    {
        //атрибуты:
        double real;
        double imag;

        //свойства:
        public double Real
        {
            get { return real; }
            set { real = value; }
        }
        public double Imag
        {
            get { return imag; }
            set { imag = value; }
        }

        //часть 1
        public Complex() //конструктор без параметров
        {
            real = 0;
            imag = 0;
        }
        public Complex(double r, double i) //конструктор с параметрами
        {
            this.real = r;
            this.imag = i;
        } 
        public void Show() //метод для вывода   
        {   if (imag != 0)
            {
                if (this.imag > 0) Console.WriteLine("{0} + i{1}", real, imag);
                else Console.WriteLine("{0} - i{1}", real, Math.Abs(imag));
            }
            else Console.WriteLine("{0}", real);
        }

        public override string ToString()
        {
            return real + "+" + imag + "*i";
        }

        //часть 2. Перегрузка операций:
        public static Complex operator *(double a, Complex A) //Умножение комплексного числа на действительное
        {
            Complex res = new Complex(A.real * a, A.imag * a);
            return res;
        }

        public static Complex operator + (Complex A, Complex B)
        {
            Complex res = new Complex(A.real + B.real, A.imag + B.imag);
            return res;
        }

        public static Complex operator *(Complex A, Complex B)
        {
            Complex res = new Complex(A.real * B.real - A.imag * B.imag, A.real*B.imag + B.real*A.imag);
            return res;
        }

        public static Complex operator /(Complex A, Complex B)
        {
            Complex res = new Complex();
            if (B.real * B.real + B.imag * B.imag != 0)
                res = new Complex((A.real * B.real + A.imag * B.imag) / (B.real * B.real + B.imag * B.imag), (A.imag * B.real - A.real * B.imag) / (B.real * B.real + B.imag * B.imag));

            else
                Console.WriteLine("Error! You have 0 in denominator. You answer isn't correct. Please, try again");
            return res;
        }

        public static Complex operator -(Complex A, Complex B)
        {
            Complex res = new Complex(A.real - B.real, B.real - B.imag);
            return res;
        }

        public static Complex operator +(double a, Complex A) 
        {
            Complex res = new Complex(A.real + a, A.imag);
            return res;
        }

        public static Complex operator -(Complex A, double a) 
        {
            Complex res = new Complex(A.real - a, A.imag);
            return res;
        }
    }
}
