using System;
using System.Collections.Generic;
using System.Numerics;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem75 : IProblem
    {
        Dictionary<int, List<int>> per = new Dictionary<int, List<int>>();

        public int solve()
        {
            // lenght, solutions;
            var now = DateTime.Now;
            Console.WriteLine(now);
            var map = new Dictionary<int, int>();

            int num = 0;

            for (int a = 2; a < 1500000; a++) // 000
            {
                int max = 1500000;
            
                for (int b = 2; b < max; b++) // 000
                {
                    if (a+b>1500000)
                    {
                        continue;
                    }

                    if (b < a)
                    {
                        continue;
                    }
                    bool correct;
                    var c = giveC(a,b,out correct);
                    var lenght = a + b + c;

                    if (lenght > 1500000)
                    {
                        continue;
                    }

                    if (correct)
                    {
                        // Console.WriteLine($"a:{a} b:{b} c:{c} lenght:{lenght}");
                        if (map.ContainsKey((int)lenght))
                        {
                            map[(int)lenght] += 1;
                        }else {
                            map.Add((int)lenght, 1);
                        }
                    }
                }

                var done2 = DateTime.Now;
                Console.WriteLine($"Next time wasted: H:{(done2-now).Hours} M:{(done2-now).Minutes} S:{(done2-now).Seconds}");
            }

            foreach(var keyval in map)
            {
                if (keyval.Value == 1)
                {
                    num += 1;
                }
            }

            var done = DateTime.Now;
            Console.WriteLine($"Solve took H:{(done-now).Hours} M:{(done-now).Minutes} S:{(done-now).Seconds}");
            return num;
        }

        public bool triangle(int lenght)
        {
            // phytagoras 
            // a^2+b^2=c^2
            // a + b + c = lenght

            return false;
        }
    
        public BigInteger giveC (BigInteger a, BigInteger b, out bool correct)
        {
            BigInteger a2 = a * a;
            BigInteger b2 = b * b;

            var c2 = (a2+b2);
            var c = c2.Sqrt();

            correct = (a2 + b2) == c*c;

            return c;
        }
        public bool correct(BigInteger a, BigInteger b, BigInteger c)
        {
            BigInteger a2 = a * a;
            BigInteger b2 = b * b;
            BigInteger c2 = c * c;

            if ((a2 + b2) == c2)
            {
                return true;
            }

            return false;
        }

        public long Answer(params long[] arguments)
        {
            return solve();
        }
    }

    public static class IntegerExtensions {

        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root*root;
            BigInteger upperBound = (root + 1)*(root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}