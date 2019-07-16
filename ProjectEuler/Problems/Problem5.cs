using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    class Problem5 : IProblem
    {
        public int FindSmallest()
        {
            bool found = false;
            int number = 1;
            while (!found)
            {
                found = CheckNumber(++number);
            }

            return number;
        }

        private bool CheckNumber(int number)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (number%i != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public long Answer(params long[] arguments)
        {
            return FindSmallest();
        }
    }

}
