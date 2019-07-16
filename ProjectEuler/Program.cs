using System;
using ProjectEular.Interfaces;
using ProjectEuler.CLI;

namespace ProjectEuler
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cli cli = new Cli();;

            while (true)
            {
                cli.ProcessCommand();

                Console.WriteLine("Which problem number?");
                string num = Console.ReadLine().Trim();


                switch (num.ToLower()) //for quiting
                {
                    case "q":
                    case "quit":
                    case "exit":
                        return;
                }

                Type problem = Type.GetType("ProjectEuler.Problems.Problem" + num, false);

                if (null == problem)
                {
                    Console.WriteLine("Problem not found");
                    continue;
                }

                try
                {
                    var pi = (IProblem) Activator.CreateInstance(problem);
                    Console.WriteLine("The answer is:");
                    Console.WriteLine(pi.Awnser());
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
        }
    }
}
