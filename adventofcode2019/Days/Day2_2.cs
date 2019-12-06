using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day2_2 : IProblem
    {
        int[] programOrigin = { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 6, 19, 1, 9, 19, 23, 1, 6, 23, 27, 1, 10, 27, 31, 1, 5, 31, 35, 2, 6, 35, 39, 1, 5, 39, 43, 1, 5, 43, 47, 2, 47, 6, 51, 1, 51, 5, 55, 1, 13, 55, 59, 2, 9, 59, 63, 1, 5, 63, 67, 2, 67, 9, 71, 1, 5, 71, 75, 2, 10, 75, 79, 1, 6, 79, 83, 1, 13, 83, 87, 1, 10, 87, 91, 1, 91, 5, 95, 2, 95, 10, 99, 2, 9, 99, 103, 1, 103, 6, 107, 1, 107, 10, 111, 2, 111, 10, 115, 1, 115, 6, 119, 2, 119, 9, 123, 1, 123, 6, 127, 2, 127, 10, 131, 1, 131, 6, 135, 2, 6, 135, 139, 1, 139, 5, 143, 1, 9, 143, 147, 1, 13, 147, 151, 1, 2, 151, 155, 1, 10, 155, 0, 99, 2, 14, 0, 0 };

        int[] program = { };

        int lastOutput = 0;

        private void runProgram(int noun, int verb)
        {
            int pointer = 0;
            program = new int[programOrigin.Length];
            Array.Copy(programOrigin, program, programOrigin.Length);
            program[1] = noun;
            program[2] = verb;

            Console.WriteLine($"Starting program with noun {noun} and verb {verb}");
            
            while(true)
            {
                int opcode = program[pointer];

                if (opcode == 99)
                {
                    Console.WriteLine($"Program has ended at {pointer} with output {program[0]}");
                    lastOutput = program[0];
                    return;
                }
                else if (opcode == 1)
                {
                    // addition
                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];
                    int outputPointer = program[ pointer + 3];

                    int aVal = program[aPointer];
                    int bVal = program[bPointer];

                    int output = aVal + bVal;

                    program[outputPointer] = output;
                }
                else if (opcode == 2)
                {
                    //muliplication
                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];
                    int outputPointer = program[pointer + 3];

                    int aVal = program[aPointer];
                    int bVal = program[bPointer];

                    int output = aVal * bVal;

                    program[outputPointer] = output;
                }
                else
                {
                    // Error 
                    Console.WriteLine($"Error at {pointer}, {opcode} is no opcode");
                    return;
                }

                pointer += 4;
            }
        }

        public long Answer(params long[] arguments)
        {

            for(int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    runProgram(noun, verb);
                    if (lastOutput == 19690720)
                    {
                        Console.WriteLine($" Program finnished with {lastOutput}, Score is { 100 * noun + verb}");
                        return 100 * noun + verb;
                    }
                }
            }

            Console.WriteLine($" Program finnished with no output and no score");
            return 0;
        }
    }
}
