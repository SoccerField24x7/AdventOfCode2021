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
            var bingoCards = FileHelper.GetFileContents<string>("data/input.txt");

            List<int> numbers = bingoCards.First().Split(",").Select(int.Parse).ToList();

            // cycle through the rest of the "cards"
            List<BingoCard> cards = new();

            // remove the first row
            bingoCards = bingoCards.GetRange(2, bingoCards.Count - 2);

            // create the first card
            BingoCard card = new();
            List<Square> tempRow = new();
            
            foreach (string row in bingoCards)
            {
                if (string.IsNullOrEmpty(row))
                {
                    // card's done, add it to the stack and create a new one.
                    cards.Add(card);
                    card = new();
                    continue;
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

            // add the final card
            cards.Add(card);

            // OK, we have all of the cards... let's start calling those numbers and marking the cards.
            foreach (int number in numbers)
            {
                foreach (BingoCard bc in cards)
                {
                    bc.MarkNumberOnCard(number);
                }

                if (cards.Any(x => x.IsWinner))
                {
                    break;
                }
            }

            BingoCard winner = cards.Single(x => x.IsWinner);
            int unmarkedNumbers = winner.GetSumOfUnmarkedNumbers();

            Console.WriteLine(unmarkedNumbers * winner.WinningNumber);

            // Part II
            
            foreach (BingoCard c in cards)
            {
                c.ResetCard();
            }

            // call the numbers again
            foreach (int number in numbers)
            {
                foreach (BingoCard bc in cards)
                {
                    bc.MarkNumberOnCard(number);
                }

                if (cards.Any(x => x.IsWinner))
                {
                    break;
                }
            }
        }
    }
}
