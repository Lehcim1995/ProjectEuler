using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Classes;
using ProjectEular.Interfaces;

namespace ProjectEular.Problems
{
    class Problem12 : IProblem
    {
        public long Awnser(params long[] arguments)
        {
            MyMaths mm = new MyMaths();

            for (int i = 0; i < 2000000; i++)
            {
                int tri = mm.TriangleNumber(i);
                int dev = mm.NumberOfDevisors(tri);
                if (dev > 500)
                {
                    return tri;
                }
            }

            return 0;
        }
    }
}
