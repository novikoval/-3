using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_11
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


        static int[] ArrayInput(int a)
        {
            int[] mas = new int[a];
            for (int i = 0; i < a; i++) { mas[i] = ReadInt("Input cipher", "", 1000000);   }
            return mas;
        }

      


        static void Main(string[] args)
        {
            
            Console.WriteLine("Input the text:");
            string text = Console.ReadLine();
            int k = ReadInt("Input k:", "k cannot be null", 100);
            Console.WriteLine("Input the cipher. Please, input just one symbol in one line:");
            int[] cipher = ArrayInput(k);

            #region шифровка
            //добавляем необходимое кол-во пробелов в конце
            int leftover = k - text.Length % k;
            for (int i=0; i<leftover; i++)
            {
                text += " ";
            }
           
            char[,] parts = new char[text.Length /k, k];

            string newtext = "";
            //делим на части по k и шифруем в правильном порядке
            int count = 0;
                for (int jj = 0; jj < text.Length / k; jj++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        parts[jj, j] = text[count];
                        count++;
                    }
                    foreach (int c in cipher)
                        newtext += parts[jj, c-1];
                }
            #endregion

            Console.WriteLine(newtext);
            char[,] parts1 = new char[text.Length / k, k];
            string newtext1 = "";

            #region расшифровка
            int count1 = 0;
            for (int jj = 0; jj < text.Length / k; jj++)
            {
                for (int j = 0; j < k; j++)
                {
                    parts1[jj, cipher[j] - 1] = newtext[count1];
                    count1++;
                }
                for (int i = 0; i < k; i++)
                    newtext1 += parts1[jj,i];
            }
            #endregion

            Console.WriteLine(newtext1);

        }
    }
}
