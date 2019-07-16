using System;
using System.Numerics;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem20 : IProblem
    {
        public int solve()
        {
            BigInteger val = fact(100);

            Console.WriteLine(val);

            BigInteger sum = 0;
            while(val > 0)
            {
                sum += val % 10;
                val = val / 10;
            }

            return (int)sum;
        }

        BigInteger fact(int factorio)
        {
            BigInteger num = 1;

            for(int i = 1; i < factorio; i ++ )
            {
                num*= i;
            }

            return num;
        }

        public long Answer(params long[] arguments)
        {
            return solve();
        }
    }
}