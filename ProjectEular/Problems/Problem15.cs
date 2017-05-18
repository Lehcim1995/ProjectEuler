using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;

namespace ProjectEular.Problems
{
    class Problem15 : IProblem
    {
        private long Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            Debug.WriteLine(number);
            return number*Factorial(number - 1);
        }

        static IEnumerable<IEnumerable<T>>
            GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] {t});

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] {t2}));
        }

        private long FindWaysInGrid(int gridsize)
        {
            long ways = 0;

            int pathLenght = gridsize*2;
            int maxdown = gridsize;
            int maxright = gridsize;

            int[] waysInts = new int[pathLenght];
            for (int i = 0; i < waysInts.Length; i++)
            {
                waysInts[i] = i > gridsize ? 0 : 1;
            }

            ways = GetPermutations(waysInts, waysInts.Length).ToList().Count;

            return ways;
        }

        public long Awnser(params long[] arguments)
        {
            return FindWaysInGrid(20);
        }
    }
}