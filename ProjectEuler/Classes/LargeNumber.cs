using System;
using System.Collections.Generic;

namespace ProjectEuler.Classes
{
    public class LargeNumber
    {
        private Dictionary<int, long> _numbers;
        private const long Cutoff = 1000000000000L;

        public Dictionary<int, long> Numbers
        {
            get => _numbers;
            set => _numbers = value;
        }

        public LargeNumber(long value)
        {
            _numbers = new Dictionary<int, long>();
            if (value > Cutoff)
            {
                _numbers.Add(0, Cutoff);
                _numbers.Add(1, value - Cutoff);
            }

            _numbers.Add(0, value);
        }

        public LargeNumber(Dictionary<int, long> value)
        {
            _numbers = value;
        }

        public LargeNumber(LargeNumber value)
        {
            _numbers = value.Numbers;
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
                long sum = a._numbers[i] + b._numbers[i];
                sum += rest;

                rest = 0;

                if (sum > Cutoff)
                {
                    rest = sum - Cutoff;
                }

                newNumber.Add(i, sum);
            }

            return new LargeNumber(newNumber);
        }
    }
}