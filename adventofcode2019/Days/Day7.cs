using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019.Classes;
using adventofcode2019.Interfaces;
using adventofcode2019.Classes;

namespace adventofcode2019.Days
{
    public class Day7 : IProblem
    {
        private long[] program = { 3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 46, 63, 76, 97, 118, 199, 280, 361, 442, 99999, 3, 9, 102, 4, 9, 9, 101, 2, 9, 9, 1002, 9, 5, 9, 101, 4, 9, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 101, 5, 9, 9, 102, 3, 9, 9, 101, 3, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 102, 3, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 5, 9, 101, 4, 9, 9, 1002, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 5, 9, 101, 3, 9, 9, 1002, 9, 5, 9, 1001, 9, 5, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99 };

        private IntCodeProcessor amplifier = new IntCodeProcessor(inputMode: IntCodeProcessor.InputMode.Set);

        private IntCodeProcessor2 amplifier2;

        public long Answer(params long[] arguments)
        {
            int[] sequence = {0, 1, 2, 3, 4};
            int maxVal = 0;
            int maxVal2 = 0;

            // for permutations of sequence
            // do this

            var perm = MyMaths.GeneratePermutations(sequence, null);

            foreach (var perms in perm)
            {
                int ampA = amplifier.RunCode(program.ToList(), new int[] { perms[0], 0 });
                int ampB = amplifier.RunCode(program.ToList(), new int[] { perms[1], ampA });
                int ampC = amplifier.RunCode(program.ToList(), new int[] { perms[2], ampB });
                int ampD = amplifier.RunCode(program.ToList(), new int[] { perms[3], ampC });
                int ampE = amplifier.RunCode(program.ToList(), new int[] { perms[4], ampD });

                if (ampE > maxVal)
                    maxVal = ampE;
                /*
                amplifier2 = new IntCodeProcessor2(program) { InputModeSetting = IntCodeProcessor2.InputMode.Set, InputNumbers = new List<long> { perms[0], 0 } };

                int ampA2 = amplifier2.Run();
                int ampB2 = amplifier2.Run(program.ToList(), new int[] { perms[1], ampA });
                int ampC2 = amplifier2.Run(program.ToList(), new int[] { perms[2], ampB });
                int ampD2 = amplifier2.Run(program.ToList(), new int[] { perms[3], ampC });
                int ampE2 = amplifier2.Run(program.ToList(), new int[] { perms[4], ampD });

                if (ampE2 > maxVal2)
                    maxVal2 = ampE2;
                    */
            }

            return maxVal;
        }
    }
}
