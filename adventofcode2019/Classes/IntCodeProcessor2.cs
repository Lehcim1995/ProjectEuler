using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Classes
{
    public class IntCodeProcessor2
    {
        private enum ParamaterMode
        {
            Relative,
            Position,
            Immediate
        }

        internal class Instruction
        {
            public static readonly Instruction EXIT =               new Instruction("Exit", 0, 99, null);
            public static readonly Instruction MUILTIPLY =          new Instruction("Mulitply", 3, 2, null);
            public static readonly Instruction ADDITION =           new Instruction("Addition", 3, 1, null);
            public static readonly Instruction INPUT =              new Instruction("Input", 1, 3, null);
            public static readonly Instruction OUTPUT =             new Instruction("Output", 1, 4, null);
            public static readonly Instruction JUMP_IF_TRUE =       new Instruction("Jump if true", 2, 5, null);
            public static readonly Instruction JUMP_IF_FALSE =      new Instruction("Jump if false", 2, 6, null);
            public static readonly Instruction LESS_THAN =          new Instruction("Less than", 3, 7, null);
            public static readonly Instruction EQUELS =             new Instruction("Equels", 3, 8, null);
            public static readonly Instruction CHANGE_RELATIVE =    new Instruction("Change relative", 1, 9, null);
            public static readonly Instruction ERROR =              new Instruction("ERROR", -1, -1, null);

            public static IEnumerable<Instruction> Values
            {
                get
                {
                    yield return EXIT;
                    yield return ADDITION;
                    yield return MUILTIPLY;
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
                return Values.FirstOrDefault(t => t.Opcode == opcode).IfDefaultGiveMe(ERROR);
            }

            public string Name { get; set; }
            public int Paramters { get; set; }
            public int Opcode { get; set; }
            public delegate void Execute( long[] parameters);
            public Execute ExecuteInsturction;

            Instruction(string name, int parameters, int opcode, Execute ExecuteInsturction)
            {
                this.Name = name;
                this.Paramters = parameters;
                this.Opcode = opcode;
                this.ExecuteInsturction = ExecuteInsturction;
            }
        }

        class IntCodeParameters
        {
            public List<long> Values { get; set; }
            public List<ParamaterMode> Modes { get; set; }
        }

        private long[] program;
        private List<long> memory;
        private IntCodeParameters parameters;

        public List<long> Memory { get { return memory; } private set { } }
 
        private int programPointer;
        private int relativePointer;

        private bool run;

        public IntCodeProcessor2(long[] program)
        {
            this.program = program;
        }

        public void Run()
        {
            memory.AddRange(program);

            programPointer = 0;

            

            while(run)
            {


                // 
                int opcode = ParseOpcode(memory[programPointer]);
                ParseParameters(memory[programPointer]);

                Instruction inst = Instruction.GetInstruction(opcode);


                switch(inst.Opcode)
                {
                    case 1:
                        Addition();
                        break;
                    case 2:
                        Muiltiply();
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
                        break;

                }

            }
        }

        public void ParseParameters(long code)
        {
            List<long> listOfLongs = new List<long>();
            while (code > 0)
            {
                listOfLongs.Add(code % 10);
                code = code / 10;
            }


            parameters = new IntCodeParameters();
           
            for(int i = 2; i < listOfLongs.Count; i ++)
            {
                int value = (int)listOfLongs[i];
                ParamaterMode m = value == 0 ? ParamaterMode.Position : value == 1 ? ParamaterMode.Immediate : ParamaterMode.Relative;

                parameters.Modes.Add(m);
            }
        }

        public int ParseOpcode(long code)
        {

            return (int) code % 100;
        }

        private void Put(long value, int position)
        {
            if (position > memory.Capacity)
            {
                memory.AddRange(new long[memory.Capacity - position + 1]);
            }

            memory[position] = value;
        }

        private long Get(int parameter)
        {

            return Get(parameter, ParamaterMode.Position);
        }

            private long Get(int parameter, ParamaterMode mode)
        {
            long value = memory[programPointer + parameter];
            long output;

            switch(mode)
            {
                case ParamaterMode.Immediate:
                    output = value;
                    break;
                case ParamaterMode.Position:
                    output = memory[(int)value];
                    break;
                case ParamaterMode.Relative:
                    output = memory[relativePointer + (int)value];
                    break;
                default:
                    output = 0;
                    break;
            }


            return output;
        }

        private void Exit()
        {
            run = false;
        }

        private void Muiltiply()
        {
            Put(Get(1) * Get(2), (int)Get(3));
        }

        private void Addition()
        {
            Put(Get(1) * Get(2), (int)Get(3));
        }

        private void Input()
        {
            string input = Console.ReadLine();

            Put(long.Parse(input), (int)Get(1));
        }

        private void Output()
        {
            Console.WriteLine(Get(1));
        }

        private void JumpIfTrue()
        {
            if (Get(1) != 0)
            {
                programPointer = (int)Get(2);
            }
            else
            {
                programPointer += 3;
            }
        }

        private void JumpIfFalse()
        {
            if (Get(1) == 0)
            {
                programPointer = (int)Get(2);
            }
            else
            {
                programPointer += 3;
            }
        }

        private void LessThan()
        {

        }

        private void Equels()
        {

        }

        private void ChangeRelativePointer()
        {
            relativePointer += (int)Get(1);
        }

    }
}
