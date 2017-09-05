using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_8
{
    class Program
    {
        static int ReadInt()
        {
            int size = 0; bool ok;
            do
            {
                //проверяем формат
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                    //if (size == 0) { Console.WriteLine(msg1); Console.WriteLine(); }
                   /* else*/ if ((size < 0) || (size > 1))
                    {
                        Console.WriteLine("Input error. Please, input 0 or 1");
                        Console.WriteLine();
                    };
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input error. Please, try again");
                    Console.WriteLine();
                    ok = false;
                }

            } while ((!ok) || (size < 0) || (size > 1));
            return size;
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
                        Console.WriteLine("Input error. Please, try again.");
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

        static int[,] ArrayInput(int a, int b)
        {
            int[,] mas = new int[a, b];
            Console.WriteLine("Input the values");
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    mas[i, j] = ReadInt();
            return mas;
        }

        static void Main(string[] args)
        {

            
            //while (deg[first] != 0) ++first; //

            ////int v1 = -1, v2 = -1; //
            //bool bad = false;
            //for (int i = 0; i < n; ++i)
            //    if ((deg[i] & 1) !=0)
            //        if (v1 == -1)
            //            v1 = i;
            //        else if (v2 == -1)
            //            v2 = i;
            //        else
            //            bad = true;

            //if (v1 != -1)
            //{
            //    ++g[v1, v2];
            //    ++g[v2, v1];
            //}


            
            bool bad = false;
            int n = ReadInt("Input the number of vertexes:", "The graph cannot be empty. Try again, please.", 1000);  //количество вершин
            int[,] g = new int[n,n];
            while (bad)
            {            
                g = ArrayInput(n, n);
                int[] deg = new int[n]; //масссив степеней вершин
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        deg[i] += g[i, j];

                //проверяем, что ввели действительно эйлеров граф
                for (int i = 0; i < n; ++i)
                    if (deg[i] % 2 != 0) //если степень хотя бы одной вершины нечетная, то граф не эйлеров
                        bad = true;
            }

            //int[,] g1 = new int[n, n];
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        g1[i, j] = g[i,j];

            int first = n - 1;

            Stack<int> st = new Stack<int>();
            st.Push(first);
            string res = ""; //массив ответ
            while (st.Count != 0) //пока стек не пустой
            {
                int v = st.Peek(); //вершина стека
                int i;
                for (i = 0; i < n; ++i)
                    if (g[v,i] !=0)
                        break;
                if (i == n) //если степень 0
                {
                    //res.Push_back(v);
                    //st.Pop();
                    int otv = st.Pop() + 1;
                    res += otv.ToString();
                }
                else
                {
                    //удаляем ребро
                    --g[v, i];
                    --g[i, v];
                    st.Push(i); //вторую вершину в стек
            }
        }

            //if (v1 != -1)
            //    for (int i = 0; i + 1 < res.Count(); ++i)
            //        if (res[i] == v1 && res[i + 1] == v2 || res[i] == v2 && res[i + 1] == v1)
            //        {
            //            int [] res2;
            //            for (int j = i + 1; j < res.Count(); ++j)
            //                res2.Push_back(res[j]);
            //            for (int j = 1; j <= i; ++j)
            //                res2.Push_back(res[j]);
            //            res = res2;
            //            break;
            //        }

            //for (int i = 0; i < n; ++i)
            //    for (int j = 0; j < n; ++j)
            //        if (g[i, j] != 0)
            //            bad = true;

            //if (bad) 
            //    puts("-1");
            //else
            //    for (int i = 0; i < res.Count(); ++i)
            //        Console.Write("%d ", res[i] + 1);

            Console.WriteLine(res);
        }
    }
}
