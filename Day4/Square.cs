using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    public class Square
    {
        public Square(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public bool Marked { get; set; }
    }
}