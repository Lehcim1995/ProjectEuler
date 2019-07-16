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
            P
        }

        private Commands commands;

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


        public void ProcessCommand()
        {
            string input = Console.ReadLine();

            commands = (Commands) Enum.Parse(commands.GetType(), input);

            switch (commands)
            {
                // Show help
                case Commands.Help:
                case Commands.H:

                    break;
                // Show all commands
                case Commands.Commands:
                    GetCommands();
                    break;

                // List all problems
                case Commands.List:
                case Commands.L:
                    ListCommands();
                    break;
                // Execute a problem
                case Commands.Problem:
                case Commands.P:


                    break;
                default:
                    // No valid command found? try to guess otherwise give help commando. 
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}