using System;
using System.Collections.Generic;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantidade = int.Parse(Console.ReadLine());
            int pares = 0;
            int[] numero = new int[quantidade];
            string[] pe = new string[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                string[] bota = Console.ReadLine().Split(" ");

                numero[i] = int.Parse(bota[0]);
                pe[i] = bota[1];
            }

            var list = new List<int>(numero);
            var list2 = new List<string>(pe);

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list[i] == list[j] && list2[i] != list2[j])
                    {
                        pares++;

                        list.RemoveAt(i);
                        list.RemoveAt(j);
                        list2.RemoveAt(i);
                        list2.RemoveAt(j);
                        i--;
                        break;
                    }
                }
            }

            Console.WriteLine(pares);
        }
    }
}
