using adventofcode2019.Classes;
using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day15 : IProblem
    {
        private long[] program = { 3, 1033, 1008, 1033, 1, 1032, 1005, 1032, 31, 1008, 1033, 2, 1032, 1005, 1032, 58, 1008, 1033, 3, 1032, 1005, 1032, 81, 1008, 1033, 4, 1032, 1005, 1032, 104, 99, 1001, 1034, 0, 1039, 102, 1, 1036, 1041, 1001, 1035, -1, 1040, 1008, 1038, 0, 1043, 102, -1, 1043, 1032, 1, 1037, 1032, 1042, 1105, 1, 124, 1001, 1034, 0, 1039, 1001, 1036, 0, 1041, 1001, 1035, 1, 1040, 1008, 1038, 0, 1043, 1, 1037, 1038, 1042, 1106, 0, 124, 1001, 1034, -1, 1039, 1008, 1036, 0, 1041, 101, 0, 1035, 1040, 101, 0, 1038, 1043, 1001, 1037, 0, 1042, 1105, 1, 124, 1001, 1034, 1, 1039, 1008, 1036, 0, 1041, 102, 1, 1035, 1040, 102, 1, 1038, 1043, 102, 1, 1037, 1042, 1006, 1039, 217, 1006, 1040, 217, 1008, 1039, 40, 1032, 1005, 1032, 217, 1008, 1040, 40, 1032, 1005, 1032, 217, 1008, 1039, 39, 1032, 1006, 1032, 165, 1008, 1040, 1, 1032, 1006, 1032, 165, 1102, 1, 2, 1044, 1105, 1, 224, 2, 1041, 1043, 1032, 1006, 1032, 179, 1101, 1, 0, 1044, 1105, 1, 224, 1, 1041, 1043, 1032, 1006, 1032, 217, 1, 1042, 1043, 1032, 1001, 1032, -1, 1032, 1002, 1032, 39, 1032, 1, 1032, 1039, 1032, 101, -1, 1032, 1032, 101, 252, 1032, 211, 1007, 0, 53, 1044, 1105, 1, 224, 1101, 0, 0, 1044, 1105, 1, 224, 1006, 1044, 247, 1002, 1039, 1, 1034, 1002, 1040, 1, 1035, 1001, 1041, 0, 1036, 1002, 1043, 1, 1038, 102, 1, 1042, 1037, 4, 1044, 1106, 0, 0, 75, 19, 3, 12, 33, 54, 92, 8, 21, 31, 54, 5, 92, 12, 60, 36, 59, 17, 50, 64, 6, 67, 13, 45, 33, 33, 6, 76, 60, 41, 97, 33, 8, 19, 78, 23, 28, 64, 22, 49, 25, 77, 58, 85, 19, 83, 48, 69, 66, 27, 18, 23, 60, 25, 13, 52, 71, 49, 88, 74, 21, 93, 89, 22, 60, 89, 12, 78, 8, 17, 98, 68, 14, 29, 57, 90, 31, 57, 13, 2, 48, 60, 18, 17, 80, 6, 96, 37, 55, 99, 44, 64, 67, 79, 27, 61, 96, 36, 97, 47, 48, 82, 96, 19, 19, 99, 35, 78, 41, 90, 21, 6, 87, 86, 6, 44, 49, 14, 88, 79, 42, 65, 73, 96, 8, 3, 13, 17, 80, 68, 35, 21, 54, 71, 49, 2, 48, 4, 95, 83, 24, 43, 74, 24, 70, 37, 47, 98, 92, 47, 76, 42, 39, 94, 86, 1, 64, 47, 83, 11, 71, 21, 90, 44, 58, 95, 67, 28, 23, 58, 58, 39, 52, 82, 18, 95, 83, 4, 91, 22, 91, 59, 32, 75, 64, 51, 99, 19, 79, 74, 22, 65, 34, 28, 77, 37, 13, 67, 18, 63, 16, 73, 33, 72, 20, 97, 41, 83, 26, 64, 81, 42, 75, 97, 36, 59, 25, 45, 75, 2, 47, 88, 98, 48, 52, 67, 6, 72, 24, 56, 96, 65, 19, 37, 10, 83, 91, 15, 86, 25, 16, 46, 45, 90, 31, 76, 18, 49, 82, 49, 99, 91, 49, 7, 33, 55, 94, 23, 13, 92, 27, 19, 96, 65, 26, 50, 90, 2, 79, 19, 28, 90, 5, 60, 15, 84, 33, 85, 9, 69, 84, 77, 34, 39, 54, 64, 8, 6, 79, 85, 17, 78, 69, 99, 49, 64, 8, 86, 72, 10, 80, 10, 97, 38, 6, 42, 79, 84, 12, 70, 75, 12, 45, 6, 9, 62, 45, 90, 46, 39, 67, 44, 92, 56, 29, 96, 94, 38, 40, 66, 8, 4, 27, 66, 34, 40, 59, 38, 99, 97, 48, 45, 89, 72, 62, 47, 73, 51, 43, 90, 10, 11, 55, 69, 36, 99, 86, 46, 90, 20, 20, 43, 1, 32, 70, 20, 24, 31, 63, 15, 90, 74, 51, 97, 60, 94, 17, 30, 76, 57, 7, 25, 75, 9, 20, 8, 75, 11, 84, 10, 31, 71, 46, 34, 83, 7, 76, 68, 74, 75, 14, 63, 76, 54, 26, 79, 71, 67, 67, 14, 93, 69, 46, 32, 21, 21, 91, 2, 48, 84, 36, 88, 2, 80, 34, 75, 57, 47, 74, 19, 74, 47, 56, 11, 29, 81, 28, 23, 98, 7, 57, 50, 21, 88, 85, 33, 46, 40, 24, 17, 60, 79, 80, 22, 79, 72, 38, 80, 92, 90, 52, 88, 79, 80, 43, 5, 65, 47, 27, 92, 94, 7, 84, 97, 9, 44, 68, 61, 12, 60, 54, 51, 6, 54, 30, 64, 20, 75, 68, 10, 54, 52, 54, 92, 1, 43, 78, 41, 98, 42, 83, 7, 7, 77, 55, 44, 14, 24, 97, 15, 48, 35, 63, 4, 91, 54, 22, 69, 26, 47, 56, 35, 74, 34, 82, 61, 7, 68, 41, 32, 72, 19, 36, 70, 68, 21, 44, 78, 18, 40, 63, 63, 34, 93, 16, 87, 45, 52, 99, 81, 49, 77, 21, 98, 12, 35, 9, 62, 25, 64, 59, 36, 76, 82, 86, 44, 37, 96, 79, 38, 62, 89, 14, 35, 56, 3, 72, 68, 81, 30, 9, 44, 43, 31, 37, 90, 55, 29, 15, 62, 65, 85, 13, 76, 59, 99, 9, 26, 75, 82, 43, 72, 3, 41, 12, 92, 32, 45, 84, 14, 36, 54, 68, 3, 91, 23, 41, 6, 98, 18, 58, 33, 94, 30, 23, 27, 23, 70, 48, 25, 68, 35, 57, 51, 96, 28, 92, 94, 8, 38, 59, 48, 67, 93, 4, 45, 66, 91, 41, 72, 61, 17, 20, 83, 36, 90, 51, 58, 62, 90, 37, 72, 26, 3, 58, 66, 88, 19, 77, 97, 41, 82, 37, 67, 35, 11, 75, 15, 45, 92, 38, 10, 86, 17, 83, 60, 48, 43, 45, 72, 29, 60, 74, 45, 97, 96, 14, 62, 13, 90, 81, 51, 12, 47, 91, 34, 65, 60, 31, 30, 92, 46, 18, 64, 85, 22, 77, 94, 42, 32, 68, 80, 94, 47, 1, 81, 98, 88, 31, 12, 54, 20, 96, 90, 31, 9, 99, 50, 70, 51, 83, 68, 40, 99, 26, 65, 19, 66, 93, 68, 49, 92, 36, 96, 6, 66, 48, 95, 57, 76, 14, 85, 12, 98, 32, 61, 36, 71, 58, 72, 15, 74, 19, 90, 49, 69, 7, 58, 18, 57, 0, 0, 21, 21, 1, 10, 1, 0, 0, 0, 0, 0, 0 };
        Dictionary<Point, int> map = new Dictionary<Point, int>();

        private void DebugMap(Point loc)
        {
            int maxX = map.Max(m => m.Key.x) + 1;
            int minX = map.Min(m => m.Key.x) - 1;
            int maxY = map.Max(m => m.Key.y) + 1;
            int minY = map.Min(m => m.Key.y) - 1;

            StringBuilder b = new StringBuilder();

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (map.ContainsKey(new Point(x, y)))
                    {
                        if (x == loc.x && y == loc.y)
                        {
                            b.Append("O");
                        }
                        else
                        {

                            switch (map[new Point(x, y)])
                            {
                                case 0: // Nothing
                                        //Console.Write(".");
                                    b.Append(".");
                                    break;
                                case 1: // Wall
                                        //Console.Write("▓");
                                    b.Append("▓");
                                    break;
                                case 2: // Oxigen leak?
                                        //Console.WriteLine("X");
                                    b.Append("X");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        //Console.Write("+");
                        b.Append("+");
                    }

                }
                //Console.Write("\n");
                b.Append("\n");
            }

            Console.Clear();
            Console.Write(b.ToString().ToCharArray());
            Thread.Sleep(16);
        }

        private int NewMove(Point location, int direction)
        {
            Point north = new Point(0, 1);
            Point east = new Point(1, 0);
            Point south = new Point(0, -1);
            Point west = new Point(-1, 0);



            /*
            // First explore map
            if (!map.ContainsKey(location + north))
            {
                return 1;
            }

            if (!map.ContainsKey(location + east))
            {
                return 4;
            }

            if (!map.ContainsKey(location + south))
            {
                return 2;
            }

            if (!map.ContainsKey(location + west))
            {
                return 3;
            }

            switch(direction)
            {
                case 1: // north
                    if (map[location + north] == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 4;
                    }
                case 2: // south
                    if (map[location + south] == 0)
                    {
                        return 2;
                    }else 
                    {
                        return 3;
                    }
                case 3: //west
                    if (map[location + west] == 0)
                    {
                        return 3;
                    }else 
                    {
                        return 1;
                    }
                case 4: //east
                    if (map[location + east] == 0)
                    {
                        return 4;
                    }else 
                    {
                        return 2;
                    }
            }
            */

            return -1;
        }

        public long Answer(params long[] arguments)
        {
            IntCodeProcessor2 icp2 = new IntCodeProcessor2(program) { InputModeSetting = IntCodeProcessor2.InputMode.Set };

            icp2.Reset();
            Point location = new Point(0, 0);
            Point add = new Point(0, 0);

            map.Add(location + add, 0);
            int dir = 3;

            // north (1), south (2), west (3), and east (4)

            while (icp2.IsRunning)
            {
                icp2.InputNumbers.Add(dir);

                var x = icp2.RunWithOutput();

                switch(dir)
                {
                    case 1: // north
                        add = new Point(0, 1);
                        break;
                    case 2: // south
                        add = new Point(0, -1);
                        break;
                    case 3: //west
                        add = new Point(-1, 0);
                        break;
                    case 4: //east
                        add = new Point(1, 0);
                        break;
                }

                if (!map.ContainsKey(location + add))
                {
                    map.Add(location + add, 0);
                }

                switch (x)
                {
                    case 1: // nothing in the way

                        // Move

                        location.x += add.x;
                        location.y += add.y;

                        // Add now location 

                        break;
                    case 0: // wall in the way didnt move

                        map[location + add] = 1;
                        

                        break;
                    case 2: // found leak

                        map[location + add] = 2;
                        break;
                }

                // Calculate new move now
                var n = NewMove(location, dir);
                if (n == -1)
                {
                    dir++;
                    if (dir == 5)
                    {
                        dir = 1;
                    }
                }
                else
                {
                    dir = n;
                }


                DebugMap(location);
            }

            //DebugMap(location);

            return 0;
        }
    }
}
