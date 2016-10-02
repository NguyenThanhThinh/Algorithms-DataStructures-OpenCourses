using System;
using System.Linq;
using System.Text;

namespace _01.Parenthesis
{
    class Program
    {
        static StringBuilder result = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Brackets("", 0, 0, n);
            Console.Write(result);
        }

        private static void Brackets(string output, int open, int close, int pairs)
        {
            if ((open == pairs) && (close == pairs))
            {
                result.AppendLine(output);
            }
            else
            {
                if (open < pairs)
                    Brackets(output + "(", open + 1, close, pairs);
                if (close < open)
                {
                    Brackets(output + ")", open, close + 1, pairs);
                }
            }
        }
    }
}
