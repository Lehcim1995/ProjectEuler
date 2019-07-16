using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Classes;
using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    class Problem10 : IProblem
    {
        public long Awnser(params long[] arguments)
        {
            MyMaths mm = new MyMaths();
            long awnser = 0;
            bool largeprime = false;

            int i = 0;
            while (!largeprime)
            {
                int prime = mm.PrimaAtPosition(i++);
                if (prime > 2000000)
                {
                    largeprime = true;
                    continue;
                }
                awnser += prime;
            }
            
            return awnser;

        }
    }
}
