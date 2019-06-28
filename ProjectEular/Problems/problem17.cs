using System;
using System.Collections.Generic;

public class problem17 {

    Dictionary<int, string> singles = new Dictionary<int, string>();
    Dictionary<int, string> specials = new Dictionary<int, string>();

    Dictionary<int, string> tens = new Dictionary<int, string>();


    public problem17()
    {
        singles.Add(1, "one");
        singles.Add(2, "two");
        singles.Add(3, "three");
        singles.Add(4, "four");
        singles.Add(5, "five");
        singles.Add(6, "six");
        singles.Add(7, "seven");
        singles.Add(8, "eight");
        singles.Add(9, "nine");

        tens.Add(10, "ten");
        tens.Add(20, "twenty");
        tens.Add(30, "thirty");
        tens.Add(40, "forty");
        tens.Add(50, "fifty");
        tens.Add(60, "sixty");
        tens.Add(70, "seventy");
        tens.Add(80, "eighty");
        tens.Add(90, "ninety");

        specials.Add(11, "eleven");
        specials.Add(12, "twelve");
        specials.Add(13, "thirteen");
        specials.Add(14, "fourteen");
        specials.Add(15, "fifteen");
        specials.Add(16, "sixteen");
        specials.Add(17, "seventeen");
        specials.Add(18, "eighteen");
        specials.Add(19, "nineteen");
    }

    public int solve()
    {
        int sum = 0;

        for(int i = 1; i <= 1000; i++)
        {
            var s = numToString(i);
            Console.WriteLine($"{i} = {s}");

            s = s.Trim();
            s = s.Replace(" ", "");
            s = s.Replace("-", "");

            //Console.WriteLine($"{i} = {s}");

            sum += s.Length;
        }

        return sum;
    }

    public string numToString(int nummer)
    {
        const string hundreds = "hundred";

        if (nummer > 1000)
        {
            return "";
        }

        if (nummer == 1000)
        {
            return "one thousand";
        }

        if (singles.ContainsKey(nummer))
        {
            return singles[nummer];
        }

        if (tens.ContainsKey(nummer))
        {
            return tens[nummer];
        }

        if (specials.ContainsKey(nummer))
        {
            return specials[nummer];
        }

        string snum = "";

        int honderd = nummer / 100;
        string tenPrefix = "";
        string singlePrefix = "";

        //Console.WriteLine($" honderd = {honderd} ");
        if (honderd != 0)
        {
            snum += singles[honderd] + " " + hundreds;
            tenPrefix = " and ";
            singlePrefix = " and ";
        }

        int tienen = ((nummer / 10) * 10) % 100;
        int special = nummer % 100;
        
        //Console.WriteLine($" tienden = {tienen} ");
        //Console.WriteLine($" special = {special} ");
        if (special > 10 && special < 20 )
        {
            snum += tenPrefix + specials[special];
            singlePrefix = "-";           
        }
        else if (tienen > 0)
        {
            snum += tenPrefix + tens[tienen];
            singlePrefix = "-";
        }

        int eenen = nummer % 10;
        //Console.WriteLine($" eenen = {eenen} ");
        if (eenen != 0 && !(special > 10 && special < 20 ))
        {
            snum += singlePrefix + singles[eenen];
        }

        return snum;
    }
}