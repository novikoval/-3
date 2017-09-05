using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_12
{
    class Program
    {
        static int comp = 0; //счетчик сравнений
        static int repl = 0; //счетчик пересылок

        static IComparable[] Merge_Sort(IComparable[] massive)
        {
            comp++;
            if (massive.Length == 1)
                return massive;
           
            int mid_point = massive.Length / 2;
            repl += massive.Length;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }
        static IComparable[] Merge(IComparable[] mass1, IComparable[] mass2)
        {
            int a = 0, b = 0;
            IComparable[] merged = new IComparable[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                comp+=2; // за for и следующий if
                if (b.CompareTo(mass2.Length) < 0 && a.CompareTo(mass1.Length) < 0)
                    if (mass1[a].CompareTo(mass2[b]) > 0)
                    {
                        merged[i] = mass2[b++];
                        comp++;
                        repl++;
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                        repl++;
                    }
                else
                    if (b < mass2.Length)
                {
                    merged[i] = mass2[b++];
                    comp++;
                    repl++;
                }
                else
                {
                    merged[i] = mass1[a++];
                    repl++;
                }
            }
            return merged;
        }
        static void Main(string[] args)
        {
            IComparable[] arr = new IComparable[10];
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = i; 
            }
            Console.WriteLine("\n\nThe array before sorting:");
            foreach (int x in arr)
                System.Console.Write(x + " ");
            arr = Merge_Sort(arr);
            Console.WriteLine("\n\nThe array after sorting:");
            foreach (int x in arr)
                System.Console.Write(x + " ");
            Console.WriteLine("\n\nthe number of comp is {0}, the number of repl is {1}", comp, repl);
            Console.WriteLine("\n\nFor exit push the <Enter>.");
            Console.ReadKey();
        }
    }
}
