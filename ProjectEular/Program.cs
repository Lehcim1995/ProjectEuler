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
                string num = Console.ReadLine();

                Type problem = Type.GetType("ProjectEular.Problems.Problem" + num, false);

                if (null == problem)
                {
                    Console.WriteLine("Problem not found");
                    continue;
                }

                IProblem pi;
                try
                {
                    pi = (IProblem)Activator.CreateInstance(problem);
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem not found");
                    continue;
                }
                
                Console.WriteLine("The awnser is:");
                Console.WriteLine(pi.Awnser());
            }

        }
    }
}
