namespace AdventOfCode2022
{
    internal class ProgramRunner
    {
        public void Run<TProgram>() where TProgram : Puzzlebase, new()
        {
            IPuzzle problem = new TProgram();

            Solve(problem);
        }

        protected virtual void Solve(IPuzzle problem)
        {
            problem.SolvePart1();
            problem.SolvePart2();
        }
    }
}
