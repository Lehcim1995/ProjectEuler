using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019.Classes;
using adventofcode2019.Interfaces;

namespace adventofcode2019.Days
{
    public class Day9 : IProblem
    {
        private long[] code = { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
        private long[] code2 = { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
        private long[] code3 = { 104, 1125899906842624, 99 };

        private IntCodeProcessor processor = new IntCodeProcessor();

        public long Answer(params long[] arguments)
        {
            
            Console.WriteLine(processor.RunCode(code.ToList(), new int[] {}));

            return 0;
        }
    }
}
