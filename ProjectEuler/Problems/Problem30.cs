using System;
using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem30 : IProblem
    {
        public int solve()
        {
            int sum = 0;

            int result = 0;

            for (int i = 2; i < 355000; i++)
            {
                int sumOfPowers = 0; 
                int number = i; 
                while (number > 0)
                {
                    int digit = number % 10;
                    number /= 10;

                    int temp = digit;
                    for (int j = 1; j < 5; j++)
                    {
                        temp *= digit;
                    }
                    sumOfPowers += temp;
                }

                if (sumOfPowers == i)
                {
                    Console.WriteLine($"Found at {i}");
                    result += i;
                }
            }

            Console.WriteLine($"Other solution = {result}");

            for (int fifth = 1; fifth < 10; fifth++)
            {
                for (int forth = 0; forth < 10; forth++)
                {
                    for (int thirth = 0; thirth < 10; thirth++)
                    {
                        for (int second = 0; second < 10; second++)
                        {
                            for (int first = 0; first < 10; first++)
                            {
                                int numb = (fifth * 10000) + (forth * 1000) + (thirth * 100) + (second * 10) + (first);
                                int num = 0;
                                //Console.WriteLine($"{fifth} {forth} {thirth} {second} {first}");
                                num += (int)Math.Pow(fifth, 5);
                                num += (int)Math.Pow(forth, 5);
                                num += (int)Math.Pow(thirth, 5);
                                num += (int)Math.Pow(second, 5);
                                num += (int)Math.Pow(first, 5);

                                if (num == numb)
                                {
                                    sum += numb;
                                    Console.WriteLine($"{fifth} {forth} {thirth} {second} {first}");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum for 5 = {sum}");
            sum = 0;

            for (int forth = 1; forth < 10; forth++)
            {
                for (int thirth = 0; thirth < 10; thirth++)
                {
                    for (int second = 0; second < 10; second++)
                    {
                        for (int first = 0; first < 10; first++)
                        {
                            int numb = (forth * 1000) + (thirth * 100) + (second * 10) + (first);
                            int num = 0;
                            //Console.WriteLine($"{fifth} {forth} {thirth} {second} {first}");
                            num += (int)Math.Pow(forth, 4);
                            num += (int)Math.Pow(thirth, 4);
                            num += (int)Math.Pow(second, 4);
                            num += (int)Math.Pow(first, 4);

                            if (num == numb)
                            {
                                sum += numb;
                                Console.WriteLine($"{forth} {thirth} {second} {first}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum for 4 = {sum}");

            return sum;
        }

        public long Awnser(params long[] arguments)
        {
            return solve();
        }
    }
}