using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(2)]
[SolutionInput("Day2 - Example.txt")]
public class Day2 : Solution
{
    private readonly Dictionary<char, int> _playerMappings;
    private readonly Dictionary<char, int> _shapeScoreMappings;
    private readonly int[,] _outcomeScores;
    private readonly string[] _rounds;

    public Day2(Input input) : base(input)
    {
        _shapeScoreMappings = new Dictionary<char, int>()
        { 
            { 'X', 1 }, // Rock
            { 'Y', 2 }, // Paper 
            { 'Z', 3 }  // Scissors
        };

        _playerMappings = new Dictionary<char, int>()
        {
            // Opponent
            { 'A', 0 }, // Rock
            { 'B', 1 }, // Paper 
            { 'C', 2 }, // Scissors
            
            // You
            { 'X', 0 }, // Rock
            { 'Y', 1 }, // Paper 
            { 'Z', 2 }  // Scissors
        };

        _outcomeScores = new int[,] 
        { 
            { 3, 6, 0 },
            { 0, 3, 6 },
            { 6, 0, 3 }
        };

        _rounds = input.Lines;
    }

    protected override string? Problem1()
    {
        long totalScore = 0;
        foreach (var round in _rounds)
        {
            var inputs = round.Split(' ');
            var opponent = inputs[0][0];
            var you = inputs[1][0];

            var roundScore = _outcomeScores[_playerMappings[opponent], _playerMappings[you]] + _shapeScoreMappings[you];

            totalScore += roundScore;
        }

        return totalScore.ToString();
    }

    protected override string? Problem2()
    {
        return null;
    }
}
