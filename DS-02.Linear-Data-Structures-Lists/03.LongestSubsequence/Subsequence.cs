namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Subsequence
    {
        public static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            int longestLength = 1;
            int currentLength = 1;
            int longestNum = elements[0];
            int currentNum = elements[0];

            for (int element = 0; element < elements.Count - 1; element++)
            {
                if (currentNum == elements[element + 1])
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                    currentNum = elements[element + 1];
                }

                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestNum = currentNum;
                }
            }

            for (int i = 0; i < longestLength; i++)
            {
                Console.Write(longestNum + " ");
            }

            Console.WriteLine();
        }
    }
}
