using AdventOfCode2022.Puzzles;

namespace AdventOfCode2022.Models
{
    internal class Monkey
    {
        public Monkey(string data)
        {
            foreach (var line in data.Split('\n'))
            {
                if (line.Contains("Monkey"))
                    MonkeyNumber = GetIntFromString(line);

                if (line.Contains("Starting"))
                    StartingItems = GetStartingItems(line);

                if (line.Contains("Operation"))
                    Operation = GetOperation(line);

                if (line.Contains("Test"))
                    Test = GetIntFromString(line);

                if (line.Contains("true"))
                    True = GetIntFromString(line);

                if (line.Contains("false"))
                    False = GetIntFromString(line);

            }
        }

        private Operation GetOperation(string line)
        {
            var operation = new Operation();
            var operand = line.Substring(line.IndexOf('d') + 2, 1);
            var value = GetIntFromString(line);

            operation.Operand = operand.ToCharArray()[0];
            operation.Value = value;
            return operation;
        }

        private List<int> GetStartingItems(string line)
        {
            List<int> startingItems = new List<int>();
            var stringItems = line[line.IndexOf(':')..];

            var items = stringItems.Split(',');
            foreach (var item in items)
            {
                startingItems.Add(GetIntFromString(item));
            }

            return startingItems;
        }

        private static int GetIntFromString(string line)
        {
            var success = int.TryParse(new string(line.Where(char.IsDigit).ToArray()), out var result);
            if (!success)
                return 9999;

            return result;
        }

        public int MonkeyNumber { get; set; }
        public List<int> StartingItems { get; init; } = new();
        public Operation Operation { get; init; } = new();
        public int Test { get; init; }
        public int True { get; init; }
        public int False { get; init; }
        public long ItemsCheckCount { get; set; } = 0;
    }
}
