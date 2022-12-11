using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(4)]
[SolutionInput("Day4.txt")]
public class Day4 : Solution
{
    private readonly string[] _lines;

    public Day4(Input input) : base(input)
    {
        _lines = input.Lines;
    }

    protected override string? Problem1()
    {
        long sum = 0;
        foreach (var line in _lines)
        {
            var ranges = line.Split(',');
            
            var range1Limits = ranges[0].Split('-');
            var range1Lower = int.Parse(range1Limits[0]);
            var range1Upper = int.Parse(range1Limits[1]);

            var range2Limits = ranges[1].Split('-');
            var range2Lower = int.Parse(range2Limits[0]);
            var range2Upper = int.Parse(range2Limits[1]);

            if ((range1Lower <= range2Lower && range1Upper >= range2Upper) || 
                (range2Lower <= range1Lower && range2Upper >= range1Upper))
            {
                sum++;
            }
        }

        return sum.ToString();
    }

    protected override string? Problem2()
    {
        return null;
    }
}