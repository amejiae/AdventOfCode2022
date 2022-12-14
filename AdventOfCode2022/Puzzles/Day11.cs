using System.Text;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class Day11 : Puzzlebase
    {
        private List<Monkey> _monkeys = new();
        private const int _rounds = 20;

        public Day11()
        {
            var input = GetInput();
            var sb = new StringBuilder();
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var monkey = new Monkey(sb.ToString());
                    _monkeys.Add(monkey);
                    sb.Clear();
                    continue;
                }

                sb.AppendLine(line);
            }

            _monkeys.Add(new Monkey(sb.ToString()));
        }

        public override void SolvePart1()
        {
        }

        public override void SolvePart2()
        {
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day11.txt");
            return inputFile.Select(ins => new string(ins)).ToList();
        }
    }
}
