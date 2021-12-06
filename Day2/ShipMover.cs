namespace Advent2021.Day2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Advent2021.Constants;
    
    public class ShipMover
    {
        public static ManhattanLocation MoveForward(ManhattanLocation position, int directionFacing, int amount, int multiplier = 1)
        {
            ManhattanLocation endingPosition = new(position.HorizontalPosition, position.VerticalPosition);

            switch (directionFacing)
            {
                case Direction.EAST:
                    endingPosition.HorizontalPosition += amount * multiplier;
                    break;

                case Direction.WEST:
                    endingPosition.HorizontalPosition -= amount * multiplier;
                    break;

                case Direction.NORTH:
                    endingPosition.VerticalPosition += amount * multiplier;
                    break;

                case Direction.SOUTH:
                    endingPosition.VerticalPosition -= amount * multiplier;
                    break;

                default:
                    throw new Exception("Invalid move direction.");
            }

            return endingPosition;
        }
    }
}