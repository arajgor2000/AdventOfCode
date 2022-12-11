using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(2)]
[SolutionInput("Day2.txt")]
public class Day2 : Solution
{
    private readonly Dictionary<char, int> _itemScoreMappings;
    private readonly Dictionary<char, int> _playerMatrixIndexMappings;
    private readonly int[,] _outcomeMatrixScores;
    private readonly string[] _rounds;

    #region Outcome Matrix Indices
    private const int INDEX_ROCK        = 0;
    private const int INDEX_PAPER       = 1;
    private const int INDEX_SCISSORS    = 2;
    #endregion

    public Day2(Input input) : base(input)
    {
        _itemScoreMappings = new Dictionary<char, int>()
        { 
            { 'X', 1 }, // Rock
            { 'Y', 2 }, // Paper 
            { 'Z', 3 }  // Scissors
        };

        _playerMatrixIndexMappings = new Dictionary<char, int>()
        {
            // Opponent
            { 'A', INDEX_ROCK },
            { 'B', INDEX_PAPER },
            { 'C', INDEX_SCISSORS },
            
            // You
            { 'X', INDEX_ROCK },
            { 'Y', INDEX_PAPER }, 
            { 'Z', INDEX_SCISSORS }
        };

        _outcomeMatrixScores = new int[,] 
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
            var players = round.Split(' ');
            var opponent = players[0][0];
            var you = players[1][0];

            var roundScore = _outcomeMatrixScores[_playerMatrixIndexMappings[opponent], _playerMatrixIndexMappings[you]] + _itemScoreMappings[you];

            totalScore += roundScore;
        }

        return totalScore.ToString();
    }

    protected override string? Problem2()
    {
        var outcomeMappings = new Dictionary<char, int>()
        {
            { 'X', 0 }, // Lose
            { 'Y', 3 }, // Draw 
            { 'Z', 6 }  // Win
        };

        long totalScore = 0;
        foreach (var round in _rounds)
        {
            var inputs = round.Split(' ');
            var opponent = inputs[0][0];
            var outcome = inputs[1][0];

            var opponentIndex = _playerMatrixIndexMappings[opponent];
            var requiredOutcomeScore = outcomeMappings[outcome];
            int youIndex = 0;
            for (var youCount = 0; youCount < _outcomeMatrixScores.GetLength(1); youCount++)
            {
                if (_outcomeMatrixScores[opponentIndex, youCount] == requiredOutcomeScore)
                {
                    youIndex = youCount;
                    break;
                }
            }

            char youItem = _playerMatrixIndexMappings.Last(item => item.Value == youIndex).Key;

            var roundScore = requiredOutcomeScore + _itemScoreMappings[youItem];

            totalScore += roundScore;
        }

        return totalScore.ToString();
    }
}
