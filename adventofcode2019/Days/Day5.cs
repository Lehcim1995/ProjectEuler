using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day5 : IProblem
    {
        int[] programOrigin = { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 65, 39, 225, 2, 14, 169, 224, 101, -2340, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 7, 224, 224, 1, 224, 223, 223, 1001, 144, 70, 224, 101, -96, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1101, 92, 65, 225, 1102, 42, 8, 225, 1002, 61, 84, 224, 101, -7728, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 5, 224, 1, 223, 224, 223, 1102, 67, 73, 224, 1001, 224, -4891, 224, 4, 224, 102, 8, 223, 223, 101, 4, 224, 224, 1, 224, 223, 223, 1102, 54, 12, 225, 102, 67, 114, 224, 101, -804, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 3, 224, 1, 224, 223, 223, 1101, 19, 79, 225, 1101, 62, 26, 225, 101, 57, 139, 224, 1001, 224, -76, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 224, 223, 223, 1102, 60, 47, 225, 1101, 20, 62, 225, 1101, 47, 44, 224, 1001, 224, -91, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 224, 223, 223, 1, 66, 174, 224, 101, -70, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 223, 224, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 108, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 329, 101, 1, 223, 223, 1107, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 344, 101, 1, 223, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 359, 101, 1, 223, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 389, 101, 1, 223, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 419, 1001, 223, 1, 223, 1008, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 434, 101, 1, 223, 223, 107, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 449, 1001, 223, 1, 223, 1007, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 464, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 479, 101, 1, 223, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 494, 101, 1, 223, 223, 7, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 509, 101, 1, 223, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 524, 1001, 223, 1, 223, 108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 539, 101, 1, 223, 223, 8, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 554, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 569, 1001, 223, 1, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 599, 101, 1, 223, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 614, 1001, 223, 1, 223, 7, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 629, 1001, 223, 1, 223, 107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 644, 1001, 223, 1, 223, 1107, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 659, 101, 1, 223, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 };

        //int[] programOrigin = { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

        int[] program = { };

        int lastOutput = 0;

        int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            //listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        private void runProgram()
        {
            int pointer = 0;
            program = new int[programOrigin.Length];
            Array.Copy(programOrigin, program, programOrigin.Length);
            
            while(true)
            {
                int opcode = program[pointer];
                bool paramA = false;
                bool paramB = false;
                bool paramC = false;


                if (opcode > 10)
                {
                    var nums = GetIntArray(opcode);

                    opcode = nums[0] + (nums[1] * 10);

                    if (nums.Length >= 3)
                        paramA = nums[2] == 1;

                    if (nums.Length >= 4)
                        paramB = nums[3] == 1;

                    if (nums.Length >= 5)
                        paramC = nums[4] == 1;

                }

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
                    int outputPointer = program[pointer + 3];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    int output = aVal + bVal;

                    program[outputPointer] = output;

                    if (outputPointer != pointer)
                        pointer += 4;
                }
                else if (opcode == 2)
                {
                    //muliplication
                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];
                    int outputPointer = program[pointer + 3];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    int output = aVal * bVal;

                    program[outputPointer] = output;

                    if (outputPointer != pointer)
                        pointer += 4;
                }
                else if (opcode == 3)
                {
                    // Input
                    int aPointer = program[pointer + 1];
                    //int aVal = paramA ? aPointer : program[aPointer];

                    Console.WriteLine("Please profide an input");
                    string input = Console.ReadLine();

                    program[aPointer] = int.Parse(input);

                    pointer += 2;
                }
                else if (opcode == 4)
                {
                    // Output
                    int aPointer = program[pointer + 1];
                    int aVal = paramA ? aPointer : program[aPointer];

                    Console.WriteLine($"Out: {aVal}");

                    pointer += 2;
                }
                else if (opcode == 5)
                {
                    // Jump if true

                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    if (aVal != 0)
                    {
                        pointer = bVal;
                    }
                    else
                    {
                        pointer += 3;
                    }
                }
                else if (opcode == 6)
                {
                    // Jump if false

                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    if (aVal == 0)
                    {
                        pointer = bVal;
                    }
                    else
                    {
                        pointer += 3;
                    }
                }
                else if (opcode == 7)
                {
                    // Less than
                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];
                    int outputPointer = program[pointer + 3];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    int output = aVal < bVal ? 1 : 0;

                    program[outputPointer] = output;

                    if (outputPointer != pointer)
                        pointer += 4;
                }
                else if (opcode == 8)
                {
                    // equels
                    int aPointer = program[pointer + 1];
                    int bPointer = program[pointer + 2];
                    int outputPointer = program[pointer + 3];

                    int aVal = paramA ? aPointer : program[aPointer];
                    int bVal = paramB ? bPointer : program[bPointer];

                    int output = aVal == bVal ? 1 : 0;

                    program[outputPointer] = output;

                    if (outputPointer != pointer)
                        pointer += 4;

                }
                else
                {
                    // Error 
                    Console.WriteLine($"Error at {pointer}, {opcode} is no opcode");
                    return;
                }
            }
        }

        public long Answer(params long[] arguments)
        {
            try
            {
                runProgram();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return 0;
        }
    }
}
