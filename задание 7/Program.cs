using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_7
{
    class Program
    {
        static int count = 1;

        static void ArrayOutput(string[] arr)
        {
            Console.Write("{0}: ", count);
            foreach (string x in arr)
                Console.Write(x + " ");
            count++;
            Console.WriteLine();
        }

        static string[] ArrayInput(int a)
        {
            string[] mas = new string[a];
            Console.WriteLine("Input {0} elements:", a);
            for (int i = 0; i < a; i++) mas[i] = Console.ReadLine();
            return mas;
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
                    if (size == 1) { Console.WriteLine(msg1); Console.WriteLine(); }
                    else if ((size < 1) || (size > border))
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

            } while ((!ok) || (size <= 1) || (size > border));
            return size;
        }
         
        static void Main(string[] args)
        {
            int k = ReadInt("Input k:","K should be more than 2",1000), n = ReadInt("Input n:", "n should be more than 2", 1000);
            string[] nabor = ArrayInput(n);
            Array.Sort(nabor);
            string[] arr = new string[k];
            for(int i=0; i<k; i++)
            {
                arr[i] = nabor[0];
            }
            
            ArrayOutput(arr);
            int c = 1;


            while (arr[0] != nabor[n-1])
            {
                c=0;
                while (arr[k - 1] != nabor[n-1])
                {
                    arr[k - 1] = nabor[Array.IndexOf(nabor, arr[k-1])+1];
                    ArrayOutput(arr);
                }

                do
                {
                    c++;
                    arr[k - c - 1] = nabor[Array.IndexOf(nabor, arr[k - c - 1])+1];
                    for (int j = k - c; j < k; j++) arr[j] = arr[k - c - 1];
                    ArrayOutput(arr);

                } while (arr[k - c - 1] == nabor[n-1] && c<k-1);
            }
        }
    }
}
