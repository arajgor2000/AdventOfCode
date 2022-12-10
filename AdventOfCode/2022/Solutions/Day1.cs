using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(1)]
[SolutionInput("Day1.txt")]
public class Day1 : Solution
{
    private readonly string[] _lines;

    public Day1(Input input) : base(input)
    {
        _lines = input.Lines;
    }

    protected override string? Problem1()
    {
        ulong maxCalories = 0;
        ulong totalCaloriesForElf = 0;
        foreach (var line in _lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                totalCaloriesForElf += ulong.Parse(line);
                continue;
            }

            if (totalCaloriesForElf > maxCalories)
            {
                maxCalories = totalCaloriesForElf;
            }

            totalCaloriesForElf = 0;
        }

        // Ensure final line is taken into consideration.
        if (totalCaloriesForElf > maxCalories)
        {
            maxCalories = totalCaloriesForElf;
        }

        return maxCalories.ToString();
    }

    protected override string? Problem2()
    {
        List<ulong> totalCaloriesPerElf = new();
        ulong totalCaloriesForElf = 0;
        foreach (var line in _lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                totalCaloriesForElf += ulong.Parse(line);
                continue;
            }

            totalCaloriesPerElf.Add(totalCaloriesForElf);
            totalCaloriesForElf = 0;
        }

        // Ensure final elf is taken into consideration.
        totalCaloriesPerElf.Add(totalCaloriesForElf);

        var topThreeTotalCalories = totalCaloriesPerElf
            .OrderByDescending(totalCalories => totalCalories)
            .Take(3)
            .ToArray();

        ulong sumTopThreeTotalCalories = 0;
        for (var index = 0; index < 3; index++)
        {
            sumTopThreeTotalCalories += topThreeTotalCalories[index];
        }

        return sumTopThreeTotalCalories.ToString();
    }
}
