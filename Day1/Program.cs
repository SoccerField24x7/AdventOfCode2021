using System;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Helpers;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var depths = FileHelper.GetFileContents<int>("./data/input.txt");

            int higher = 0;
            int lower = 0;

            for (int i=1; i < depths.Count; i++)
            {
                if (depths[i] > depths[i-1])
                {
                    higher++;
                }
                else if (depths[i] < depths[i-1])
                {
                    lower++;
                }
            }

            Console.WriteLine(higher); // answer A

            List<int> sums = new();
            higher = 0;
            lower = 0;

            for (int i=0; i < depths.Count - 2; i++)
            {
                sums.Add(depths.GetRange(i, 3).Sum());
            }

            for (int i=1; i < sums.Count; i++)
            {
                if (sums[i] > sums[i-1])
                {
                    higher++;
                }
                else if (sums[i] < sums[i-1])
                {
                    lower++;
                }
            }
            
            Console.WriteLine(higher); // answer B
        }
    }
}
