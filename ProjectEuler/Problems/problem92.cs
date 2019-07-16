using ProjectEular.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem92 : IProblem
    {
        public int solve()
        {
            int sum = 0;
            for (int i = 2; i < 10000000; i ++)
            {
                if (is89loop(i))
                {
                    sum++;
                    // Console.WriteLine($"Nummer {i} loopt naar 89");
                }
            }

            return sum;
        }

        bool is89loop(int start)
        {
            int next = ditgitSquare(start);
            while (next != 89 && next != 1)
            {
                next = ditgitSquare(next);
            }

            return next == 89;
        }

        int ditgitSquare(int number)
        {
            int sum = 0;

            var val = number;

            while(val > 0)
            {
                var numb = (val % 10);
                sum += numb * numb;
                val = val / 10;
            }

            return sum;
        }


        public long Awnser(params long[] arguments)
        {
            return solve();
        }
    }
}