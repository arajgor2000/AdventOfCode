using AdventOfCode.Framework;
using AdventOfCode.Framework.Runner;

SolutionRunner runner = new( 
    new Options()
    {
        InputBaseDirectory = "Inputs"
    });

runner.Solve(1, Problem.Problem1);