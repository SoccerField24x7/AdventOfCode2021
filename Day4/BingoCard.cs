
namespace AdventOfCode2021.Day4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BingoCard
    {
        private readonly int _squareSize;

        private List<List<Square>> _card = new();

        public bool IsWinner { get; set; }

        public BingoCard(int size)
        {
           _squareSize = size;
        }

        public BingoCard()
        {
            _squareSize = 5;
        }

        public void MarkNumberOnCard(int number)
        {
            foreach (var row in _card)
            {
                Square square = row.FirstOrDefault(x => x.Value == number);
                if (square != null)
                {
                    square.Marked = true;

                    // we marked a number, let's see if we have a winner!
                    if (IsBingo())
                        IsWinner = true;
                }
            }
        }

        public bool IsBingo()
        {
            // check vertical
            // check horizontal

            // set iswinner

            return false;
        }

        public void InitializeRow(List<Square> newRow)
        {
            if (newRow.Count != _squareSize)
            {
                throw new ArgumentException("The row is not of the correct size");
            }

            if (_card.Count == _squareSize)
            {
                throw new ArgumentException("The card already has the required number of rows.");
            }

            // make sure that none of the new row numbers exist on the card already
            foreach (List<Square> row in _card)
            {
                if (newRow.Any(x => row.Any(y => y.Value == x.Value)))
                {
                    throw new Exception("Duplicate number found in another row.");
                }
            }

            _card.Add(newRow);
        }

        private void CheckVeriticalBingos()
        {
            for (int i =0; i < _card[0].Count; i++)
            {
                bool bingo = true;
                foreach (List<Square> column in _card) // s/b row... todo
                {
                    if (!column[i].Marked)
                    {
                        bingo = false;
                        continue;
                    }
                }

                if (bingo)
                {
                    IsWinner = true;
                }
            }
        }

        private void CheckHorizontalBingos()
        {

        }

        private void CheckDiagonalBingos()
        {

        }
    }
}