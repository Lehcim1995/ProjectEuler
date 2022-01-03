using System.Drawing;
using System.Text.RegularExpressions;
using adventofcode2021.util;

namespace adventofcode2021.days;

public class Day5: IProblem
{
    private readonly List<string> _input = FileLoader.LoadAsList("day5_input.txt");

    class Line
    {
        public Point a;
        public Point b;
    }
    
    public long Answer(params long[] arguments)
    {
        Regex r = new Regex("(\\d{1,3}),(\\d{1,3}) -> (\\d{1,3}),(\\d{1,3})");

        List<Line> lines = new List<Line>();
        foreach (var s1 in _input)
        {
            var matches= r.Matches(s1);
            Line s = new Line()
            {
                a = new Point(Convert.ToInt32(matches[0].Groups[1].Value), Convert.ToInt32(matches[0].Groups[2].Value)),
                b = new Point(Convert.ToInt32(matches[0].Groups[3].Value),Convert.ToInt32(matches[0].Groups[4].Value))
            };

            if (s.a.X == s.b.X || s.a.Y == s.b.Y)
            {
                lines.Add(s);    
            }
        }
        
        


        return 0;
    }

    public long Answer2(params long[] arguments)
    {
        throw new NotImplementedException();
    }
}