using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // read in each line in file
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Aniket\Documents\Advent Of Code 2020\Day4\input.txt");

            HowManyPassportsAreValid(lines);
        }

        public static int HowManyPassportsAreValid(string[] lines)
        {
            List<List<string>> passports = new List<List<string>>();
            List<string> pass = new List<string>();
            for(int i = 0; i < lines.Length; i++)
            {
                pass.Add(lines[i]);
                if(lines[i].Length == 0)
                {
                    passports.Add(pass);
                    pass = new List<string>();
                }
            }
            passports.Add(pass);
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            foreach(var passport in passports)
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                foreach (var line in passport)
                {
                    foreach (var splitLine in line.Split(' '))
                    {
                        var keyValue = splitLine.Split(':');
                        if (line.Length != 0)
                        {
                            keyValues.Add(keyValue[0], keyValue[1]);
                            //Console.WriteLine(keyValue[0]);
                        }
                    }
                }
                keyValuePairs.Add(keyValues);
            }
            int numberOfValidItems = 0;
            int numberOfValid = 0;

            foreach (var item in keyValuePairs)
            {
                numberOfValidItems = 0;
                foreach(var key in item)
                {
                    Console.WriteLine(key.Value);
                    if(key.Key.Contains("ecl") && (key.Value.Contains("amb") || key.Value.Contains("blu") || key.Value.Contains("brn") || key.Value.Contains("gry") || key.Value.Contains("grn") || key.Value.Contains("hzl") || key.Value.Contains("oth")))
                    {
                        numberOfValidItems++;
                    }
                    else if(key.Key.Contains("pid") && key.Value.Length == 9)
                    {
                        numberOfValidItems++;
                    }
                    else if(key.Key.Contains("eyr") && key.Value.Length == 4 && Convert.ToInt32(key.Value) >= 2020 && Convert.ToInt32(key.Value) <= 2030)
                    {
                        numberOfValidItems++;
                    }
                    else if(key.Key.Contains("hcl"))
                    {
                        Regex regex = new Regex("^#[0-9|a-f]{6}$");
                        if(regex.Matches(key.Value.ToString()).Count > 0)
                        {
                            numberOfValidItems++;
                        }
                    }
                    else if (key.Key.Contains("byr") && key.Value.Length == 4 && Convert.ToInt32(key.Value) >= 1920 && Convert.ToInt32(key.Value) <= 2002)
                    {
                        numberOfValidItems++;
                    }
                    else if (key.Key.Contains("iyr") && key.Value.Length == 4 && Convert.ToInt32(key.Value) >= 2010 && Convert.ToInt32(key.Value) <= 2020)
                    {
                        numberOfValidItems++;
                    }
                    else if (key.Key.Contains("hgt"))
                    {
                        if(key.Value.Contains("in") && Convert.ToInt32(key.Value.Substring(0, key.Value.Length - 2)) >= 59 && Convert.ToInt32(key.Value.Substring(0, key.Value.Length - 2)) <= 76)
                        {
                            numberOfValidItems++;
                        }
                        else if (key.Value.Contains("cm") && Convert.ToInt32(key.Value.Substring(0, key.Value.Length - 2)) >= 150 && Convert.ToInt32(key.Value.Substring(0, key.Value.Length - 2)) <= 193)
                        {
                            numberOfValidItems++;
                        }
                    }
                }
                if(numberOfValidItems == 7)
                {
                    numberOfValid++;
                }
            }

                return numberOfValid;
        }
    }
}
