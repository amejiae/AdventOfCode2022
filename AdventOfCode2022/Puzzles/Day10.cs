namespace AdventOfCode2022.Puzzles
{
    internal class Day10 : Puzzlebase
    {
        private readonly List<string> _instructions;
        private readonly char[] _crt = new char[240];

        public Day10()
        {
            _instructions = GetInput();
        }

        public override void SolvePart1()
        {
            int cycles = 0;
            int x = 1;
            int signalStrenght = 0;
            int signalStrenghtCheckmark = 20;
            int totalSignalStrenght = 0;
            int index = 1;

            foreach (var ins in _instructions)
            {
                string[] instruction = ins.Split(' ');
                string command = instruction[0];

                if (command == "noop")
                {
                    if (cycles == signalStrenghtCheckmark)
                    {
                        signalStrenght = signalStrenghtCheckmark * x;
                        totalSignalStrenght += signalStrenght;
                        signalStrenghtCheckmark += 40;
                    }
                    cycles++;
                    if (cycles == signalStrenghtCheckmark)
                    {
                        signalStrenght = signalStrenghtCheckmark * x;
                        totalSignalStrenght += signalStrenght;
                        signalStrenghtCheckmark += 40;
                    }
                }
                else if (command == "addx")
                {
                    cycles++;
                    if (cycles == signalStrenghtCheckmark)
                    {
                        signalStrenght = signalStrenghtCheckmark * x;
                        totalSignalStrenght += signalStrenght;
                        signalStrenghtCheckmark += 40;
                    }
                    int value = int.Parse(instruction[1]);
                    cycles++;
                    if (cycles == signalStrenghtCheckmark)
                    {
                        signalStrenght = signalStrenghtCheckmark * x;
                        totalSignalStrenght += signalStrenght;
                        signalStrenghtCheckmark += 40;
                    }
                    x += value;
                }

                index++;
            }

            Console.WriteLine(totalSignalStrenght);
        }

        public override void SolvePart2()
        {
            int cycles = 0;
            int x = 1;
            int totalSignalStrenght = 0;

            foreach (var ins in _instructions)
            {
                string[] instruction = ins.Split(' ');
                string command = instruction[0];

                if (command == "noop")
                {                   
                    cycles++;
                    DrawPixel(cycles, x);
                }
                else if (command == "addx")
                {
                    cycles++;
                    DrawPixel(cycles, x);
                    int value = int.Parse(instruction[1]);
                    cycles++;
                    DrawPixel(cycles, x);
                    x += value;
                }
            }

            Console.WriteLine(totalSignalStrenght);
        }

        private void DrawPixel(int cycles, int x)
        {
            int crtPos = cycles - 1;
            if (x == crtPos || x - 1 == crtPos || x + 1 == crtPos)
            {
                _crt[cycles - 1] = 'X';
            }
            else
            {
                _crt[cycles - 1] = '.';
            }

        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day10.txt");
            return inputFile.Select(ins => new string(ins)).ToList();
        }
    }
}
