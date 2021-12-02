using System;
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
                Console.WriteLine(depths[i]);
            }
        }
    }
}
