using System.Text;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class Day11 : Puzzlebase
    {
        private readonly List<Monkey> _monkeys = new();

        public Day11()
        {
            PopulateMonkeys();
        }
        
        public override void SolvePart1()
        {
            int roundCounter = 0;
            while (roundCounter < 20)
            {
                foreach (var monkey in _monkeys)
                {
                    List<int> itemsToRemove = new List<int>();
                    foreach (var item in monkey.StartingItems)
                    {
                        var operation = monkey.Operation;
                        int newWorry = GetNewWorry(item, operation);
                        decimal lowerWorry = newWorry / 3;
                        var roundedWorry = Math.Round(lowerWorry, MidpointRounding.ToZero);

                        if (roundedWorry % monkey.Test == 0)
                        {
                            itemsToRemove.Add(item);
                            _monkeys.First(m => m.MonkeyNumber == monkey.True).StartingItems.Add((int) roundedWorry);
                            
                        }
                        else
                        {
                            itemsToRemove.Add(item);
                            _monkeys.First(m => m.MonkeyNumber == monkey.False).StartingItems.Add((int)roundedWorry);
                        }

                        monkey.ItemsCheckCount++;
                    }
                    itemsToRemove.ForEach(i => monkey.StartingItems.Remove(i));
                }
                roundCounter++;
            }

            var monkeyBusiness = _monkeys.OrderByDescending(m => m.ItemsCheckCount).Take(2).ToList();
            Console.WriteLine(monkeyBusiness[0].ItemsCheckCount * monkeyBusiness[1].ItemsCheckCount);
        }

        public override void SolvePart2()
        {
            int roundCounter = 0;
            while (roundCounter < 10000)
            {
                foreach (var monkey in _monkeys)
                {
                    List<int> itemsToRemove = new List<int>();
                    foreach (var item in monkey.StartingItems)
                    {
                        var operation = monkey.Operation;
                        int newWorry = GetNewWorry(item, operation);

                        if (newWorry % monkey.Test == 0)
                        {
                            itemsToRemove.Add(item);
                            _monkeys.First(m => m.MonkeyNumber == monkey.True).StartingItems.Add(newWorry);
                        }
                        else
                        {
                            itemsToRemove.Add(item);
                            _monkeys.First(m => m.MonkeyNumber == monkey.False).StartingItems.Add(newWorry);
                        }

                        monkey.ItemsCheckCount++;
                    }
                    itemsToRemove.ForEach(i => monkey.StartingItems.Remove(i));
                }
                roundCounter++;
            }

            var monkeyBusiness = _monkeys.OrderByDescending(m => m.ItemsCheckCount).Take(2).ToList();
            Console.WriteLine(monkeyBusiness[0].ItemsCheckCount * monkeyBusiness[1].ItemsCheckCount);
        }

        private int GetNewWorry(int item, Operation operation)
        {
            if (operation.Value == 9999)
                return item * item;

            if (operation.Operand == '*')
                return operation.Value * item;

            if (operation.Operand == '+')
                return operation.Value + item;

            return operation.Value;
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day11.txt");
            return inputFile.Select(ins => new string(ins)).ToList();
        }

        private void PopulateMonkeys()
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
    }
}
