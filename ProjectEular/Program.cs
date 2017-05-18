using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectEular.Interfaces;
using ProjectEular.Problems;

namespace ProjectEular
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Which problem number?");
                string num = Console.ReadLine().Trim();

                switch (num?.ToLower()) //for quiting
                {
                    case "q":
                    case "quit":
                    case "exit":
                        return;
                }

                Type problem = Type.GetType("ProjectEular.Problems.Problem" + num, false);

                if (null == problem)
                {
                    Console.WriteLine("Problem not found");
                    continue;
                }

                try
                {
                    var pi = (IProblem) Activator.CreateInstance(problem);
                    Console.WriteLine("The awnser is:");
                    Console.WriteLine(pi.Awnser());
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Awnser not implemented yet");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Interface not implemented in problem {num}");
                }
            }
        }
    }
}
