
namespace AdventOfCode2021.Day4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BingoCard
    {
        private readonly int _squareSize;

        private List<List<Square>> card = new();

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

        }

        public bool IsBingo()
        {
            // check vertical
            // check horizontal

            // set iswinner
        }

        public void InitRow(List<Square> row)
        {
            if (row.Count != _squareSize)
            {
                throw new ArgumentException("The row is not of the correct size");
            }

            if (card.Count == _squareSize)
            {
                throw new ArgumentException("The card already has the required number of rows.");
            }

            card.Add(row);
        }

        private void CheckVeriticalBingos()
        {

        }

        private void CheckHorizontalBingos()
        {

        }

        private void CheckDiagonalBingos()
        {

        }
    }
}