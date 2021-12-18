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

            // populate the list with lists of bits (1-12)
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

            // Part II

            bits.Clear();

            // re-populate the list with lists of ints (instructions)
            bits = reports.Select(report => report.Select(a => a - '0').ToArray().ToList()).ToList();

            var firstBitGroup = bits.GroupBy(n => n[0], (key, values) => new { Key = key, Count = values.Count() });

            // generate the initial lists
            List<List<int>> oxyGeneration = firstBitGroup.Where(x => x.Key == 1).First().Count > firstBitGroup.Where(x => x.Key == 0).First().Count
                ? bits.Where(x => x[0] == 1).ToList()
                : bits.Where(x => x[0] == 0).ToList();

            List<List<int>> co2Scrubber = firstBitGroup.Where(x => x.Key == 1).First().Count < firstBitGroup.Where(x => x.Key == 0).First().Count
                ? bits.Where(x => x[0] == 1).ToList()
                : bits.Where(x => x[0] == 0).ToList();

            for (var i = 1; oxyGeneration.Count() > 1; i++)
            {
                var grouped = oxyGeneration.GroupBy(x => x[i], (key, values) => new { Key = key, Count = values.Count() });

                oxyGeneration = grouped.Where(x => x.Key == 0).First().Count > grouped.Where(x => x.Key == 1).First().Count
                    ? oxyGeneration.Where(x => x[i] == 0).ToList()
                    : oxyGeneration.Where(x => x[i] == 1).ToList();
            }

            for (var i = 1; co2Scrubber.Count() > 1; i++)
            {
                var grouped = co2Scrubber.GroupBy(x => x[i], (key, values) => new { Key = key, Count = values.Count() });

                co2Scrubber = grouped.Where(x => x.Key == 0).First().Count > grouped.Where(x => x.Key == 1).First().Count
                    ? co2Scrubber.Where(x => x[i] == 1).ToList()
                    : co2Scrubber.Where(x => x[i] == 0).ToList();
            }

            Console.WriteLine(Convert.ToInt32(string.Join("", oxyGeneration.First().ToArray()), 2) * Convert.ToInt32(string.Join("", co2Scrubber.First().ToArray()), 2));
        }
    }
}
