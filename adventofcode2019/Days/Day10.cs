using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019.Interfaces;

namespace adventofcode2019.Days
{
    public class Day10 : IProblem
    {
        // Array of points

        private int width = 33;
        //private int width = 5;

        //private string input = "..#..###....#####....###........#.##.##...#.#.......#......##....##..#..##.#..###...##....#......##..####...#..##...####.#.......#.#...#.#.....##...#.####.#.###.#..##..#..##.#.#.####.#.###.#.##.....#.##...##.....##.#......#.....##..#..##.##.#..#....#...#...#...##..#..#.....###.#..##.###.##........##...#..#####.#.#......####.......##.#.#.#.###..#...#.#..##.#.........#....#....##.####....#.......#..##.#.........#..#......###..##.##....#.#..#.#....#.###...#.....##...##..#.#.#...###..#.#.#..###.#..##..##...##...#.#.#...#..#.#..#..#..##.##...###.##.#......#......#.....###.....#....#..#....#...#...###..#......#.##.#...#.####.....#.##...##.#...#........#.#.....#.##....#..#.......##.##.....#..#.#....###.#.#.#.#.#............#....####.##....#..###.##.#.#..#.......##....#.#.#...#...#..#........#.#..####.##.#.........###..##.......#....#.##.......#.#.###......#..#.#.........#...###......#..#.##.#.#.#.#........#.#.##..#..........#.##.#...........#..#.#....####....##..#..##.#.##.##..##....#.#..###.#..#...#....#.###.#..#.............#...#...#.......#.#...........###.#.....#..##..#.##...";

        //private string input = ".#..#.....#####....#...##";

        private string input = ".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##";

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
                    int range = 1;

                    while (range <= width + 1)
                    {

                        CheckAround(astroid.Key, range);
                        range++;
                        //Console.WriteLine();
                        //DebugMap(astroids2);
                    }
                    Console.WriteLine();
                    DebugMap(astroids2);

                }
            }
        }

        private void CheckAround(Point p, int range)
        {
            //Console.WriteLine($"Finding astroids for {p.x}:{p.y} with range {range}");

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
                            {
                                float deltaX = (p2.x) - p.x;
                                float deltaY = (p2.y) - p.y;


                                
                                if (deltaX > 1 || deltaX < -1)
                                {
                                    deltaY /= deltaX;

                                    if (deltaX < 0)
                                        deltaX /= -deltaX;
                                    else
                                        deltaX /= deltaX;

                                    //deltaX /= deltaX;
                                    
                                   
                                }
                                Console.WriteLine($"deltaX {deltaX} deltay {deltaY} ");

                                int maxwidth = (int)Math.Sqrt(width * width);

                                for (int i = 2; i < maxwidth; i++)
                                {
                                    float xnew = p.x + (deltaX * i);
                                    float ynew = p.y + (deltaY * i);

                                    if (xnew == Math.Floor(xnew) && ynew == Math.Floor(ynew))
                                    {
                                        astroids2[new Point((int)xnew, (int)ynew)] = false;
                                    }
                                }
                            }

                            {
                                float deltaX = (p2.x) - p.x;
                                float deltaY = (p2.y) - p.y;

                                
                                if (deltaY > 1 || deltaY < -1)
                                {
                                    deltaX /= deltaY;
                                    //deltaY /= deltaY;

                                    if (deltaY < 0)
                                        deltaY /= -deltaY;
                                    else
                                        deltaY /= deltaY;
                                   
                                }

                                int maxwidth = (int)Math.Sqrt(width * width);

                                for (int i = 2; i < maxwidth; i++)
                                {
                                    float xnew = p.x + (deltaX * i);
                                    float ynew = p.y + (deltaY * i);

                                    if (xnew == Math.Floor(xnew) && ynew == Math.Floor(ynew))
                                    {
                                        astroids2[new Point((int)xnew, (int)ynew)] = false;
                                    }
                                }
                            }

                            astroidDetect[p] += 1;
                        }
                    }
                }
            }
        }

        private float[] FormualaY(int a, int b, int xStart, int xEnd)
        {
            List<float> numbers = new List<float>();

            for(int x = xStart; x < xEnd; x++)
            {
                float y = a + (b * x);
                numbers.Add(y);
            }

            return numbers.ToArray();
        }

        private float[] FormualaX(int a, int b, int yStart, int yEnd)
        {
            List<float> numbers = new List<float>();

            for (int y = yStart; y < yEnd; y++)
            {
                //int y = a + (b * x);
                float x = (float)(y  - a) / b ;
                numbers.Add(x);
            }

            return numbers.ToArray();
        }

        private void DebugMap(Dictionary<Point, bool> map)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                   // Console.Write(map[new Point(y, x)] ? "#" : ".");
                }
                //Console.Write("\n");
            }
        }

        // path is block if 

        public long Answer(params long[] arguments)
        {
            width = (int)Math.Sqrt(input.Length);

            Console.WriteLine($"Width {width}");

            FillAstroids();
            DebugMap(astroids);
            FindAstroids();

            //var xs = FormualaY(3, 2, 0, 5);
            //var ys = FormualaX(3, 2, 0, 10);

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