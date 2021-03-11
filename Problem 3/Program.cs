using System;
using System.Collections.Generic;

namespace Day3_Problem1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Program.ReadInput(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day3_Problem1\input.txt");
            //Program.PrintList(input);
            long ou = Program.FindNumberOfTrees(3, 1, input);
            Console.WriteLine(ou);
            //Part 2
            long thirdPart = ThirdPart(input, ou);
            Console.WriteLine(thirdPart);
        }

        public static long ThirdPart(List<char[]> input, long ou)
        {
            long firstPart = Program.FindNumberOfTrees(1, 1, input);
            Console.WriteLine(firstPart);
            Console.WriteLine(ou);
            long thirdPart = Program.FindNumberOfTrees(5, 1, input);
            Console.WriteLine(thirdPart);
            long fourthPart = Program.FindNumberOfTrees(7, 1, input);
            Console.WriteLine(fourthPart);
            int fifthPart = Program.FindNumberOfTrees(1, 2, input);
            Console.WriteLine(fifthPart);
            long variable = 0L;
            variable = (long)  firstPart * ou * thirdPart * fourthPart * fifthPart;
            Console.WriteLine(variable);
            return variable;
        }

        public static int FindNumberOfTrees(int right, int down, List<char[]> input)
        {
            //var input = ReadInput(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day3_Problem1\input.txt");

            int j = 0;
            int counter = 0;
            for(int i = down; i < input.Count; i = i + down)
            {
                j = (j + right) % input[j].Length;
                //Console.WriteLine("i:" + i + "j:" + j);
                if (input[i][j] == '#')
                {
                    counter++;
                }
            }
            //Console.WriteLine();
            return counter;
        }

        public static List<char[]> ReadInput(string path)
        {
            string[] input = System.IO.File.ReadAllLines(path);
            List<char[]> list = new List<char[]>();
            foreach(var str in input)
            {
                list.Add(str.ToCharArray());
            }
            return list;
        }

        public static void PrintList(List<char[]> list)
        {
            foreach (var row in list)
            {
                foreach (var chr in row)
                {
                    Console.Write(chr);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
