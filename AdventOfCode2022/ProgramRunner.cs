﻿namespace AdventOfCode2022
{
    internal class ProgramRunner
    {
        public void Run<TProgram>() where TProgram : ProgramBase, new()
        {
            IProgram problem = new TProgram();

            Solve(problem);
        }

        protected virtual void Solve(IProgram problem)
        {
            problem.SolvePart1();
            problem.SolvePart2();
        }
    }
}
