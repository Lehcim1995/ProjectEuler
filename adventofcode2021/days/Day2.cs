using System.Numerics;
using adventofcode2021.util;

namespace adventofcode2021.days;

public class Day2 : IProblem
{
    private readonly List<string> _input = FileLoader.LoadAsList("day2_input.txt");
    
    public long Answer(params long[] arguments)
    {
        var forwards = 0;
        var dept = 0;
        
        foreach (var s in _input)
        {
            var split = s.IndexOf(" ");
            var command = s.Substring(0, split);
            var length = int.Parse(s.Substring(split));
            
            switch (command)
            {
                case "forward":
                    forwards += length;
                    break;
                case "up":
                    dept -= length;
                    break;
                case "down":
                    dept += length;
                    break;
                default:
                    break;
            }
        }

        return forwards * dept;
    }

    public long Answer2(params long[] arguments)
    {
        var forwards = 0;
        var dept = 0;
        var aim = 0;
        
        foreach (var s in _input)
        {
            var split = s.IndexOf(" ");
            var command = s.Substring(0, split);
            var length = int.Parse(s.Substring(split));

            switch (command)
            {
                case "forward":
                    forwards += length;
                    dept += aim * length;
                    break;
                case "up":
                    aim -= length;
                    break;
                case "down":
                    aim += length;
                    break;
                default:
                    break;
            }
        }

        return forwards * dept;
    }
}