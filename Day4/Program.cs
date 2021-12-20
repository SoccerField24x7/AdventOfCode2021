namespace AdventOfCode2021.Day4
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

            // remove the first row?

            // cycle through the rest of the "cards"
            List<BingoCard> cards = new();

            BingoCard card = new();

            Square a = new Square(55);
            Square b = new Square(23);
            Square c = new Square(6);
            Square d = new Square(1);
            Square e = new Square(11);

            List<Square> tmp = new() { a, b, c, d , e };

            card.InitializeRow(tmp);

            a = new Square(44);
            b = new Square(2);
            c = new Square(3);
            d = new Square(11);
            e = new Square(18);

            card.InitializeRow(new List<Square>{ a, b, c, d, e });
            

        }
    }
}
