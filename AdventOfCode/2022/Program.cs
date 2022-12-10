using AdventOfCode.Framework;
using AdventOfCode.Framework.Runner;

SolutionRunner runner = new( 
    new Options()
    {
        InputBaseDirectory = "Inputs"
    });

runner.Solve(2, Problem.All);