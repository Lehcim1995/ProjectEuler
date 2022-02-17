using System.Drawing;
using System.Text.RegularExpressions;
using adventofcode2021.util;
using static System.Convert;

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

        InfiniGrid<int> infiniGrid = new InfiniGrid<int>(0);

        List<Line> lines = new List<Line>();
        foreach (var s1 in _input)
        {
            var matches= r.Matches(s1);
            Line s = new Line()
            {
                a = new Point(ToInt32(matches[0].Groups[1].Value), ToInt32(matches[0].Groups[2].Value)),
                b = new Point(ToInt32(matches[0].Groups[3].Value),ToInt32(matches[0].Groups[4].Value))
            };

            if (s.a.X == s.b.X || s.a.Y == s.b.Y)
            {
                lines.Add(s);    
            }
        }

        foreach (var line in lines)
        {
            if (line.a.X == line.b.X)
            {
                var minY = Math.Min(line.a.Y, line.b.Y);
                var maxY = Math.Max(line.a.Y, line.b.Y);
                for (var y = minY; y < maxY; y++)
                {
                    var p = new Point(line.a.X, y);
                    if (infiniGrid.ItemExist(p))
                    {
                        infiniGrid.SetItem( p,infiniGrid.GetItem(p) + 1);
                    }
                    else
                    {
                        infiniGrid.AddItem(p, 1);
                    }
                }
            }
            else if (line.a.Y == line.b.Y)
            {
                var minX = Math.Min(line.a.X, line.b.X);
                var maxX = Math.Max(line.a.X, line.b.X);
                for (var x = minX; x < maxX; x++)
                {
                    var p = new Point(x, line.a.Y);
                    if (infiniGrid.ItemExist(p))
                    {
                        infiniGrid.SetItem( p,infiniGrid.GetItem(p) + 1);
                    }
                    else
                    {
                        infiniGrid.AddItem(p, 1);
                    }
                    
                }
            }
        }
        infiniGrid.DrawGrid();

        return infiniGrid.Grid.Values.Count((i => i > 1));
    }

    public long Answer2(params long[] arguments)
    {
        throw new NotImplementedException();
    }
}