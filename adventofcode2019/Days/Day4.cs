using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day4 : IProblem
    {
        int input1 = 240920;
        int input2 = 789857;

        private bool passCriteria(int pass)
        {
            int last = -1;
            bool hasDouble = false;

            for(int i = 0; i < 6; i++)
            {
                int curr = getNumberOn(pass, i);

                if (curr < last)
                {
                    return false;
                }

                if (curr == last)
                {
                    hasDouble = true;
                }

                last = curr;

            }
            return hasDouble;
        }

        private int getNumberOn(int input, int num)
        {
            String s = input + "";

            if (num > s.Length)
            {
                // error
            }

            return int.Parse(s[num] + "");
        }

        public long Answer(params long[] arguments)
        {
            int awnser = 0;

            for(int i = input1; i < input2; i++)
            {
                if (passCriteria(i))
                {
                    awnser++;
                }
            }

            return awnser;
        }
    }
}
