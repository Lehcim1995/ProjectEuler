using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    class Problem9 : IProblem
    {
        public long FindABCForNumber(int number)
        {
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;

            // c^2 = b^2 = a^2
            //
            // a + b + c = 1000
            // a*a + b*b = c*c
            // a + b + (wortel(a*a + b*b)) = 1000
            // a = b
            // d = wortel(d*d) = 1000
            // https://www.wolframalpha.com/input/?i=a+%2B+b+%2B+c+%3D+1000,++c%5E2+%3D+a%5E2+%2B+b%5E2,+x+%3D+a*b*c,+a+%3E+0

            c = Math.Sqrt(a*a + b*b);

            double anwser = a*b*c;

            return (long)anwser;
        }


        public long Answer(params long[] arguments)
        {
            return FindABCForNumber(1000);
        }
    }
}