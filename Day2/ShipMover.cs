namespace Advent2021.Day2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Advent2021.Constants;
    
    public class ShipMover
    {
        public static ManhattanLocation MoveInDirection(ManhattanLocation currentPosition, int directionFacing, int amount, int multiplier = 1)
        {
            ManhattanLocation endingPosition = new(currentPosition.HorizontalPosition, currentPosition.VerticalPosition);

            switch (directionFacing)
            {
                // case Direction.EAST:
                case Direction.FORWARD:
                    endingPosition.HorizontalPosition += amount * multiplier;
                    break;

                // case Direction.WEST:
                case Direction.BACKWARD:
                    endingPosition.HorizontalPosition -= amount * multiplier;
                    break;

                // case Direction.NORTH:
                case Direction.DOWN:
                    endingPosition.VerticalPosition += amount * multiplier;
                    break;

                // case Direction.SOUTH:
                case Direction.UP:
                    endingPosition.VerticalPosition -= amount * multiplier;
                    break;

                default:
                    throw new Exception("Invalid move direction.");
            }

            return endingPosition;
        }
    }
}