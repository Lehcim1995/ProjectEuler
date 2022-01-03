using System.Security.AccessControl;
using adventofcode2021.util;

namespace adventofcode2021.days;

public class Day3: IProblem
{
    private readonly List<string> _input = FileLoader.LoadAsList("day3_input.txt");

    public long Answer(params long[] arguments)
    {
        var gammaRate = 0;
        var epsilonRate = 0;

        const int bits = 12;
        var amount = new int[bits];
        foreach (var s in _input)
        {
            for (var i = 0; i < bits; i++)
            {
                amount[i] += s[i] == '1' ? 1 : 0;
            }
        }
        
        Console.WriteLine("[{0}]", string.Join(", ", amount));
        var length = _input.Count / 2;
        Console.WriteLine(length);

        for (int i = 0; i < bits; i++)
        {
            gammaRate |= (amount[i] > length ? 1 : 0) << (bits - 1) - i;
            epsilonRate |= (amount[i] <= length ? 1 : 0) << (bits - 1) - i;
        }

        Console.WriteLine($"Gamma: {gammaRate} Epsilon: {epsilonRate}");
        Console.WriteLine($"Gamma: {Convert.ToString(gammaRate, 2)} Epsilon: {Convert.ToString(epsilonRate, 2)}");
        
        return gammaRate * epsilonRate;
    }

    public long Answer2(params long[] arguments)
    {
        var oxygenGeneratorRating = 0;
        var co2Scrubber = 0;
        
        const int bits = 12;

        var oxygen = new List<string>(_input);
        var currentIndex = 0;
        while (oxygen.Count > 1)
        {
            var onesCount = oxygen.Count(s => s[currentIndex] == '1');
            var zeroCount = oxygen.Count - onesCount;

            var num = onesCount >= zeroCount ? '1' : '0';
            oxygen = oxygen.FindAll(s => s[currentIndex] == num);

            currentIndex++;
        }

        var co2 = new List<string>(_input);
        currentIndex = 0;
        while (co2.Count > 1)
        {
            var onesCount = co2.Count(s => s[currentIndex] == '1');
            var zeroCount = co2.Count - onesCount;

            var num = zeroCount <= onesCount ? '0' : '1';
            co2 = co2.FindAll(s => s[currentIndex] == num);

            currentIndex++;
        }
        
        Console.WriteLine("[{0}]", string.Join(", ", oxygen));
        Console.WriteLine("[{0}]", string.Join(", ", co2));
        
        for (int i = 0; i < bits; i++)
        {
            oxygenGeneratorRating |= (oxygen[0][i] == '1' ? 1 : 0) << (bits - 1) - i;
            co2Scrubber |= (co2[0][i] == '1' ? 1 : 0) << (bits - 1) - i;
        }

        Console.WriteLine($"oxygen: {oxygenGeneratorRating} co2: {co2Scrubber}");

        return oxygenGeneratorRating * co2Scrubber;
    }
}