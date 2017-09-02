using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_12_деревом
{
    class Program
    {
        static public int max = 0;
        static public int repl = 0; //количество перестановок
        static public int comp = 0; //количество сравнений
        public class tree
        {
            public int value;
            public tree left;
            public tree right;
        }
        static public tree add_to_tree(tree root, int new_value)
        {

            if (root == null) // если нет сыновей - создаем новый элемент
            {
                root = new tree();
                root.value = new_value;
                root.left = null;
                root.right = null;
                return root;
            }
            if (root.value < new_value)  // добавлем ветвь
            { root.right = add_to_tree(root.right, new_value); }
            else { root.left = add_to_tree(root.left, new_value); };
            return root;
        }

        static public void tree_to_array(tree root, int[] a)
        {
            if (root == null) return;  // условие окончания - нет сыновей
            tree_to_array(root.left, a);
            a[max++] = root.value;
            tree_to_array(root.right, a);
        }

        static public void sort_tree(ref int[] a)
        {
            tree root = null;
            for (int i = 0; i < a.Length; i++)
            {
                root = add_to_tree(root, a[i]);
                repl++; 
            }
            tree_to_array(root, a);
        }


        static void Main(string[] args)
        {

        }
    }
}
