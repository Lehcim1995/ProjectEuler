using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;

namespace ProjectEular.Problems
{
    class Problem9 : IProblem
    {
        public long FindABCForNumber(int number)
        {
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;

            // a + b + c = 1000
            // a*a + b*b = c*c
            // a + b + (wortel(a*a + b*b)) = 1000
            // a = b
            // d = wortel(d*d) = 1000
            //

            c = Math.Sqrt(a*a + b*b);

            double anwser = a*b*c;

            return (long)anwser;
        }


        public long Awnser(params long[] arguments)
        {
            return FindABCForNumber(1000);
        }
    }
}