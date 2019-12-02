using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1();
        }

        private static void Day1()
        {
            var result1 = Day1Puzzle1();
            Console.WriteLine($"day 1 puzzle 1: {result1}");

            var result2 = Day1Puzzle2();
            Console.WriteLine($"day 1 puzzle 2: {result2}");
        }

        private static long Day1Puzzle1()
        {
            var inputs = GetDay1Puzzle1Input("inputs/puzzle-1.txt");
            long result = 0;
            foreach (var input in inputs)
            {
                result += input / 3 - 2;
            }
            return result;
        }

        private static long Day1Puzzle2()
        {
            var inputs = GetDay1Puzzle1Input("inputs/puzzle-1.txt");
            long result = 0;
            foreach (var input in inputs)
            {
                var fuel = input / 3 - 2;
                result += fuel;
                while (true)
                {
                    fuel = fuel / 3 - 2;
                    if (fuel > 0)
                    {
                        result += fuel;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        private static List<long> GetDay1Puzzle1Input(string path)
        {
            var result = new List<long>();
            using var file = new StreamReader(path);
            var line = file.ReadLine();
            while (line != null)
            {
                result.Add(long.Parse(line));
                line = file.ReadLine();
            }
            return result;
        }
    }
}
