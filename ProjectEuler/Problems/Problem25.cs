using System;
using System.Numerics;
using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem25 : IProblem
    {
        public int solve()
        {
            Fibonacci();
            return 0;
        }

        int Fibonacci()
        {
            int sol = 0;
            int index = 2;
            BigInteger fn = 0;
            BigInteger fn1 = 1;
            BigInteger fn2 = 1;

            while(true)
            {
                fn = fn1 + fn2;
                fn1 = fn2;
                fn2 = fn;
                index ++;

                if (fn.ToString().Length >= 1000)
                {
                    Console.WriteLine($"number: {fn}");
                    Console.WriteLine($"index: {index}");
                    break;
                }
            }

            return sol;
        }

        public long Awnser(params long[] arguments)
        {
            return solve();
        }
    }
}