using AdventOfCode.Framework;

namespace _2022.Solutions;

[Solution(3)]
[SolutionInput("Day3.txt")]
public class Day3 : Solution
{
    private readonly string[] _rucksacks;

    public Day3(Input input) : base(input)
    {
        _rucksacks = input.Lines;
    }

    protected override string? Problem1()
    {
        long sum = 0;
        var compartment1Items = new HashSet<char>();
        var compartment2Items = new HashSet<char>();
        foreach (var rucksack in _rucksacks)
        {
            compartment1Items.Clear();
            compartment2Items.Clear();
            for (var index = 0; index < rucksack.Length / 2; index++)
            {
                var compartment1Item = rucksack[index];
                var isNewCompartment1Item = compartment1Items.Add(compartment1Item);
                
                var compartment2Item = rucksack[rucksack.Length - 1 - index];
                var isNewCompartment2Item = compartment2Items.Add(compartment2Item);

                if (isNewCompartment1Item && isNewCompartment2Item && compartment1Item == compartment2Item)
                {
                    sum += GetItemPriority(compartment1Item);
                }
                else
                {
                    if (isNewCompartment1Item && compartment2Items.Contains(compartment1Item))
                    {
                        sum += GetItemPriority(compartment1Item);
                    }

                    if (isNewCompartment2Item && compartment1Items.Contains(compartment2Item))
                    {
                        sum += GetItemPriority(compartment2Item);
                    }
                }
            }
        }

        return sum.ToString();
    }

    protected override string? Problem2()
    {
        if (_rucksacks.Length % 3 != 0)
        {
            throw new ApplicationException($"Number of rucksacks ({_rucksacks.Length}) not divisible by 3");
        }

        long sum = 0;
        for (var index = 0; index < _rucksacks.Length; index += 3)
        {
            var rucksack1 = _rucksacks[index].ToHashSet();
            var rucksack2 = _rucksacks[index + 1].ToHashSet();
            var rucksack3 = _rucksacks[index + 2].ToHashSet();
            foreach (var item in rucksack1)
            {
                if (rucksack2.Contains(item) && rucksack3.Contains(item))
                {
                    sum += GetItemPriority(item);
                    break;
                }
            }
        }

        return sum.ToString();
    }

    private int GetItemPriority(char item)
    {
        return char.IsLower(item) ? item - 96 : item - 38;
    }
}