namespace _02.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var hashTable = new HashTable<char, int>();
            var input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (!hashTable.ContainsKey(ch))
                {
                    hashTable[ch] = 0;
                }

                hashTable[ch]++;
            }

            var sorted = hashTable.OrderBy(k => k.Key);

            foreach (var ch in sorted)
            {
                Console.WriteLine("{0}: {1} time/s", ch.Key, ch.Value);
            }
        }
    }
}
