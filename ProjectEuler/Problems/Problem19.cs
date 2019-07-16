using System;
using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem19 : IProblem
    {
        public int solve()
        {
            DateTime d = new DateTime(1901, 1, 1);
            DateTime stop = new DateTime(2000, 12, 31);
            int sum = 0;

            while (d < stop)
            {
                Console.WriteLine(d);
                Console.WriteLine(d.DayOfWeek);
                if (d.DayOfWeek == DayOfWeek.Sunday)
                {
                    sum += 1;
                }
                d = d.AddMonths(1);
            
            }

            return sum;   
        }

        public long Awnser(params long[] arguments)
        {
            return solve();
        }
    }
}