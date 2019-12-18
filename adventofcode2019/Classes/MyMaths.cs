using System;
using System.Collections;
using System.Collections.Generic;

namespace adventofcode2019.Classes
{
    public class MyMaths
    {
        private readonly int[] _primeList;

        public MyMaths()
        {
            _primeList = GeneratePrimesSieveOfSundaram(2000000).ToArray();
        }

        public List<int> Devisors(int number)
        {

            double max = Math.Sqrt(number);
            List<int> devisorsList = new List<int>();

            for (int i = 1; i <= max; i++)
            {
                if (number % i == 0)
                {
                    devisorsList.Add(i);
                }
            }

            return devisorsList;
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
            if (_primeList[position] != 0)
            {
                return _primeList[position];
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
                    _primeList[primenr] = number;
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

        /// <summary>
        /// Returns factorio til n 9
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FastFactorio(int n)
        {
            switch (n)
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

        /** 
        * permutation function 
        * @param str string to  
        * calculate permutation for 
        * @param l starting index 
        * @param r end index 
        */
        public void Permute(string str, int l, int r)
        {
            if (l == r)
            {
                // Done?
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        /** 
       * permutation function 
       * @param str string to  
       * calculate permutation for 
       * @param l starting index 
       * @param r end index 
       */
        public void Permute(int[] arr, int l, int r)
        {
            if (l == r)
            {
                // Done?
                Console.WriteLine(arr);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    arr = Swap(arr, l, i);
                    Permute(arr, l + 1, r);
                    arr = Swap(arr, l, i);
                }
            }
        }

        /** 
        * Swap array value at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        */
        public int[] Swap(int[] a, int i, int j)
        {
            int temp;
            temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            return a;
        }

        /** 
        * Swap Characters at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        */
        public string Swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        public static IList<T[]> GeneratePermutations<T>(T[] objs, long? limit)
        {
            var result = new List<T[]>();
            long n = Factorial(objs.Length);
            n = (!limit.HasValue || limit.Value > n) ? n : (limit.Value);

            for (long k = 0; k < n; k++)
            {
                T[] kperm = GenerateKthPermutation<T>(k, objs);
                result.Add(kperm);
            }

            return result;
        }

        public static T[] GenerateKthPermutation<T>(long k, T[] objs)
        {
            T[] permutedObjs = new T[objs.Length];

            for (int i = 0; i < objs.Length; i++)
            {
                permutedObjs[i] = objs[i];
            }
            for (int j = 2; j < objs.Length + 1; j++)
            {
                k = k / (j - 1);                      // integer division cuts off the remainder
                long i1 = (k % j);
                long i2 = j - 1;
                if (i1 != i2)
                {
                    T tmpObj1 = permutedObjs[i1];
                    T tmpObj2 = permutedObjs[i2];
                    permutedObjs[i1] = tmpObj2;
                    permutedObjs[i2] = tmpObj1;
                }
            }
            return permutedObjs;
        }

        public static long Factorial(int n)
        {
            if (n < 0) { throw new Exception("Unaccepted input for factorial"); }    //error result - undefined
            if (n > 256) { throw new Exception("Input too big for factorial"); }  //error result - input is too big

            if (n == 0) { return 1; }

            // Calculate the factorial iteratively rather than recursively:

            long tempResult = 1;
            for (int i = 1; i <= n; i++)
            {
                tempResult *= i;
            }
            return tempResult;
        }
    }
}
