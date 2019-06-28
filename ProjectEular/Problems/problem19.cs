using System;

public class problem19
{
    public int solve()
    {
        DateTime d = new DateTime(1901, 1, 1);
        DateTime stop = new DateTime(2000, 12, 31);
        int sum = 0;

        while (d < stop)
        {
            Console.WriteLine(d);
            Console.WriteLine(d.DayOfWeek);
            if (d.DayOfWeek == DayOfWeek.Sunday)
            {
                sum += 1;
            }
            d = d.AddMonths(1);
            
        }

        return sum;   
    }
}