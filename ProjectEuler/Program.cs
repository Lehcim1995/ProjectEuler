using System;
using ProjectEuler.CLI;
using ProjectEuler.Interfaces;

namespace ProjectEuler
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cli cli = new Cli();

            Console.WriteLine("This is the Project euler commandline application");
            Console.WriteLine("Type \"Commands\" to see all commands ");

            while (true)
            {
                cli.ProcessCommand();
            }
        }
    }
}
