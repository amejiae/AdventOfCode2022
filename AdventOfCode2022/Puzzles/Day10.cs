namespace AdventOfCode2022.Puzzles
{
    internal class Day10 : Puzzlebase
    {
        private readonly List<string> _instructions;

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
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day10.txt");
            return inputFile.Select(ins => new string(ins)).ToList();
        }
    }
}
