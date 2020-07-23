using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Classes
{
    public class MazeSolver
    {
        private int _wall;
        private int _empty;
        private int[,] maze;
        private bool[,] wasHere;
        private bool[,] correctPath;
        private int mazeSizeX;
        private int mazeSizeY;
        private int maxX, minX, maxY, minY;

        public MazeSolver(int wall = 1, int empty = 0)
        {
            this._wall = wall;
            this._empty = empty;
        }


        private int[,] DictionaryToIntMaze(Dictionary<Point, int> maze)
        {
            maxX = maze.Max(m => m.Key.x);
            minX = maze.Min(m => m.Key.x);
            maxY = maze.Max(m => m.Key.y);
            minY = maze.Min(m => m.Key.y);

            int sizeX = maxX - minX;
            int sizeY = maxY - minY;

            int[,] intMaze = new int[sizeX + 1, sizeY + 1];
            // intMaze.Initialize();

            for (var index0 = 0; index0 < intMaze.GetLength(0); index0++)
            for (var index1 = 0; index1 < intMaze.GetLength(1); index1++)
            {
                intMaze[index0, index1] = _wall;
            }

            foreach (var kvPair in maze)
            {
                int x = kvPair.Key.x - minX;
                int y = kvPair.Key.y - minY;
                intMaze[x, y] = kvPair.Value;
            }

            return intMaze;
        }

        private bool recursiveSolve(Point loc, Point end)
        {
            if (loc.x == end.x && loc.y == end.y) return true;
            if (maze[loc.x, loc.y] == _wall || wasHere[loc.x, loc.y]) return false;

            wasHere[loc.x, loc.y] = true;
            if (loc.x != 0) // Checks if not on left edge
                if (recursiveSolve(loc - new Point(-1, 0), end))
                {
                    // Recalls method one to the left
                    correctPath[loc.x, loc.y] = true; // Sets that path value to true;
                    return true;
                }

            if (loc.x != mazeSizeX - 1) // Checks if not on right edge
                if (recursiveSolve(loc - new Point(1, 0), end))
                {
                    // Recalls method one to the right
                    correctPath[loc.x, loc.y] = true;
                    return true;
                }

            if (loc.y != 0) // Checks if not on top edge
                if (recursiveSolve(loc - new Point(0, -1), end))
                {
                    // Recalls method one up
                    correctPath[loc.x, loc.y] = true;
                    return true;
                }

            if (loc.y != mazeSizeY - 1) // Checks if not on bottom edge
                if (recursiveSolve(loc - new Point(0, 1), end))
                {
                    // Recalls method one down
                    correctPath[loc.x, loc.y] = true;
                    return true;
                }

            return false;
        }

        public bool[,] Solve(int[,] maze, Point start, Point end)
        {
            int sizeX = maze.GetLength(0);
            int sizeY = maze.GetLength(1);

            this.maze = maze;
            this.wasHere = new bool[sizeX, sizeY];
            this.correctPath = new bool[sizeX, sizeY];

            Point offset = new Point(-minX, -minY);
            recursiveSolve(start - offset, end - offset);

            return correctPath;
        }

        public bool[,] Solve(Dictionary<Point, int> maze, Point start, Point end)
        {
            return Solve(DictionaryToIntMaze(maze), start, end);
        }
    }
}