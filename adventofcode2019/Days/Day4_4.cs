using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day4_4 : IProblem
    {
        int input1 = 240920;
        int input2 = 789857;

        private bool passCriteria(int pass)
        {
            int last = -1;
            bool hasDouble = false;
            Dictionary<int, int> repeat = new Dictionary<int, int>();

            for(int i = 0; i < 6; i++)
            {
                int curr = getNumberOn(pass, i);

                if (curr < last)
                {
                    return false;
                }

                if (curr == last)
                {
                    if (repeat.ContainsKey(curr))
                    {
                        repeat[curr] += 1;
                    }
                    else
                    {
                        repeat.Add(last, 2);
                    }
                    
                }

                last = curr;

            }

            foreach(var r in repeat)
            {
                if (r.Value == 2)
                {
                    return true;
                }
            }

            return false;
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
                    Console.WriteLine($"input {i} is correct");
                    
                }
            }

            return awnser;
        }
    }
}
