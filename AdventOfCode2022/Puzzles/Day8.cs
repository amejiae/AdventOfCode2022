namespace AdventOfCode2022.Puzzles
{
    internal class Day8 : Puzzlebase
    {
        private readonly int[,] _input;
        private readonly int _rows;
        private readonly int _columns;

        public Day8()
        {
            _input = GetInput();
            _rows = _input.GetLength(0);
            _columns = _input.GetLength(1);
        }

        public override void SolvePart1()
        {
            int tallTreeCounter = 0;
            int x = 1;


            while (x < _rows - 1)
            {
                int y = 1;
                while (y < _columns - 1)
                {
                    if (IsTreeVisible(x, y, _input[x,y]))
                    {
                        tallTreeCounter++;
                    }

                    y++;
                }

                x++;
            }

            var edgeTrees = (_columns + _rows) + (_rows - 2) * 2));
            Console.WriteLine(tallTreeCounter + edgeTrees);
        }

        private bool IsTreeVisible(int row, int column, int value)
        {
            //Look Up
            int index = row;
            while (index > 0)
            {
                index--;
                if (index == 0 && _input[index, column] <= value)
                {
                    return true;
                }

                if (_input[index, column] >= value)
                {
                    break;
                }
            }

            //Look Down
            index = row;
            while (index > 0)
            {
                index++;
                if (index == _rows && _input[index - 1, column] <= value)
                {
                    return true;
                }

                if (_input[index, column] >= value)
                {
                    break;
                }

            }

            //Look Right
            index = column;
            while (index > 0)
            {
                index++;
                if (index == _columns && _input[row, index - 1] <= value)
                {
                    return true;
                }

                if (_input[row, index] >= value)
                {
                    break;
                }
            }

            //Look Left
            index = column;
            while (index > 0 && _input[index, column] <= value)
            {
                index--;
                if (index == 0 && _input[row, index] <= value)
                {
                    return true;
                }

                if (_input[row, index] >= value)
                {
                    break;
                }
            }

            return false;
        }


        public override void SolvePart2()
        {

        }

        private int[,] GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day8.txt");
            var lines = inputFile.Select(sack => new string(sack)).ToList();
            var columns = lines[0].ToCharArray().Length;

            int[,] newArray = new int[lines.Count, columns];
            int lineCounter = 0;

            foreach (string line in lines)
            {
                int charCounter = 0;
                foreach (char character in line)
                {
                    newArray[lineCounter, charCounter] = int.Parse(character.ToString());
                    charCounter++;
                }

                lineCounter++;
            }

            return newArray;
        }
    }
}
