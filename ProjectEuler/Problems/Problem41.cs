using System;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Problems
{
    public class Problem41 : IProblem
    {
        public int solve()
        {
            for (int i = 9; i > 0; i--)
            {
                string str = "";
                for (int j = i; j > 0; j--)
                {
                    str += j;
                }

                Console.WriteLine(str);

                int n = str.Length;
                permute(str, 0, n - 1);
            }

            return -1;
        }

        bool isPrime(int number)
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

        /** 
        * permutation function 
        * @param str string to  
        * calculate permutation for 
        * @param l starting index 
        * @param r end index 
        */
        private void permute(string str, int l, int r)
        {
            if (l == r)
            {
                // Console.WriteLine($"Nr: {str}"); 

                int.TryParse(str, out int i);
                if (isPrime(i))
                {
                    Console.WriteLine($"Prime: {i}");
                }
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        /** 
        * Swap Characters at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        */
        public string swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        public long Answer(params long[] arguments)
        {
            return solve();
        }
    }
}