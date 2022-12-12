namespace AdventOfCode2022.Puzzles
{
    internal class Day9 : Puzzlebase
    {
        private readonly string _input;

        public Day9()
        {
            _input = GetInput();
        }

        public override void SolvePart1()
        {
            var result = ProcessMoves(_input, 2).ToHashSet().Count;
            Console.WriteLine(result);
        }
        
        public override void SolvePart2()
        {
            var result = ProcessMoves(_input, 10).ToHashSet().Count;
            Console.WriteLine(result);
        }

        private IEnumerable<KnotPosition> ProcessMoves(string input, int ropeLength)
        {
            var rope = Enumerable.Repeat(new KnotPosition {Row = 0,Column = 0 }, ropeLength).ToArray();
            yield return rope.Last();

            foreach (var line in input.Split("\n"))
            {
                var parts = line.Split(' ');
                var direction = parts[0];
                var distance = int.Parse(parts[1]);

                for (var i = 0; i < distance; i++)
                {
                    MoveHeadAndTail(rope, direction);
                    yield return rope.Last();
                }
            }
        }

        void MoveHeadAndTail(KnotPosition[] rope, string direction)
        {
            rope[0] = direction switch
            {
                "U" => rope[0] = new KnotPosition { Row = rope[0].Row - 1 },
                "D" => rope[0] = new KnotPosition { Row = rope[0].Row + 1 },
                "L" => rope[0] = new KnotPosition { Column = rope[0].Column - 1 },
                "R" => rope[0] = new KnotPosition { Column = rope[0].Column + 1 },
                _ => throw new ArgumentException(direction)
            };

            //Move tail
            for (var i = 1; i < rope.Length; i++)
            {
                var drow = rope[i - 1].Row - rope[i].Row;
                var dcol = rope[i - 1].Column - rope[i].Column;

                if (Math.Abs(drow) > 1 || Math.Abs(dcol) > 1)
                {
                    rope[i] = new KnotPosition { Row = rope[i].Row + Math.Sign(drow), Column = rope[i].Column + Math.Sign(dcol)};
                }
            }
        }

        private string GetInput()
        {
            return File.ReadAllText(".\\Inputs\\Day9.txt");
        }

        private class KnotPosition
        {
            public int Row { get; init; }
            public int Column { get; init; }
        }
    }
}
