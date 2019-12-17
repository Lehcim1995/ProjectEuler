﻿using System;
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
//                        Console.WriteLine();
//                        DebugMap(astroids2);
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
                                float deltaX = p2.x - p.x;
                                float deltaY = p2.y - p.y;
                                int maxWidth = (int)Math.Sqrt(width * width);

                                if (Math.Abs(deltaY) > 0.00001 && Math.Abs(deltaX) > 0.00001)
                                {

                                    Breuken breukX = new Breuken((int)deltaX, (int)deltaY);

                                    for (int i = 2; i < maxWidth; i++)
                                    {
                                        float xnew = p.x + (breukX * i).Value();
                                        float ynew = p.y + (1 * i);

                                        if (xnew == Math.Floor(xnew) && ynew == Math.Floor(ynew))
                                        {
                                            astroids2[new Point((int)xnew, (int)ynew)] = false;
                                        }
                                    }

                                    Breuken breukY = new Breuken(p2.y - p.y, p2.x - p.x);

                                    for (int i = 2; i < maxWidth; i++)
                                    {
                                        float xnew = p.x + (1 * i);
                                        float ynew = p.y + (breukY * i).Value();

                                        if (xnew == Math.Floor(xnew) && ynew == Math.Floor(ynew))
                                        {
                                            astroids2[new Point((int)xnew, (int)ynew)] = false;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 2; i < maxWidth; i++)
                                    {
                                        float xnew = p.x + (deltaX * i);
                                        float ynew = p.y + (deltaY * i);

                                        if (xnew == Math.Floor(xnew) && ynew == Math.Floor(ynew))
                                        {
                                            astroids2[new Point((int) xnew, (int) ynew)] = false;
                                        }
                                    }

                                }
                            }

                            astroidDetect[p] += 1;
                        }
                    }
                }
            }
        }

        class Breuken
        {
            private int _teller; // boven de streep
            private int _noemer; // onder de streep

            public Breuken(int teller, int noemer)
            {
                this._teller = teller;
                this._noemer = noemer;
            }

            public static Breuken operator *(Breuken a, int b)
            {
                Breuken bnew = new Breuken(a._teller * b, a._noemer);
                return bnew;
            }

            public float Value()
            {
                return (float)_teller /_noemer;
            }

            public override string ToString()
            {
                return _teller + "\\" + _noemer;
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
                    Console.Write(map[new Point(y, x)] ? "#" : ".");
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
            DebugMap(astroids);
            FindAstroids();

            //var xs = FormualaY(3, 2, 0, 5);
            //var ys = FormualaX(3, 2, 0, 10);

//            Breuken b1 = new Breuken(1, 3);
//            Breuken b2 = new Breuken(2, 3);
//            
//            Console.WriteLine($"3 * {b1.Value()} = {(b1 * 3).Value()}");

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