namespace AdventOfCode2022.Puzzles
{
    internal class Day6 : Puzzlebase
    {
        private readonly string _stream; 
        
        public Day6()
        {
            _stream = GetInput();
        }

        public override void SolvePart1()
        {
            int index = 3;
            foreach (char unused in _stream)
            {
                if (AreCharactersDistinct(index, 4))
                {
                    Console.WriteLine(index);
                    break;
                }

                index++;
            }
        }

        public override void SolvePart2()
        {
            int index = 13;
            foreach (char unused in _stream)
            {
                if (AreCharactersDistinct(index, 14))
                {
                    Console.WriteLine(index);
                    break;
                }

                index++;
            }
        }

        private bool AreCharactersDistinct(int index, int lenght)
        {
            var subArray = _stream.ToCharArray().SubArray(index - lenght, lenght);
            if (subArray.Length == 14)
            {
                return !HasRepeatedElements(subArray);
            }

            return false;
        }

        private bool HasRepeatedElements(char[] subArray)
        {
            return subArray.GroupBy(c => c).Any(g => g.Count() > 1);
        }

        private static string GetInput()
        {
            return File.ReadAllText(".\\Inputs\\Day6.txt");
        }
    }
}
