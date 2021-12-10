using System;
using Advent2021.Helpers;
using Advent2021.Constants;

namespace Advent2021.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = FileHelper.GetFileContents<string>("data/input.txt");

            var shipPosition = new ManhattanLocation();

            foreach (string instruction in instructions)
            {
                string[] parts = instruction.Split(" ");

                switch (parts[0])
                {
                    case "up":
                        shipPosition = ShipMover.MoveForward(shipPosition, Constants.Direction.UP, int.Parse(parts[1]));
                        break;
                    case "down":
                        shipPosition = ShipMover.MoveForward(shipPosition, Constants.Direction.DOWN, int.Parse(parts[1]));
                        break;
                    case "forward":
                        shipPosition = ShipMover.MoveForward(shipPosition, Constants.Direction.FORWARD, int.Parse(parts[1]));
                        break;
                    default:
                        throw new InvalidOperationException("The requested direction was invalid.");
                }
            }

            Console.WriteLine(shipPosition.HorizontalPosition * shipPosition.VerticalPosition);

        }
    }
}
