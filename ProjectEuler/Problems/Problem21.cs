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
            List<int> div = new List<int>();

            for (int i = 1; i < input - 1; i++)
            {
                int intdiv = input / i;
                float floatdiv = (float) input / (float) i;

                if (Math.Abs(floatdiv - intdiv) < 0.0001f)
                {
                    //Console.WriteLine("yay " + i);
                    div.Add(i);
                }
            }

            return div.ToArray();
        }

        private int ProperDivisorsSum(int input)
        {
            var temp = ProperDivisors(input).Sum();
            //Console.WriteLine(" sum of " + input + " is " + temp);
            return temp;
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
