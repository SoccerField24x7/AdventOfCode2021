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

            int _winCounter = 0;

            // call the numbers again, this time keep going until we have no winning cards (or run out of numbers)
            foreach (int number in numbers)
            {
                foreach (BingoCard bc in cards.Where(x => !x.IsWinner))
                {
                    bc.MarkNumberOnCard(number);

                    // if this is a winner, let's capture the order
                    if (bc.IsWinner)
                    {
                        bc.WinSequence = _winCounter++;
                    }
                }

                if (cards.All(x => x.IsWinner))
                {
                    break;
                }
            }

            // get the last winner
            winner = cards.Where(x => x.IsWinner).OrderByDescending(x => x.WinSequence).First();

            unmarkedNumbers = winner.GetSumOfUnmarkedNumbers();

            Console.WriteLine(unmarkedNumbers * winner.WinningNumber);
        }
    }
}
