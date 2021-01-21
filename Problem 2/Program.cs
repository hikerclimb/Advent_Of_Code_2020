using System;
using System.Collections.Generic;

namespace Day1Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day1Problem2\input.txt");
            var list = new List<int>();
            foreach (string line in lines)
            {
                list.Add(Convert.ToInt32(line));
            }

            int n = list.Count;
            bool flip = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (list[i] + list[j] + list[k] == 2020)
                        {
                            Console.WriteLine(list[i] * list[j] * list[k]);
                            flip = true;
                            break;
                        }
                    }
                }
                if (flip == true)
                {
                    break;
                }
            }
        }
    }
}
