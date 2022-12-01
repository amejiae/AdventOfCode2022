namespace AdventOfCode2022.Puzzles
{
    internal class Day1 : Puzzlebase
    {
        private readonly List<int> _calories = new();

        public override void SolvePart1()
        {
            var inputs = GetInputAsList();
            int caloriesElf = 0;

            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input))
                {
                    _calories.Add(caloriesElf);
                    caloriesElf = 0;
                }
                else
                {
                    caloriesElf += int.Parse(input);
                }
            }

            Console.WriteLine(_calories.Max());
        }

        public override void SolvePart2()
        {
            var top3 = _calories.OrderByDescending(c => c).Take(3);
            Console.WriteLine(top3.Sum());
        }

        private List<string> GetInputAsList()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day1.txt");
            return inputFile.Select(inputLine => inputLine).ToList();
        }
    }
}
