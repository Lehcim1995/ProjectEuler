using System;
using System.Numerics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public class problem145
{
    private List<int> reversible = new List<int>();
    private List<int> reversibleKey = new List<int>();

    public int solve()
    {

        Thread thread1 = new Thread(new ThreadStart(this.thread1));  
        thread1.Start();  

        Thread thread2 = new Thread(new ThreadStart(this.thread2));  
        thread2.Start();  

        Thread thread3 = new Thread(new ThreadStart(this.thread3));  
        thread3.Start();  

        Thread thread4 = new Thread(new ThreadStart(this.thread4));  
        thread4.Start();  

        Thread thread5 = new Thread(new ThreadStart(this.thread5));  
        thread5.Start(); 

        return 0;
    }


    public int solve(int start, int end)
    {
        var sum = 0;

        //for(int i = 0; i < 1e9; i++)
        // for (int e = 2; e < 10; e++ )
        // {

        Console.WriteLine($"{start} -> {end}");

        for(int i = start; i < end; i++)
        {
            if (endNotZero(i))
            {
                var r = reverse(i);
                var s = r + i;

                if (oddItem(s) == s.ToString().Length )
                {
                    //Console.WriteLine($"{i} + {r} = {s}; is Reverse nr {sum}");
                    sum++;
                }
            }
            // }
        }

        return sum;
    }

    private bool endNotZero(int number) 
    {

        return number % 10 != 0;
    }

    private int oddItem(int number)
    {
        var val = number;
        var result = 0;

        while(val > 0)
        {
            if (val%10!=0)
            {
                if ((val % 10) % 2 != 0)
                {
                    result++;
                }
            }

            val = val / 10;
        }

        return result;
    }

    private int evenItem(int number)
    {
        var val = number;
        var result = 0;

        while(val > 0)
        {
            if (val%10!=0)
            {
                if ((val % 10) % 2 == 0)
                {
                    result++;
                }
            }

            val = val / 10;
        }

        return result;
    }

    private int reverse(int number)
    {
        string num = number.ToString();

        char[] arr = num.ToCharArray();
        Array.Reverse(arr);
        num = new string(arr);

        int newNumber = int.Parse(num);

        return newNumber;
    }

    public void thread1() {
        var problem = new problem145();
        
        Console.WriteLine("start 1");
        Console.WriteLine(problem.solve(0, (int)2e8));
        Console.WriteLine("Done 1");
    }

    public void thread2() {
        var problem = new problem145();
        
        Console.WriteLine("start 2");
        Console.WriteLine(problem.solve((int)2e8, (int)4e8));
        Console.WriteLine("Done 2");
    }

    public void thread3() {
        var problem = new problem145();
        
        Console.WriteLine("start 3");
        Console.WriteLine(problem.solve((int)4e8, (int)6e8));
        Console.WriteLine("Done 3");
    }

    public void thread4() {
        var problem = new problem145();
        
        Console.WriteLine("start 4");
        Console.WriteLine(problem.solve((int)6e8, (int)8e8));
        Console.WriteLine("Done 4");
    }

    public void thread5() {
        var problem = new problem145();
        
        Console.WriteLine("start 5");
        Console.WriteLine(problem.solve((int)8e8, (int)1e9));
        Console.WriteLine("Done 5");
    }

}