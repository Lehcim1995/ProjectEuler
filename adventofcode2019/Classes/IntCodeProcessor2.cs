using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace adventofcode2019.Classes
{
    public class IntCodeProcessor2
    {
        private enum ParameterMode
        {
            Relative,
            Position,
            Immediate
        }

        public enum InputMode
        {
            Set,
            Console
        }

        public enum OutputMode
        {
            Return,
            Console
        }

        internal class Instruction
        {
            public static readonly Instruction EXIT = new Instruction("Exit", 0, 99, null);
            public static readonly Instruction MULTIPLY = new Instruction("Multiply", 3, 2, null);
            public static readonly Instruction ADDITION = new Instruction("Addition", 3, 1, null);
            public static readonly Instruction INPUT = new Instruction("Input", 1, 3, null);
            public static readonly Instruction OUTPUT = new Instruction("Output", 1, 4, null);
            public static readonly Instruction JUMP_IF_TRUE = new Instruction("Jump if true", 2, 5, null);
            public static readonly Instruction JUMP_IF_FALSE = new Instruction("Jump if false", 2, 6, null);
            public static readonly Instruction LESS_THAN = new Instruction("Less than", 3, 7, null);
            public static readonly Instruction EQUELS = new Instruction("Equels", 3, 8, null);
            public static readonly Instruction CHANGE_RELATIVE = new Instruction("Change relative", 1, 9, null);
            public static readonly Instruction ERROR = new Instruction("ERROR", 0, -1, null);

            public static IEnumerable<Instruction> Values
            {
                get
                {
                    yield return EXIT;
                    yield return ADDITION;
                    yield return MULTIPLY;
                    yield return INPUT;
                    yield return OUTPUT;
                    yield return JUMP_IF_TRUE;
                    yield return JUMP_IF_FALSE;
                    yield return LESS_THAN;
                    yield return EQUELS;
                    yield return CHANGE_RELATIVE;
                }
            }

            public static Instruction GetInstruction(int opcode)
            {
                var s = Values.FirstOrDefault(t => t.OpCode == opcode);

                return s ?? ERROR;
            }

            public string Name { get; set; }
            public int Parameters { get; set; }
            public int OpCode { get; set; }

            public delegate void Execute(long[] parameters);

            public Execute ExecuteInstruction;

            Instruction(string name, int parameters, int opCode, Execute executeInstruction)
            {
                this.Name = name;
                this.Parameters = parameters;
                this.OpCode = opCode;
                this.ExecuteInstruction = executeInstruction;
            }
        }

        class IntCodeParameters
        {
            public List<long> Values { get; set; }
            public List<ParameterMode> Modes { get; set; }

            public IntCodeParameters(int instParameters)
            {
                Values = new List<long>(instParameters);
                Modes = new List<ParameterMode>(instParameters);

                for (int i = 0; i < instParameters - 1; i++)
                {
                    Modes.Add(ParameterMode.Position);
                }

                Modes.Add(instParameters == 1 ? ParameterMode.Position : ParameterMode.Immediate);
                //Modes.Add(ParameterMode.Immediate);
            }
        }

        private readonly long[] _program;
        private List<long> _memory = new List<long>();
        public List<long> InputNumbers { get; set; } = new List<long>();
        private IntCodeParameters _parameters;

        public List<long> Memory => _memory;

        private int _programPointer;
        private int _relativePointer;
        private int _inputPointer;

        private long _returnValue;
        private bool _return;
        private bool _run = true;
        public bool Debug { get; set; }
        public InputMode InputModeSetting { get; set; }
        public bool IsRunning { get { return _run; } private set { _run = value; } }

        public IntCodeProcessor2(long[] program)
        {
            this._program = program;


            _memory.AddRange(_program);
            _programPointer = 0;
            _relativePointer = 0;
        }

        /// <summary>
        /// Clears the memory and resets the program pointer and relative pointer
        /// </summary>
        public void Reset()
        {
            _memory.Clear();
            _memory.AddRange(_program);
            _programPointer = 0;
            _relativePointer = 0;
            _inputPointer = 0;
            _returnValue = 0;
            _return = false;
            _run = true;
        }

        /// <summary>
        /// This runs the specific intcode profiede.
        /// If the intcode contains an Output instruction it will return this and keeps state. 
        /// If this method is rerun it will continue 
        /// </summary>
        /// <returns> output </returns>
        public long RunWithOutput()
        {
            // 
            _run = true;
            _return = false;

            while (!_return && _run)
            {
                // 
                int opCode = ParseOpcode(_memory[_programPointer]);

                var inst = Instruction.GetInstruction(opCode);
                ParseParameters(_memory[_programPointer], inst);

                if (Debug)
                {
                    Console.WriteLine($"Current pointer location {_programPointer}");
                    Console.WriteLine($"Current relative pointer location {_relativePointer}");
                    Console.Write($"Original Input {_memory[_programPointer]}");
                    for (int i = 0; i < inst.Parameters; i++)
                    {
                        Console.Write($",{Get(i + 1, ParameterMode.Immediate)}");
                    }

                    Console.Write("\n");

                    Console.WriteLine($"Name: {inst.Name}");

                    for (int i = 0; i < inst.Parameters; i++)
                    {
                        Console.WriteLine($"Parameter value: {Get(i + 1, ParameterMode.Immediate)} | Mode: {_parameters.Modes[i]} | Actual Value: {Get(i + 1)}");
                    }
                }

                switch (inst.OpCode)
                {
                    case 1:
                        Addition();
                        break;
                    case 2:
                        Multiply();
                        break;
                    case 3:
                        Input();
                        break;
                    case 4:
                        Output();
                        break;
                    case 5:
                        JumpIfTrue();
                        break;
                    case 6:
                        JumpIfFalse();
                        break;
                    case 7:
                        LessThan();
                        break;
                    case 8:
                        Equels();
                        break;
                    case 9:
                        ChangeRelativePointer();
                        break;
                    case 99:
                        Exit();
                        break;
                    default:
                        Console.WriteLine($"Faulty opcode");

                        break;
                }

                if (Debug)
                {
                    //Thread.Sleep(500);

                    Console.WriteLine("\n");
                }
            }


            return _returnValue;
        }

        /// <summary>
        /// This is an encapulation of the RunWithOutput fucntion
        /// Runs the intcode and outputs the output only in the console
        /// It wont stop till it reaches the Exit intcode
        /// </summary>
        public void Run()
        {
            // Reset all befor running so not state is stored in the Proccessor.
            Reset();
            // While not done
            while (_run)
            {
                RunWithOutput();
            }
        }

        // Internal functions

        private void DebugLog(string log)
        {
            if (Debug)
            {
                Console.WriteLine(log);
            }
        }

        private void ParseParameters(long code, Instruction inst)
        {
            List<long> listOfLongs = new List<long>();
            while (code > 0)
            {
                listOfLongs.Add(code % 10);
                code = code / 10;
            }

            _parameters = new IntCodeParameters(inst.Parameters);

            for (int i = 0; i < inst.Parameters; i++)
            {
                _parameters.Values.Add(Get(i + 1, ParameterMode.Immediate));
            }

            for (int i = 2; i < listOfLongs.Count; i++)
            {
                int value = (int) listOfLongs[i];
                ParameterMode m = value == 0 ? ParameterMode.Position :
                    value == 1 ? ParameterMode.Immediate : ParameterMode.Relative;

                _parameters.Modes[i-2] = m ;
            }
        }

        private int ParseOpcode(long code)
        {
            return (int) code % 100;
        }

        private void Put(long value)
        {
            int position = (int) _parameters.Values.Last();

            if (_parameters.Modes.Last() == ParameterMode.Relative)
            {
                position = _relativePointer + (int)_parameters.Values.Last();
            }

            if (position > _memory.Count - 1)
            {
                var current = position - _memory.Count;
                for (int i = 0; i < current + 1; i++)
                {
                    _memory.Add(0);
                }
            }

            if (Debug)
                Console.WriteLine($"Setting position {position} to value {value} ");

            _memory[position] = value;
        }

        private long Get(int parameter)
        {
            return Get(parameter, _parameters.Modes[parameter-1]);
        }

        private void AdvancePointer(int count)
        {
            _programPointer += count + 1;
        }

        private long Get(int parameter, ParameterMode mode)
        {
            long value = _memory[_programPointer + parameter];
            long output;

            switch (mode)
            {
                case ParameterMode.Immediate:
                    output = value;
                    break;
                case ParameterMode.Position:
                    output = 0;

                    if (value < _memory.Count)
                    {
                        output = _memory[(int)value];
                    }
                    break;
                case ParameterMode.Relative:
                    output = 0;

                    if (_relativePointer + (int)value < _memory.Count)
                    {
                        output = _memory[_relativePointer + (int)value];
                    }
                    break;
                default:
                    output = 0;
                    break;
            }


            return output;
        }

        // All IntCode stuff

        private void Exit()
        {
            _run = false;
        }

        private void Multiply()
        {
            Put(Get(1) * Get(2));
            AdvancePointer(3);
        }

        private void Addition()
        {
            Put(Get(1) + Get(2));
            AdvancePointer(3);
        }

        private void Input()
        {
            long longValue;

            switch (InputModeSetting)
            {
                case InputMode.Set:

                    // Check if input pointer rolled over before retrieving the input because the input numbers could have changed
                    if (_inputPointer >= InputNumbers.Count)
                    {
                        _inputPointer = 0;
                    }

                    longValue = InputNumbers[_inputPointer];
                    _inputPointer++;
                    
                    break;
                case InputMode.Console:
                    Console.WriteLine("Give an input please");
                    string input = Console.ReadLine();

                    longValue = long.Parse(input);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

           

            Put(longValue);
            AdvancePointer(1);
        }

        private void Output()
        {

            switch (_parameters.Modes[0])
            {
                case ParameterMode.Relative:
                    _returnValue = Get(1, ParameterMode.Relative);
                    _return = true;
                    
                    //Console.WriteLine($"Outputting: {Get(1, ParameterMode.Relative)}");
                    break;
                case ParameterMode.Position:
                    _returnValue = Get(1, ParameterMode.Position);
                    _return = true;
                    //Console.WriteLine($"Outputting: {Get(1, ParameterMode.Position)}");
                    break;
                case ParameterMode.Immediate:
                    _returnValue = Get(1, ParameterMode.Immediate);
                    _return = true;
                    //Console.WriteLine($"Outputting: {Get(1, ParameterMode.Immediate)}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
            AdvancePointer(1);
        }

        private void JumpIfTrue()
        {
            if (Get(1) != 0)
            {
                _programPointer = (int) Get(2);
                if (Debug)
                {
                    Console.WriteLine($"Jumped to location {(int)Get(2)}");
                }
            }
            else
            {
                _programPointer += 3;
                if (Debug)
                {
                    Console.WriteLine($"Didnt jump");
                }
            }
        }

        private void JumpIfFalse()
        {
            if (Get(1) == 0)
            {
                _programPointer = (int) Get(2);
                if (Debug)
                {
                    Console.WriteLine($"Jumped to location {(int)Get(2)}");
                }
            }
            else
            {
                _programPointer += 3;
                if (Debug)
                {
                    Console.WriteLine($"Didnt jump");
                }
            }
        }

        private void LessThan()
        {
            Put(Get(1) < Get(2) ? 1 : 0);
            AdvancePointer(3);
        }

        private void Equels()
        {
            Put(Get(1) == Get(2) ? 1 : 0);
            AdvancePointer(3);
        }

        private void ChangeRelativePointer()
        {
            _relativePointer += (int) Get(1);
            AdvancePointer(1);
        }
    }
}