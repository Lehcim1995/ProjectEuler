using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019.Interfaces;
using adventofcode2019.Classes;

namespace adventofcode2019.Days
{
    public class Day10 : IProblem
    {
        // Array of points

        private int width = 33;
        //private int width = 5;

        private string input = "..#..###....#####....###........#.##.##...#.#.......#......##....##..#..##.#..###...##....#......##..####...#..##...####.#.......#.#...#.#.....##...#.####.#.###.#..##..#..##.#.#.####.#.###.#.##.....#.##...##.....##.#......#.....##..#..##.##.#..#....#...#...#...##..#..#.....###.#..##.###.##........##...#..#####.#.#......####.......##.#.#.#.###..#...#.#..##.#.........#....#....##.####....#.......#..##.#.........#..#......###..##.##....#.#..#.#....#.###...#.....##...##..#.#.#...###..#.#.#..###.#..##..##...##...#.#.#...#..#.#..#..#..##.##...###.##.#......#......#.....###.....#....#..#....#...#...###..#......#.##.#...#.####.....#.##...##.#...#........#.#.....#.##....#..#.......##.##.....#..#.#....###.#.#.#.#.#............#....####.##....#..###.##.#.#..#.......##....#.#.#...#...#..#........#.#..####.##.#.........###..##.......#....#.##.......#.#.###......#..#.#.........#...###......#..#.##.#.#.#.#........#.#.##..#..........#.##.#...........#..#.#....####....##..#..##.#.##.##..##....#.#..###.#..#...#....#.###.#..#.............#...#...#.......#.#...........###.#.....#..##..#.##...";

        //private string input = ".#..#.....#####....#...##";

        //private string input = ".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##";

        //private string input = ".#..#..#######.###.#....###.#...###.##.###.##.#.#.....###..#..#.#..#.##..#.#.###.##...##.#.....#.#..";

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return x + " : " + y;
            }
        }

        private Dictionary<Point, bool> astroids;
        private Dictionary<Point, bool> astroids2;
        private Dictionary<Point, int> astroidDetect;
        private MyMaths mm = new MyMaths();

        private void FillAstroids()
        {
            astroids = new Dictionary<Point, bool>();
            astroidDetect = new Dictionary<Point, int>();

            for (var i = 0; i < input.ToCharArray().Length; i++)
            {
                char astroid = input.ToCharArray()[i];
                int x = i % width;
                int y = i / width;

                //Console.WriteLine($" X: {x} Y: {y} ");

                astroids.Add(new Point(x, y), astroid == '#');

                if (astroid == '#')
                    astroidDetect.Add(new Point(x, y), 0);
            }
        }

        private void FindAstroids()
        {
            foreach (var astroid in astroids)
            {
                if (astroid.Value)
                {
                    astroids2 = new Dictionary<Point, bool>(astroids);
                    int range = width+1;

                    while (range > 1)
                    {

                        CheckAround(astroid.Key, range);
                        range--;
                        //Console.WriteLine();
                        //DebugMap(astroids2, astroid.Key);
                    }

                    foreach(var a in astroids2)
                    {
                        astroidDetect[astroid.Key] += a.Value ? 1 : 0;
                    }
                    astroidDetect[astroid.Key] -= 1;

                    Console.WriteLine();
                    Console.WriteLine(astroid.Key);
                    DebugMap(astroids2, astroid.Key);

                }
            }
        }

        private void CheckAround(Point p, int range)
        {
            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    var p2 = new Point(p.x + x, p.y + y);

                    if (x == 0 && y == 0)
                    {
                        continue; // Dont check center
                    }

                    if (p2.y < 0 || p2.x < 0)
                    {
                        continue; // dont check negative values
                    }

                    // only check if the value is on the border

                    if ((x != -range && x != range) && (y != -range && y != range))
                    {
                        continue;
                    }

                    if (astroids2.ContainsKey(p2))
                    {
                        if (astroids2[p2])
                        {
                            int deltaX = p2.x - p.x;
                            int deltaY = p2.y - p.y;
                            var cd = mm.GCD(Math.Abs(deltaX), Math.Abs(deltaY));

                            if (cd == 1) // 
                            {
                                // Im possible to find a astroid that is closer
                                //astroidDetect[p] += 1;
                            }
                            else
                            {
                                // possibility for a match in smaller items
                                // check for the posibilty

                                int smallX = deltaX / (int)cd;
                                int smally = deltaY / (int)cd;
                                bool found = false;


                                for (int i = (int)cd - 1; i > 0; i--)
                                {
                                    if (astroids2[new Point(p.x + (smallX * i), p.y + (smally * i))])
                                    {
                                        // Found a astroid that is close by
                                        found = true;
                                    }
                                }

                                if (found) // Found a astroid that is closer
                                {
                                    // Just disable the astroid for now, no need to check it anymore
                                    astroids2[p2] = false;
                                }
                                else // Didnt found an astroid that is closer. add the astroid
                                {
                                    //astroidDetect[p] += 1;
                                }
                            }



                            if (p.x == 11 && p.y == 13)
                            {
                                var l = 1;
                            }

                        }
                    }
                }
            }
        }

        private void DebugMap(Dictionary<Point, bool> map, Point current)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (current.x == y && current.y == x)
                    {
                        Console.Write("%");
                    }
                    else
                    {
                        Console.Write(map[new Point(y, x)] ? "#" : ".");
                    }
                    
                }
                Console.Write("\n");
            }
        }

        // path is block if 

        public long Answer(params long[] arguments)
        {
            width = (int)Math.Sqrt(input.Length);

            Console.WriteLine($"Width {width}");

            FillAstroids();
            DebugMap(astroids, new Point(-1, -1));
            FindAstroids();

            var large = 0;

            foreach(var astroid in astroidDetect)
            {
                if (astroid.Value > large)
                    large = astroid.Value;
            }

            var stroid = astroidDetect.First(t => t.Value == large);

            Console.WriteLine($"Largest {large} at {stroid.Key}");

            return large;
        }
    }
}