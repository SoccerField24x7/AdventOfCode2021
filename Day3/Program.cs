namespace AdventOfCode2021.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Advent2021.Helpers;

    class Program
    {
        static void Main(string[] args)
        {
            var reports = FileHelper.GetFileContents<string>("data/input.txt");
            List<List<int>> bits = new();

            foreach (string report in reports)
            {
                for (int i=0; i < report.Length; i++)
                {
                    if (bits.Count < i + 1)
                    {
                        bits.Add(new List<int>());
                    }
                    
                    bits[i].Add(int.Parse(report[i].ToString()));
                    
                }
            }
            
            string gamma = "";
            string epsilon = "";

            // build gamma and epsilon based on least/most common digit in each position
            for (int i=0; i < bits.Count; i++)
            {
                int a = bits[i].Count(x => x == 1);
                int b = bits[i].Count(x => x == 0);

                gamma += a > b ? "1" : "0";
                epsilon += a < b ? "1" : "0";
            }

            Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));

        }
    }
}
