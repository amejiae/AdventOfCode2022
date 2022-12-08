namespace AdventOfCode2022.Puzzles
{
    internal class Day7 : Puzzlebase
    {
        private readonly List<string> _input;
        private Dictionary<string, Dictionary<string, int>> _directories;

        public Day7()
        {
            _directories = new Dictionary<string, Dictionary<string, int>>();
            _input = GetInput();
        }

        public override void SolvePart1()
        {
            var result = SolvePart1(_input);
            Console.WriteLine(result);
        }

        public override void SolvePart2()
        {
            var memoryAvailable = 70000000 - _directories["/"].Values.Sum();
            var memoryNeeded = 30000000 - memoryAvailable;

            var result = _directories.Values.Select(v => v.Values.Sum())
                .Where(x => x >= memoryNeeded)
                .Min()
                .ToString();
            
            Console.WriteLine(result);
        }

        public string SolvePart1(List<string> input)
        {
            var cwd = string.Empty;
            _directories = new Dictionary<string, Dictionary<string, int>>();

            foreach (var l in input)
            {
                if (l.Equals("$ cd .."))
                {
                    cwd = OneLevelUp(cwd, _directories);
                }
                else if (l.StartsWith("$ cd "))
                {
                    cwd = ChangeDirectory(l, cwd);
                }
                else if (l.StartsWith("dir"))
                {
                    ListDirectory(_directories, cwd, l);
                }
                else if (!l.StartsWith("$ ls"))
                {
                    List(l, _directories, cwd);
                }
            }

            while (cwd != "/")
            {
                var previousSlash = cwd.LastIndexOf('/', cwd.Length - 2) + 1;
                var name = cwd[previousSlash..^1];
                var parent = cwd[..previousSlash];

                _directories[parent][name] = _directories[cwd].Values.Sum();

                cwd = parent;
            }

            var part1 = _directories.Values.Select(v => v.Values.Sum())
                .Where(x => x <= 100000)
                .Sum()
                .ToString();

            return part1;
        }

        private static void List(string l, Dictionary<string, Dictionary<string, int>> dirs, string cwd)
        {
            var size = int.Parse(l.Split()[0]);
            var name = l.Split()[1];

            dirs.GetOrAdd(cwd, _ => new Dictionary<string, int>())[name] = size;
        }

        private static void ListDirectory(Dictionary<string, Dictionary<string, int>> dirs, string cwd, string l)
        {
            dirs.GetOrAdd(cwd, _ => new Dictionary<string, int>())[l[4..]] = 0;
        }

        private static string ChangeDirectory(string l, string cwd)
        {
            var path = l[5..];
            cwd = path.StartsWith("/") ? path : $"{cwd}{path}/";
            return cwd;
        }

        private static string OneLevelUp(string cwd, Dictionary<string, Dictionary<string, int>> dirs)
        {
            var previousSlash = cwd.LastIndexOf('/', cwd.Length - 2) + 1;
            var name = cwd[previousSlash..^1];
            var parent = cwd[..previousSlash];

            dirs[parent][name] = dirs[cwd].Values.Sum();

            cwd = parent;
            return cwd;
        }

        private List<string> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day7.txt");
            return inputFile.Select(sack => new string(sack)).ToList();
        }
    }
}
