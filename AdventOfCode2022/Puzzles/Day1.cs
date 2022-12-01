namespace AdventOfCode2022.Puzzles
{
    internal class Day1 : ProgramBase
    {
        public override void SolvePart1()
        {
            var inputs = GetInputAsList();
            List<int> calories = new List<int>();
            int caloriesElf = 0;

            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input))
                {
                    calories.Add(caloriesElf);
                    caloriesElf = 0;
                }
                else
                {
                    caloriesElf += int.Parse(input);
                }
            }

            Console.WriteLine(calories.Max());
        }

        public override void SolvePart2()
        {

        }

        private List<string> GetInputAsList()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day1.txt");
            return inputFile.Select(inputLine => inputLine).ToList();
        }
    }
}
