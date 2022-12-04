namespace AdventOfCode2022.Puzzles
{
    internal class Day4 : Puzzlebase
    {
        private readonly List<string> _allAsignments;

        public Day4()
        {
            _allAsignments = GetInput();
        }

        public override void SolvePart1()
        {
            int duplicatedAssigments = 0;
            foreach (string asignment in _allAsignments)
            {
                var tasks = asignment.Split(',');
                var startAndEnd1 = tasks[0].Split('-');
                var startAndEnd2 = tasks[1].Split('-');

                var range1 = new Range(int.Parse(startAndEnd1[0]), int.Parse(startAndEnd1[1]));
                var range2 = new Range(int.Parse(startAndEnd2[0]), int.Parse(startAndEnd2[1]));

                if (range1.ContainsRange(range2) || range2.ContainsRange(range1))
                {
                    duplicatedAssigments++;
                }
            }

            Console.WriteLine(duplicatedAssigments);
        }

        public override void SolvePart2()
        {
            int duplicatedAssigments = 0;
            foreach (string asignment in _allAsignments)
            {
                var tasks = asignment.Split(',');
                var startAndEnd1 = tasks[0].Split('-');
                var startAndEnd2 = tasks[1].Split('-');

                var range1 = new Range(int.Parse(startAndEnd1[0]), int.Parse(startAndEnd1[1]));
                var range2 = new Range(int.Parse(startAndEnd2[0]), int.Parse(startAndEnd2[1]));

                if (range1.OverlapsRange(range2) || range2.OverlapsRange(range1))
                {
                    duplicatedAssigments++;
                }
            }

            Console.WriteLine(duplicatedAssigments);
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day4.txt");
            return inputFile.Select(sack => new string(sack)).ToList();
        }

        
    }
}
