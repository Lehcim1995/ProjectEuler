using System;
using System.Collections.Generic;

public class problem74
{
    public int solve()
    {

        int max = 0;

        for (int i = 2; i < 100000000; i++)
        {
            int solve = start(i);

            if (solve == 60)
            {
                max ++;
                Console.WriteLine($"Found  at:{i} nr:{max}");
            }

            
        }

        return max;
    }

    public int start(int start)
    {
        List<int> numbers = new List<int>();
        numbers.Add(start);
        int num = start;

        while (true)
        {
            num = next(num);

            if (numbers.Contains(num) || numbers.Count > 60)
            {
                break;
            }

            numbers.Add(num);
        }

        return numbers.Count;
    }

    public int next(int i)
    {
        int sum = 0;
        int num = i;
        while(num > 0)
        {
            sum += factorio(num % 10);
            num = num / 10;
        }

        return sum;
    }

    public int factorio(int i)
    {
        switch (i)
        {
            case 0:
                return 1;
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 6;
            case 4:
                return 24;
            case 5:
                return 120;
            case 6:
                return 720;
            case 7:
                return 5040;
            case 8:
                return 40320;
            case 9:
                return 362880;
            default:
                return 0;
        }
    }
}