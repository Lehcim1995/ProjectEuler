using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEular.Classes
{
    class LargeNumber
    {
        private Dictionary<int, long> numbers;
        private const long cutoff = 1000000000000L;

        public Dictionary<int, long> Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public LargeNumber(long value)
        {
            numbers = new Dictionary<int, long>();
            if (value > cutoff)
            {
                numbers.Add(0, cutoff);
                numbers.Add(1, value);
            }

            numbers.Add(0, value);
        }

        public LargeNumber(Dictionary<int, long> value)
        {
            numbers = value;
        }

        public LargeNumber(LargeNumber value)
        {
            numbers = value.Numbers;
        }

        public static LargeNumber operator +(LargeNumber a, LargeNumber b)
        {
            int keysA = a.Numbers.Count;
            int keysB = a.Numbers.Count;

            Dictionary<int, long> newNumber = new Dictionary<int, long>();

            int loop = Math.Max(keysA, keysB);
            long rest = 0;

            for (int i = 0; i < loop; i++)
            {
                long sum = a.numbers[i] + b.numbers[i];
                sum += rest;

                rest = 0;

                if (sum > cutoff)
                {
                    rest = sum - cutoff;
                }

                newNumber.Add(i, sum);
            }

            return new LargeNumber(newNumber);
        }
    }
}