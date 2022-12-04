namespace AdventOfCode2022.Puzzles
{
    internal class Day3 : Puzzlebase
    {
        private readonly List<string> _allSacks;

        public Day3()
        {
            _allSacks = GetInput();
        }

        public override void SolvePart1()
        {
            int totalPriority = 0;

            foreach (var sack in _allSacks)
            {
                var part1 = sack.Take(sack.Length / 2).ToArray();
                var part2 = sack.Skip(sack.Length / 2).ToArray();
                var intersect = part1.Intersect(part2).First();
                int priority = GetPriority(intersect);
                totalPriority += priority;
            }

            Console.WriteLine(totalPriority);
        }

        public override void SolvePart2()
        {
            int totalPriority = 0;
            var teams = _allSacks.ToArray().Split(3);

            foreach (IEnumerable<string> team in teams)
            {
                if (!team.Any())
                {
                    continue;
                }

                var teamAsArray = team.ToArray();
                var badge = teamAsArray[0].Intersect(teamAsArray[1]).Intersect(teamAsArray[2]).First();
                int priority = GetPriority(badge);
                totalPriority += priority;
            }

            Console.WriteLine(totalPriority);
        }

        private static int GetPriority(char letter)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            return Array.IndexOf(alphabet, letter) + 1;
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day3.txt");
            return inputFile.Select(sack => new string(sack)).ToList();
        }
    }
}
