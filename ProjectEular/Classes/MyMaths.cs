using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEular.Classes
{
    class MyMaths
    {
        private int[] primelist = new int[2000000];

        public MyMaths()
        {
            primelist = GeneratePrimesSieveOfSundaram(2000000).ToArray();
        }

        public int NumberOfDevisors(int number)
        {
            int devisors = 0;
            double max = Math.Sqrt(number);
            List<int> devisorsList = new List<int>();

            for (int i = 1; i <= max; i++)
            {
                if (number % i == 0)
                {
                    devisorsList.Add(i);
                    devisors++;
                }
            }

            foreach (var dv in devisorsList)
            {
                if (number % dv == 0)
                {
                    devisors++;
                }
            }

            return devisors;
        }

        public int TriangleNumber(int number)
        {
            int triangle = 0;

            for (int i = 0; i < number; i++)
            {
                triangle += i;
            }

            return triangle;
        }

        public int PrimaAtPosition(int position, int max = 0)
        {
            if (primelist[position] != 0)
            {
                return primelist[position];
            }

            int primenr = 1;
            int number = 1;

            while (primenr != position)
            {

                number += 2;
                if (max != 0 && number > max)
                {
                    break;
                }

                if (isPrime(number))
                {
                    primelist[primenr] = number;
                    primenr++;
                }
            }

            return number;
        }

        private bool isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public int ApproximateNthPrime(int nn)
        {
            double n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        public BitArray SieveOfSundaram(int limit)
        {
            limit /= 2;
            BitArray bits = new BitArray(limit + 1, true);
            for (int i = 1; 3 * i + 1 < limit; i++)
            {
                for (int j = 1; i + j + 2 * i * j <= limit; j++)
                {
                    bits[i + j + 2 * i * j] = false;
                }
            }
            return bits;
        }

        public List<int> GeneratePrimesSieveOfSundaram(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfSundaram(limit);
            List<int> primes = new List<int>();
            primes.Add(2);
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(2 * i + 1);
                    found++;
                }
            }
            return primes;
        }

    }
}
