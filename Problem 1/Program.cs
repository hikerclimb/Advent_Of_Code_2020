using System;
using System.Collections.Generic;

namespace Day1Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day1Problem1\input.txt");
            var list = new List<int>();
            foreach(string line in lines)
            {
                list.Add(Convert.ToInt32(line));
            }

            int n = list.Count;
            bool flip = false;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(list[i] + list[j] == 2020)
                    {
                        Console.WriteLine(list[i]*list[j]);
                        flip = true;
                        break;
                    }
                }
                if(flip == true)
                {
                    break;
                }
            }
        }
    }
}
