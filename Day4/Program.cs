﻿namespace AdventOfCode2021.Day4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Advent2021.Helpers;

    class Program
    {
        static void Main(string[] args)
        {
            var bingo = FileHelper.GetFileContents<string>("data/input.txt");

            List<int> numbers = bingo.First().Split(",").Select(int.Parse).ToList();

            // cycle through the rest of the "cards"
            List<BingoCard> cards = new();

            // BingoCard card = new();

            // // move these to unit tests
            // Square a = new Square(55);
            // Square b = new Square(23);
            // Square c = new Square(6);
            // Square d = new Square(1);
            // Square e = new Square(11);

            // List<Square> tmp = new() { a, b, c, d , e };

            // card.InitializeRow(tmp);

            // a = new Square(44);
            // b = new Square(2);
            // c = new Square(3);
            // d = new Square(17);
            // e = new Square(18);

            // card.InitializeRow(new List<Square>{ a, b, c, d, e });

            // remove the first row
            bingo = bingo.GetRange(2, bingo.Count - 2);

            // create a card
            BingoCard card = new();
            List<Square> tempRow = new();
            
            foreach (string row in bingo)
            {
                if (string.IsNullOrEmpty(row))
                {
                    cards.Add(card);
                    card = new();
                }

                var nums = row.Split(" ");

                foreach (string num in nums)
                {
                    // because of extra spaces for alignment in the txt file, there will be blanks
                    if (!string.IsNullOrEmpty(num))
                    {
                        tempRow.Add(new Square(num));
                    }                    
                }

                card.InitializeRow(tempRow);
                tempRow = new();
            }

        }
    }
}
