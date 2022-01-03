// See https://aka.ms/new-console-template for more information

using adventofcode2021;

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

    Type problem = Type.GetType("adventofcode2021.days.Day" + num, false);

    if (null == problem)
    {
        Console.WriteLine("Day not found");
        continue;
    }

    try
    {
        var pi = (IProblem)Activator.CreateInstance(problem);
        Console.WriteLine("The answer is:");
        Console.WriteLine(pi!.Answer());
        Console.WriteLine("The second answer is:");
        Console.WriteLine(pi!.Answer2());
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