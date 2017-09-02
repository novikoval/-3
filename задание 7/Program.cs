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

        static void ArrayOutput(int[] arr)
        {
            Console.Write("{0}: ", count);
            foreach (int x in arr)
                Console.Write(x + " ");
            count++;
            Console.WriteLine();
        }

        static void F(int c, int k, int n, ref int[] arr)
        {
            while (arr[k - c] < n)//группа эл-тов, где все, кроме последнего, наименьшие
            {
                arr[k - c]++;
                ArrayOutput(arr);
            }
            c++;
            arr[k - c]++;

            for (int j = k - c + 1; j < k; j++) arr[j] = arr[k - c];
            ArrayOutput(arr);
        }

        static void Func(int[] arr, int k, int n, int c)
        {
            while (arr[k - c] < n)
            {
                arr[k - c]++;
                ArrayOutput(arr);
            }
            if (c < k)
            {
                arr[k - c - 1]++;
                while (arr[k - c] == arr[k - c - 1])
                {
                    c++;
                    ArrayOutput(arr);
                    arr[k - c - 1]++;
                    for (int j = k - c; j < k; j++) arr[j] = arr[k - c - 1];
                    //c++;
                    ArrayOutput(arr);
                    c--;
                    for (int j = k - c; j < k; j++) arr[j] = arr[k - c - 1];
                    //c++;
                    ArrayOutput(arr);
                }


                for (int j = k - c; j < k; j++) arr[j] = arr[k - c - 1];
                //c++;
                ArrayOutput(arr);

                if ((arr[k - c] < n))
                    Func(arr, k, n, c);
            }
            ArrayOutput(arr);

        }

        static void Main(string[] args)
        {
            int k = 4, n = 3;
            int[] arr = { 1, 1, 1, 1 };
            ArrayOutput(arr);
            int c = 1;

            //for (int i = 0; i < k; i++) //для каждой группы, где наименьших эл-тов: к-1, ..., к-к. Итого k групп
            //{
            /*  while (arr[k - c] < n)//группа эл-тов, где все, кроме последнего, наименьшие
              {
                  arr[k - c]++;
                  //for (int j = k - c + 1; j < k; j++) arr[j] = arr[k - c];
                  ArrayOutput(arr);
              }

              c++;
              arr[k - c]++;
              for (int j = k - c + 1; j < k; j++) arr[j] = arr[k - c];
              ArrayOutput(arr);

              F(1, k, n, ref arr);


              c++;
              arr[k - c]++;
              for (int j = k - c + 1; j < k; j++) arr[j] = arr[k - c];
              ArrayOutput(arr);

              F(1, k, n, ref arr);

              arr[k - c]++;
              ArrayOutput(arr);

              c++;
              arr[k - c]++;
              for (int j = k - c + 1; j < k; j++) arr[j] = arr[k - c];
              ArrayOutput(arr);

              F(1, k, n, ref arr);

              arr[k - c]++;
              ArrayOutput(arr); */



            Func(arr, k, n, c);

        }
    }
}
