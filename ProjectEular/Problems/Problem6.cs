using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;

namespace ProjectEular.Problems
{
    class Problem6 : IProblem
    {
        public int Diffrence()
        {
            int number = 100;
            return SumOfSquares(number) - SquareOfSums(number);
        }

        private int SumOfSquares(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                sum += i*i;
            }
            return sum;
        }

        private int SquareOfSums(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                sum += i;
            }
            return sum * sum;
        }

        public long Awnser(params long[] arguments)
        {
            return Diffrence();
        }
    }
}
