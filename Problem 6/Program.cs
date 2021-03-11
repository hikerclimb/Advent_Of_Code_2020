using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day6
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day6\input.txt");
            var groups = CreateGroups(lines);
            var output = SumOfGroupTotalQuestionsAnsweredYes(groups);
            Console.WriteLine(output);

            var PartTwo = SumOfTotalForEveryoneInTheGroup(groups);
            Console.WriteLine(PartTwo);
        }

        public static List<List<string>> CreateGroups(string[] lines)
        {
            List<List<string>> groups = new List<List<string>>();
            List<string> group = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length != 0)
                {
                    group.Add(lines[i]);
                }
                if (lines[i].Length == 0)
                {
                    groups.Add(group);
                    group = new List<string>();
                }
            }
            groups.Add(group);
            return groups;
        }

        public static int SumOfGroupTotalQuestionsAnsweredYes(List<List<string>> groups)
        {
            var dict = GetCharacterFrequencyInGroups(groups);
            List<int> groupTotals = new List<int>();
            foreach (var group in dict)
            {
                int i = 0;
                foreach (var keyVal in group)
                {
                    if(keyVal.Value >= 1)
                    {
                        i++;
                    }
                }
                groupTotals.Add(i);
            }
            int output = 0;
            foreach(var numberOfUniqueLettersInEachGroup in groupTotals)
            {
                output += numberOfUniqueLettersInEachGroup;
            }
            return output;
        }

        public static int SumOfTotalForEveryoneInTheGroup(List<List<string>> groups)
        {
            List<int> groupTotals = new List<int>();
            foreach(var group in groups)
            {
                var dict = GetCharacterFrequencyInGroup(group);
                int i = 0;
                foreach (var keyVal in dict)
                {
                    if (group.Count == keyVal.Value)
                    {
                        i++;
                    }
                }
                groupTotals.Add(i);
            }
            int output = 0;
            foreach (var numberOfUniqueLettersInEachGroup in groupTotals)
            {
                output += numberOfUniqueLettersInEachGroup;
            }
            return output;
        }

        public static List<Dictionary<char, int>> GetCharacterFrequencyInGroups(List<List<string>> groups)
        {
            List<Dictionary<char, int>> dict = new List<Dictionary<char, int>>();
            foreach(var group in groups)
            {
                Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
                foreach (var line in group)
                {
                    foreach(var ch in line)
                    {
                        if (keyValuePairs.ContainsKey(ch))
                            keyValuePairs[ch]++;
                        else
                            keyValuePairs[ch] = 1;
                    }
                }
                dict.Add(keyValuePairs);
            }
            return dict;
        }

        private static Dictionary<char, int> GetCharacterFrequencyInGroup(List<string> group)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            foreach (var line in group)
            {
                foreach (var ch in line)
                {
                    if (keyValuePairs.ContainsKey(ch))
                        keyValuePairs[ch]++;
                    else
                        keyValuePairs[ch] = 1;
                }
            }
            return keyValuePairs;
        }

public static void PrintKeyValuePairsForGroups(List<Dictionary<char, int>> pairs)
        {
            foreach(var dict in pairs)
            {
                foreach(var keyVal in dict)
                {
                    Console.WriteLine("key:" + keyVal.Key + "value:" + keyVal.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
