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
                        shipPosition = ShipMover.MoveInDirection(shipPosition, Direction.UP, int.Parse(parts[1]));
                        break;
                    case "down":
                        shipPosition = ShipMover.MoveInDirection(shipPosition, Direction.DOWN, int.Parse(parts[1]));
                        break;
                    case "forward":
                        shipPosition = ShipMover.MoveInDirection(shipPosition, Direction.FORWARD, int.Parse(parts[1]));
                        break;
                    default:
                        throw new InvalidOperationException("The requested direction was invalid.");
                }
            }

            Console.WriteLine(shipPosition.HorizontalPosition * shipPosition.VerticalPosition);

            // Part II
            shipPosition.SetPosition(0, 0);
            ManhattanLocation aim = new ManhattanLocation();

            foreach (string instruction in instructions)
            {
                string[] parts = instruction.Split(" ");

                switch (parts[0])
                {
                    case "up":
                        aim = ShipMover.MoveInDirection(aim, Direction.UP, int.Parse(parts[1]));
                        break;
                    case "down":
                        aim = ShipMover.MoveInDirection(aim, Direction.DOWN, int.Parse(parts[1]));
                        break;
                    case "forward":
                        shipPosition = ShipMover.MoveInDirection(shipPosition, Direction.FORWARD, int.Parse(parts[1])); // move horizontal position
                        shipPosition = ShipMover.MoveInDirection(shipPosition, Direction.DOWN, int.Parse(parts[1]), aim.VerticalPosition); // move vertical position
                        break;
                    default:
                        throw new InvalidOperationException("The requested direction was invalid.");
                }
            }

            Console.WriteLine(shipPosition.HorizontalPosition * shipPosition.VerticalPosition);
        }
    }
}
