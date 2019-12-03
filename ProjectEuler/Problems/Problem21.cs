using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem21 : IProblem
    {
        private int[] ProperDivisors(int input)
        {
            var div = new List<int>();

            for (var i = 1; i < input - 1; i++)
            {
                var intDiv = input / i;
                var floatDiv = (float) input / i;

                if (Math.Abs(floatDiv - intDiv) < 0.0001f)
                {
                    div.Add(i);
                }
            }

            return div.ToArray();
        }

        private int ProperDivisorsSum(int input)
        {
            return ProperDivisors(input).Sum();
        }

        public long Answer(params long[] arguments)
        {
            int answer = 0;

            for (int i = 1; i < 10000; i++)
            {
                var output = ProperDivisorsSum(i);
                if (output != i)
                {

                    var output2 = ProperDivisorsSum(output);

                    if (output2 == i)
                    {
                        Console.WriteLine(i + " " + output);
                        answer += i;
                    }
                }
            }

            return answer;
        }
    }
}
