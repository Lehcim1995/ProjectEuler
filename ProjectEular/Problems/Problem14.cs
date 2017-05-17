using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;

namespace ProjectEular.Problems
{
    class Problem14 : IProblem
    {
        private int chain(int input)
        {
            long number = input;
            int chain = 1;
            long last = 0;

            while (number != 1)
            {
                if (number%2 == 0)
                {
                    number /= 2;
                }
                else
                {
                    number = (number*3) + 1;
                }

                chain++;
            }

            return chain;
        }

        private int Findlongestchain()
        {
            int largestchain = 0;
            int number = 0;

            for (int i = 2; i < 1000000; i++)
            {
                int num = chain(i);
                if (largestchain < num)
                {
                    largestchain = num;
                    number = i;
                }
            }

            return number;
        }


        public long Awnser(params long[] arguments)
        {
            return Findlongestchain();
        }
    }
}
