using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(4)]
[SolutionInput("Day4.txt")]
public class Day4 : Solution
{
    private readonly List<RangePair> _rangePairs;

    public Day4(Input input) : base(input)
    {
        _rangePairs = new List<RangePair>();
        foreach (var line in input.Lines)
        {
            var ranges = line.Split(',');
            _rangePairs.Add(new(new Range(ranges[0]), new Range(ranges[1])));
        }
    }

    protected override string? Problem1()
    {
        long sum = 0;
        foreach (var rangePair in _rangePairs)
        {
            if ((rangePair.Range1.Lower <= rangePair.Range2.Lower && rangePair.Range1.Upper >= rangePair.Range2.Upper) || 
                (rangePair.Range2.Lower <= rangePair.Range1.Lower && rangePair.Range2.Upper >= rangePair.Range1.Upper))
            {
                sum++;
            }
        }

        return sum.ToString();
    }

    protected override string? Problem2()
    {
        long sum = 0;
        foreach (var rangePair in _rangePairs)
        {
            if ((rangePair.Range1.Lower >= rangePair.Range2.Lower && rangePair.Range1.Lower <= rangePair.Range2.Upper) ||
                (rangePair.Range1.Upper >= rangePair.Range2.Lower && rangePair.Range1.Upper <= rangePair.Range2.Upper) ||
                (rangePair.Range2.Lower >= rangePair.Range1.Lower && rangePair.Range2.Lower <= rangePair.Range1.Upper) ||
                (rangePair.Range2.Upper >= rangePair.Range1.Lower && rangePair.Range2.Upper <= rangePair.Range1.Upper))
            {
                sum++;
            }
        }

        return sum.ToString();
    }

    public struct Range
    {
        public int Lower { get; }
        public int Upper { get; }

        public Range(string range)
        {
            var rangeLimits = range.Split('-');
            Lower = int.Parse(rangeLimits[0]);
            Upper = int.Parse(rangeLimits[1]);
        }
    }

    private record struct RangePair(Range Range1, Range Range2);
}