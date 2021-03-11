using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Problem5\input.txt");

            List<int> seatIds = new List<int>();

            foreach(var line in lines)
            {
                seatIds.Add(CalculateSeatId(line));
            }

            var output = CalculateMaxSeatId(seatIds);
            Console.WriteLine(output);

            seatIds.Sort();
            int prevItem = seatIds[0] - 1;
            foreach(var item in seatIds)
            {
                if(prevItem != item - 1)
                {
                    Console.WriteLine(item - 1);
                    break;
                }
                prevItem = item;
            }
        }

        public static int CalculateSeatId(string line)
        {
            var row = line.Substring(0, 7);
            var col = line.Substring(7, 3);

            var rowDec = ConvertBinaryToDecimal(ConvertToBinaryRow(row));
            var colDec = ConvertBinaryToDecimal(ConvertToBinaryCol(col));

            return rowDec * 8 + colDec;
        }

        public static string ConvertToBinaryRow(string row)
        {
            string binaryRowNum = "";
            foreach (var item in row.ToCharArray())
            {
                if (item == 'F')
                {
                    binaryRowNum = binaryRowNum + 0;
                }
                else
                {
                    binaryRowNum = binaryRowNum + 1;
                }
            }
            return binaryRowNum;
        }

        public static string ConvertToBinaryCol(string col)
        {
            string binaryColNum = "";
            foreach (var item in col.ToCharArray())
            {
                if (item == 'L')
                {
                    binaryColNum = binaryColNum + 0;
                }
                else
                {
                    binaryColNum = binaryColNum + 1;
                }
            }
            return binaryColNum;
        }

        public static int ConvertBinaryToDecimal(string num)
        {
            int decimalValue = 0;
            int binaryNumber = int.Parse(num);

            //base of decimal
            int base1 = 1;

            while (binaryNumber > 0)
            {
                int reminder = binaryNumber % 10;
                binaryNumber = binaryNumber / 10;
                decimalValue += reminder * base1;
                base1 = base1 * 2;
            }
            return decimalValue;
        }

        static int CalculateMaxSeatId(List<int> seatIds)
        {
            return seatIds.Max(x => x);
        }
    }
}
