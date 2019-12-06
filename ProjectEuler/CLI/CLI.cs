using ProjectEuler.Interfaces;
using System;

namespace ProjectEuler.CLI
{
    public class Cli
    {
        private enum Commands
        {
            Help,
            H,
            Commands,
            List,
            L,
            Problem,
            P,
            Exit,
            Quit,
            Leave,
            Q
        }

        private Commands _commands;

        private void GetCommands()
        {
            Console.Write("Commands");
        }

        private void ListCommands()
        {
            var values = Enum.GetValues(typeof(Commands));

            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }

        private void ShowProblems()
        {
            for (int i = 1; i < 600; i++)
            {

                Type problem = Type.GetType("ProjectEuler.Problems.Problem" + i, false);

                if (null != problem)
                {
                    Console.WriteLine($"Problem {i}");
                    continue;
                }
            }
        }

        private void RunProblem()
        {
            Console.WriteLine("Which problem number?");
            string num = Console.ReadLine().Trim();

            Type problem = Type.GetType("ProjectEuler.Problems.Problem" + num, false);

            if (null == problem)
            {
                Console.WriteLine("Problem not found");
                return;
            }

            try
            {
                var pi = (IProblem)Activator.CreateInstance(problem);
                Console.WriteLine("The answer is:");
                Console.WriteLine(pi.Answer());
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Answer not implemented yet");
            }
            catch (Exception)
            {
                Console.WriteLine($"Interface not implemented in problem {num}");
            }
        }

        public void ProcessCommand()
        {
            string input = Console.ReadLine();

            _commands = (Commands) Enum.Parse(_commands.GetType(), input);

            switch (_commands)
            {
                // Show help
                case Commands.Help:
                case Commands.H:
                    ListCommands();
                    break;
                // Show all commands
                case Commands.Commands:
                    ListCommands();
                    
                    break;

                // List all problems
                case Commands.List:
                case Commands.L:
                    ShowProblems();
                    break;
                // Execute a problem
                case Commands.Problem:
                case Commands.P:
                    RunProblem();
                    break;
                default:
                    // No valid command found? try to guess otherwise give help commando. 
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}