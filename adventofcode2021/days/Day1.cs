using System.Security.AccessControl;
using adventofcode2021.util;

namespace adventofcode2021.days;

public class Day1 : IProblem
{
    
    private readonly List<string> _input = FileLoader.LoadAsList("day1_input.txt");
    
    public long Answer(params long[] arguments)
    {
        var higher = 0;
        int? last = null;
        foreach (var current in _input.Select(int.Parse))
        {
            if (current > last)
            {
                higher++;
            }

            last = current;
        }

        return higher;
    }

    public long Answer2(params long[] arguments)
    {
        var higher = 0;
        int? lastSum = null;
        for (var i = 0; i + 2 < _input.Count; i++)
        {
            var sum = int.Parse(_input[i]) + int.Parse(_input[i + 1]) + int.Parse(_input[i + 2]);
            if (sum > lastSum)
            {
                higher++;
            }

            lastSum = sum;
        }

        return higher;
    }
}