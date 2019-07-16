using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    class Problem7 : IProblem
    {
        public int PrimaAtPosition(int position)
        {
            int primenr = 0;
            int number = 1;

            while (primenr != position)
            {
                if (isPrime(++number))
                {
                    primenr++;
                }
            }

            return number;
        }

        private bool isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number%i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public long Awnser(params long[] arguments)
        {
            return PrimaAtPosition(10001);
        }
    }
}
