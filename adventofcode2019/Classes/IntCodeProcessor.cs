using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Classes
{
    public class IntCodeProcessor
    {
        public enum InputMode
        {
            Console,
            Set
        }

        private bool _debug;
        private InputMode _inputMode;

        public IntCodeProcessor(bool debug = false, InputMode inputMode = InputMode.Console)
        {
            this._debug = debug;
            this._inputMode = inputMode;
        }

        long[] GetIntArray(long num)
        {
            List<long> listOfLongs = new List<long>();
            while (num > 0)
            {
                listOfLongs.Add(num % 10);
                num = num / 10;
            }

            //listOfInts.Reverse();
            return listOfLongs.ToArray();
        }

        public int RunCode(List<long> program, int[] inputNumber)
        {
            // Current pointer location
            int pointer = 0;

            // Relative pointer location
            int relativePointer = 0;

            // Last output from the "output" opcode
            var outputVar = 0;

            // input counter when multiple "set" input are used 
            var currentInput = 0;

            // if the program should contine to run
            bool run = true;

            while (run)
            {
                var opCode = program[pointer];
                bool immediateA = false;
                bool immediateB = false;
                bool immediateC = false;

                bool relativeA = false;
                bool relativeB = false;
                bool relativeC = false;

                if (_debug)
                    Console.WriteLine($"Origin opcode {opCode}");

                if (opCode > 10)
                {
                    var nums = GetIntArray(opCode);

                    opCode = nums[0] + (nums[1] * 10);

                    if (nums.Length >= 3)
                    {
                        immediateA = nums[2] == 1;
                        relativeA = nums[2] == 2;
                    }

                    if (nums.Length >= 4)
                    {
                        immediateB = nums[3] == 1;
                        relativeB = nums[3] == 2;
                    }

                    if (nums.Length >= 5)
                    {
                        immediateC = nums[4] == 1;
                        relativeC = nums[4] == 2;
                    }
                }

                if (_debug)
                {
                    string parmA = immediateA ? "Immediate" : relativeA ? "Relative" : "Pointer";
                    string parmB = immediateB ? "Immediate" : relativeB ? "Relative" : "Pointer";
                    string parmC = immediateC ? "Immediate" : relativeC ? "Relative" : "Pointer";

                    Console.WriteLine(
                        $"OpCode {opCode} parmmodes a {parmA} b {parmB} c {parmC}");
                    Console.WriteLine($"Current pointer location {pointer}");
                }

                switch (opCode)
                {
                    case 99:
                        Console.WriteLine($"Program has ended at {pointer} with output {program[0]}");
                        run = false;
                        break;
                    case 1:
                    {
                        // addition
                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];
                        var outputPointer = program[pointer + 3];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];
                        var outputLocation = relativeC ? (relativePointer + bPointer) : outputPointer;

                        var output = aVal + bVal;

                        if (_debug)
                            Console.WriteLine(
                                $"Addtion parmA {aVal} parmB {bVal} Output {output} Outputlocation {outputLocation}");

                        if (outputLocation > program.Count)
                        {
                            program.AddRange(new long[outputLocation]);
                        }

                        program[(int) outputLocation] = output;

                        if (outputPointer != pointer)
                            pointer += 4;
                        break;
                    }
                    case 2:
                    {
                        //muliplication
                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];
                        var outputPointer = program[pointer + 3];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];
                        var outputLocation = relativeC ? (relativePointer + bPointer) : outputPointer;

                        var output = aVal * bVal;

                        if (_debug)
                            Console.WriteLine(
                                $"Multiplication parmA {aVal} parmB {bVal} Output {output} Outputlocation {outputLocation}");


                        program[(int) outputLocation] = output;
                        if (outputLocation > program.Count)
                        {
                            program.AddRange(new long[outputLocation]);
                        }

                        if (outputPointer != pointer)
                            pointer += 4;
                        break;
                    }
                    case 3:
                    {
                        // Input
                        var aPointer = program[pointer + 1];
                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int)aPointer] : program[(int)aPointer];

                        if (_debug)
                            Console.WriteLine($"Input output at {aVal}");

                        switch (_inputMode)
                        {
                            case InputMode.Console:
                                Console.WriteLine("Please provide an input");
                                string input = Console.ReadLine();

                                program[(int) aVal] = int.Parse(input);
                                break;
                            case InputMode.Set:
                                program[(int) aVal] = inputNumber[currentInput];

                                currentInput++;
                                if (currentInput >= inputNumber.Length)
                                {
                                    currentInput = 0;
                                }

                                break;
                        }


                        pointer += 2;
                        break;
                    }
                    case 4:
                    {
                        // Output
                        var aPointer = program[pointer + 1];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];

                        if (_debug)
                            Console.WriteLine($"Output output at {aPointer} with Value {aVal}");

                        Console.WriteLine($"Out: {aVal}");
                        outputVar = (int) aVal;

                        if (aVal > program.Count)
                        {
                            //program.Capacity += aVal + 1;
                            program.AddRange(new long[aVal]);
                        }

                        program[(int) aVal] = aPointer;

                        pointer += 2;
                        break;
                    }
                    case 5:
                    {
                        // Jump if true

                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];

                        if (_debug)
                            Console.WriteLine($"Jump if true. jump? {aVal != 0} to loctation {bVal}");

                        if (aVal != 0)
                        {
                            pointer = (int) bVal;
                        }
                        else
                        {
                            pointer += 3;
                        }

                        break;
                    }
                    case 6:
                    {
                        // Jump if false

                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];

                        if (_debug)
                            Console.WriteLine($"Jump if false. jump? {aVal == 0} to loctation {bVal}");

                        if (aVal == 0)
                        {
                            pointer = (int) bVal;
                        }
                        else
                        {
                            pointer += 3;
                        }

                        break;
                    }
                    case 7:
                    {
                        // Less than
                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];
                        var outputPointer = program[pointer + 3];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];
                        var outputLocation = relativeC ? (relativePointer + bPointer) : outputPointer;

                        int output = aVal < bVal ? 1 : 0;

                        if (_debug)
                            Console.WriteLine($"Less than? {aVal} < {bVal} ? {output} at {outputLocation}");

                        if (outputLocation > program.Count)
                        {
                            program.AddRange(new long[outputLocation]);
                        }

                        program[(int) outputLocation] = output;

                        if (outputLocation != pointer)
                            pointer += 4;
                        break;
                    }
                    case 8:
                    {
                        // equels
                        var aPointer = program[pointer + 1];
                        var bPointer = program[pointer + 2];
                        var outputPointer = program[pointer + 3];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];
                        var bVal = immediateB ? bPointer :
                            relativeB ? program[relativePointer + (int) bPointer] : program[(int) bPointer];
                        var outputLocation = relativeC ? (relativePointer + bPointer) : outputPointer;

                        var output = aVal == bVal ? 1 : 0;

                        if (_debug)
                            Console.WriteLine($"Equels? {aVal} < {bVal} ? {output} at {outputLocation}");

                        if (outputLocation > program.Count)
                        {
                            program.AddRange(new long[outputLocation]);
                        }

                        program[(int) outputLocation] = output;

                        if (outputLocation != pointer)
                            pointer += 4;
                        break;
                    }
                    case 9:
                    {
                        // Change relative param
                        var aPointer = program[pointer + 1];

                        var aVal = immediateA ? aPointer :
                            relativeA ? program[relativePointer + (int) aPointer] : program[(int) aPointer];

                        relativePointer += (int) aVal;

                        if (_debug)
                            Console.WriteLine($"Changing relative pointer to {relativePointer}");

                        pointer += 2;

                        break;
                    }
                    default:
                        // Error 
                        Console.WriteLine($"Error at {pointer}, {opCode} is no opcode");
                        run = false;
                        break;
                }
            }

            return outputVar;
        }
    }
}