using System.Text.RegularExpressions;

namespace AdventOfCode2022.Puzzles
{
    internal class Day5 : Puzzlebase
    {
        private readonly List<string> _input;
        private Stack<char> _stack1 = new();
        private Stack<char> _stack2 = new();
        private Stack<char> _stack3 = new();
        private Stack<char> _stack4 = new();
        private Stack<char> _stack5 = new();
        private Stack<char> _stack6 = new();
        private Stack<char> _stack7 = new();
        private Stack<char> _stack8 = new();
        private Stack<char> _stack9 = new();
        private readonly List<Tuple<int, int, int>> _instructions = new();
        private readonly List<Stack<char>> _allStacks = new();

        public Day5()
        {
            _input = GetInput();

            PopulateStacks();
            PopulateInstructions();

            _allStacks.Add(_stack1);
            _allStacks.Add(_stack2);
            _allStacks.Add(_stack3);
            _allStacks.Add(_stack4);
            _allStacks.Add(_stack5);
            _allStacks.Add(_stack6);
            _allStacks.Add(_stack7);
            _allStacks.Add(_stack8);
            _allStacks.Add(_stack9);
        }
        
        public override void SolvePart1()
        {
            foreach (var instruction in _instructions)
            {
                ProcessInstruction(instruction);
            }
            Console.WriteLine($"{_stack1.Peek()}{_stack2.Peek()}{_stack3.Peek()}{_stack4.Peek()}" +
                              $"{_stack5.Peek()}{_stack6.Peek()}{_stack7.Peek()}{_stack8.Peek()}" +
                              $"{_stack9.Peek()}");
        }

        public override void SolvePart2()
        {
            foreach (var instruction in _instructions)
            {
                ProcessInstructionChunk(instruction);
            }

            Console.WriteLine($"{_stack1.Peek()}{_stack2.Peek()}{_stack3.Peek()}{_stack4.Peek()}" +
                              $"{_stack5.Peek()}{_stack6.Peek()}{_stack7.Peek()}{_stack8.Peek()}" +
                              $"{_stack9.Peek()}");
        }

        private void ProcessInstructionChunk(Tuple<int, int, int> instruction)
        {
            int quantity = instruction.Item1;
            Stack<char> fromStack = _allStacks[instruction.Item2 - 1];
            Stack<char> toStack = _allStacks[instruction.Item3 - 1];
            Stack<char> bufferStack = new Stack<char>();

            int index = 0;
            while (index < quantity)
            {
                var crate = fromStack.Pop();
                bufferStack.Push(crate);
                index++;
            }

            index = 0;
            while (index < quantity)
            {
                toStack.Push(bufferStack.Pop());
                index++;
            }
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day5.txt");
            return inputFile.Select(line => new string(line)).ToList();
        }

        private void ProcessInstruction(Tuple<int, int, int> instruction)
        {
            int quantity = instruction.Item1;
            Stack<char> fromStack = _allStacks[instruction.Item2 - 1];
            Stack<char> toStack = _allStacks[instruction.Item3 - 1];

            int index = 0;
            while (index < quantity)
            {
                var crate = fromStack.Pop();
                toStack.Push(crate);
                index++;
            }
        }

        private void PopulateStacks()
        {
            foreach (var line in _input)
            {
                if (string.IsNullOrWhiteSpace(line) || int.TryParse(line[1].ToString(), out _))
                    break;

                char valueStack1 = line[1];
                if (!string.IsNullOrWhiteSpace(valueStack1.ToString()))
                    _stack1.Push(valueStack1);

                char valueStack2 = line[5];
                if (!string.IsNullOrWhiteSpace(valueStack2.ToString()))
                    _stack2.Push(valueStack2);

                char valueStack3 = line[9];
                if (!string.IsNullOrWhiteSpace(valueStack3.ToString()))
                    _stack3.Push(valueStack3);

                char valueStack4 = line[13];
                if (!string.IsNullOrWhiteSpace(valueStack4.ToString()))
                    _stack4.Push(valueStack4);

                char valueStack5 = line[17];
                if (!string.IsNullOrWhiteSpace(valueStack5.ToString()))
                    _stack5.Push(valueStack5);

                char valueStack6 = line[21];
                if (!string.IsNullOrWhiteSpace(valueStack6.ToString()))
                    _stack6.Push(valueStack6);

                char valueStack7 = line[25];
                if (!string.IsNullOrWhiteSpace(valueStack7.ToString()))
                    _stack7.Push(valueStack7);

                char valueStack8 = line[29];
                if (!string.IsNullOrWhiteSpace(valueStack8.ToString()))
                    _stack8.Push(valueStack8);
                
                char valueStack9 = line[33];
                if (!string.IsNullOrWhiteSpace(valueStack9.ToString()))
                    _stack9.Push(valueStack9);
            }

            _allStacks.ForEach(RevertStack);
        }

        private void PopulateInstructions()
        {
            foreach (var line in _input)
            {
                if (!line.Contains("move"))
                    continue;

                Tuple<int, int, int> instruction = GetInstruction(line);
                _instructions.Add(instruction);
            }
        }

        private Tuple<int, int, int> GetInstruction(string line)
        {
            List<int> instruction = GetNumbersInString(line);
            int quantity = instruction[0];
            int moveFrom = instruction[1];
            int moveTo = instruction[2];

            return new Tuple<int, int, int>(quantity, moveFrom, moveTo);
        }

        private List<int> GetNumbersInString(string line)
        {
            List<int> result = new List<int>();

            // Split on one or more non-digit characters.
            string[] numbers = Regex.Split(line, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    result.Add(i);
                }
            }

            return result;
        }

        private void RevertStack(Stack<char> stack)
        {
            var newStack = new Stack<char>();
            while (stack.Count != 0)
            {
                newStack.Push(stack.Pop());
            }
        }
    }
}
