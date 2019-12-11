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

//        private int width = 33;
        private int width = 5;

//        private string input = "..#..###....#####....###........#.##.##...#.#.......#......##....##..#..##.#..###...##....#......##..####...#..##...####.#.......#.#...#.#.....##...#.####.#.###.#..##..#..##.#.#.####.#.###.#.##.....#.##...##.....##.#......#.....##..#..##.##.#..#....#...#...#...##..#..#.....###.#..##.###.##........##...#..#####.#.#......####.......##.#.#.#.###..#...#.#..##.#.........#....#....##.####....#.......#..##.#.........#..#......###..##.##....#.#..#.#....#.###...#.....##...##..#.#.#...###..#.#.#..###.#..##..##...##...#.#.#...#..#.#..#..#..##.##...###.##.#......#......#.....###.....#....#..#....#...#...###..#......#.##.#...#.####.....#.##...##.#...#........#.#.....#.##....#..#.......##.##.....#..#.#....###.#.#.#.#.#............#....####.##....#..###.##.#.#..#.......##....#.#.#...#...#..#........#.#..####.##.#.........###..##.......#....#.##.......#.#.###......#..#.#.........#...###......#..#.##.#.#.#.#........#.#.##..#..........#.##.#...........#..#.#....####....##..#..##.#.##.##..##....#.#..###.#..#...#....#.###.#..#.............#...#...#.......#.#...........###.#.....#..##..#.##...";

        private string input = ".#..#.....#####....#...##";

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
                    int range = 1;

                    while (range <= width + 1)
                    {
                        CheckAround(astroid.Key, range);
                        range++;
                    }
                }
            }
        }

        private void CheckAround(Point p, int range)
        {
            Console.WriteLine($"Finding astroids for {p.x}:{p.y} with range {range}");

            for (int x = -range; x < range; x++)
            {
                for (int y = -range; y < range; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue; // Dont check center
                    }

                    if ((x == -range || x == range) || (y == -range || y == range))
                    {
                        //Console.WriteLine($" {x} {y} ");

                        if (astroids.ContainsKey(new Point(p.x + x, p.y + y)))
                        {
                            if (astroids[new Point(p.x + x, p.y + y)])
                            {
                                bool found = true;


                                // Add 1
                                // calculate if there is a possible obstruction

                                for (int i = range ; i >= 2; i--) // y = a + bx
                                // calc y based on x and check if there is an astroid.
                                {
                                    //Console.WriteLine($"Walking back");

                                    // 
                                    float maybeX = (float) (p.x + x) / i;
                                    float maybeY = (float) (p.y + y) / i;

                                    bool isX = Math.Abs(maybeX - Math.Floor(maybeX)) < 0.001;
                                    bool isY = Math.Abs(maybeY - Math.Floor(maybeY)) < 0.001;

                                    if (isY || isX)
                                    {
                                        if (astroids[new Point((p.x + x) / i, (p.y + y) / i)])
                                        {
                                            //Console.WriteLine($"Found backtrack X: {(p.x + x)/i} Y: {(p.y + y)/i}");
                                            // Remove 1
                                            found = false;
                                            break;
                                        }
                                    }
                                }

                                if (found)
                                {
                                    Console.WriteLine($"Found astroid at X: {p.x + x} Y: {p.y + y}");
                                    astroidDetect[p] += 1;
                                }
                            }
                        }
                    }
                }
            }
        }


        // path is block if 

        public long Answer(params long[] arguments)
        {
            FillAstroids();
            FindAstroids();

            return 0;
        }
    }
}