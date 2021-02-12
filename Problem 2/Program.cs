using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidStringOrNotResult());
            Console.WriteLine(ValidSingleOccurenceResult());
        }

        private static int ValidStringOrNotResult() 
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day2Problem1\input.txt");
            int validPasswords = 0;
            foreach(var line in lines)
            {
                if(ValidStringOrNot(line)== true)
                {
                    validPasswords++;
                }
            }
            return validPasswords;
        }

        private static int ValidSingleOccurenceResult()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day2Problem1\input.txt");
            int validPasswords = 0;
            foreach (var line in lines)
            {
                if (ValidSingleOccurence(line) == true)
                {
                    validPasswords++;
                }
            }
            /*var line = "5-6 d: dcdddhzld";
            ValidSingleOccurence(line);
            var validPasswords = 0;*/
            return validPasswords;
        }


        private static bool ValidStringOrNot(string line)
        {
            var itemsSplit = line.Split(':');
            int counter = 0;
            string[] nOTIMOIP_LWOMTIP = new string[2];

            nOTIMOIP_LWOMTIP = itemsSplit[0].Split(' ');

            foreach (var str in itemsSplit[1])
            {
                if (str == Convert.ToChar(nOTIMOIP_LWOMTIP[1]))
                {
                    counter++;
                }
            }
            var minNumberAndMaxNumber = nOTIMOIP_LWOMTIP[0].Split("-");
            if (counter < Convert.ToInt32(minNumberAndMaxNumber[0]) || counter > Convert.ToInt32(minNumberAndMaxNumber[1]))
            {
                return false;
            }
            return true;
        }

        private static bool ValidSingleOccurence(string line)
        {
            var itemsSplit = line.Split(':');
            string[] nOTIMOIP_LWOMTIP = new string[2];

            nOTIMOIP_LWOMTIP = itemsSplit[0].Split(' ');
            List<int> posMatch = new List<int>();
            var minNumberAndMaxNumber = nOTIMOIP_LWOMTIP[0].Split("-");
            itemsSplit[1] = itemsSplit[1].Trim();
            for (int i = 0; i < itemsSplit[1].Length; i++)
            {
                //character matches and position matches 
                if (itemsSplit[1][i] == Convert.ToChar(nOTIMOIP_LWOMTIP[1]) && (i + 1 == Convert.ToInt32(minNumberAndMaxNumber[0]) || i + 1== Convert.ToInt32(minNumberAndMaxNumber[1])))
                {
                    posMatch.Add(i);
                }
            }
            
            bool result = false;
            //check position matches either the min or  max
            /*foreach (var pos in posMatch)
            {
                if (Convert.ToInt32(minNumberAndMaxNumber[0]) != pos && Convert.ToInt32(minNumberAndMaxNumber[1]) != pos)
                {
                    result = false;
                }
                else if(Convert.ToInt32(minNumberAndMaxNumber[0]) == pos && Convert.ToInt32(minNumberAndMaxNumber[1]) != pos)
                {
                    result = true;
                    break;
                }
                else if (Convert.ToInt32(minNumberAndMaxNumber[0]) != pos && Convert.ToInt32(minNumberAndMaxNumber[1]) == pos)
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }*/
            if(posMatch.Count ==1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
