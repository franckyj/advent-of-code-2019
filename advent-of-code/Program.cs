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
            Day2();
        }

        #region day1

        private static void Day1()
        {
            var result1 = Day1Puzzle1();
            WriteResult(1, 1, result1);

            var result2 = Day1Puzzle2();
            WriteResult(1, 2, result1);
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
            using (var file = new StreamReader(path))
            {
                var line = file.ReadLine();
                while (line != null)
                {
                    result.Add(long.Parse(line));
                    line = file.ReadLine();
                }
                return result;
            }
        }

        #endregion

        #region day2

        private static void Day2()
        {
            var input = new StreamReader("inputs/puzzle-2-1.txt").ReadToEnd();
            var result1 = Day2Puzzle1(input);
            WriteResult(2, 1, result1);

            //var result2 = Day2Puzzle2(input);
            //WriteResult(2, 2, result2);

            Console.ReadKey();
        }

        private static int Day2Puzzle1(string input)
        {
            var numbers = input.Split(',').Select(i => int.Parse(i)).ToArray();

            // replacements
            numbers[1] = 12;
            numbers[2] = 2;

            var intcodeComputer = new IntcodeComputer();
            numbers = intcodeComputer.Compute(numbers);
            return numbers[0];
        }

        private static (int Noun, int Verb) Day2Puzzle2(string input)
        {
            var numbers = input.Split(',').Select(i => int.Parse(i)).ToArray();

            // replacements
            numbers[1] = 22;
            numbers[2] = 54;

            // 1 433 555
            // [1] * 810 000 + (1870666 + [2])
            // 19 690 720
            // 0 0 1870666
            // 0 1 1870667
            // 0 2 1870668
            // 1 0 2680666
            // 1 1 2680667
            // 1 2 2680668
            // 2 0 3490666
            // 3 0 4300666

            var intcodeComputer = new IntcodeComputer();
            numbers = intcodeComputer.Compute(numbers);
            return (22, 54);
        }

        private static void WriteResult(int day, int puzzle, object result)
        {
            Console.WriteLine($"day {day} puzzle {puzzle}: {result}");
        }

        #endregion
    }

    public class IntcodeComputer
    {
        public int[] Compute(int[] memory)
        {
            var index = 0;
            int input1, input2, output;
            var ended = false;
            while (!ended)
            {
                var value = memory[index];
                switch (value)
                {
                    case 1:
                        input1 = memory[index + 1];
                        input2 = memory[index + 2];
                        output = memory[index + 3];
                        memory[output] = memory[input1] + memory[input2];
                        index += 4;
                        break;
                    case 2:
                        input1 = memory[index + 1];
                        input2 = memory[index + 2];
                        output = memory[index + 3];
                        memory[output] = memory[input1] * memory[input2];
                        index += 4;
                        break;
                    case 99:
                        ended = true;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            return memory;
        }
    }
}
