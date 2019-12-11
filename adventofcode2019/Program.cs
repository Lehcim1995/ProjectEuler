using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.BufferHeight = Int16.MaxValue - 1;

            while (true)
			{
				//cli.ProcessCommand();

				Console.WriteLine("Which Day number?");
				string num = Console.ReadLine().Trim();


				switch (num.ToLower()) //for quiting
				{
					case "q":
					case "quit":
					case "exit":
						return;
				}

				Type problem = Type.GetType("adventofcode2019.Days.Day" + num, false);

				if (null == problem)
				{
					Console.WriteLine("Day not found");
					continue;
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
				catch (MissingMemberException e)
				{
					Console.WriteLine($"Interface not implemented in problem {num} Exception : {e.Message}");
				}
			}
		}
	}
}
