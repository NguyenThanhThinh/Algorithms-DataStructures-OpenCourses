using System;
using System.Collections.Generic;

class LongestIncreasingSubsequence
{
	const int NO_PREVIOUS = -1;

	static void Main()
	{
		int[] seq = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };
		int[] len = new int[seq.Length];
		int[] prev = new int[seq.Length];

		int bestIndex = CalculateLongestIncreasingSubsequence(seq, len, prev);

		Console.WriteLine("sequence[]  = " + string.Join(", ", seq));
		Console.WriteLine("lenght[]  = " + string.Join(", ", len));
		Console.WriteLine("previouses[] = " + string.Join(", ", prev));

		PrintLongestIncreasingSubsequence(seq, prev, bestIndex);
	}

	private static int CalculateLongestIncreasingSubsequence(
        int[] sequence, int[] lenght, int[] previouses)
	{
        int longestLength = 0;
		int bestIndex = 0;
		for (int currentNumber = 0; currentNumber < sequence.Length; currentNumber++)
		{
			lenght[currentNumber] = 1;
            previouses[currentNumber] = NO_PREVIOUS;
			for (int numberBeforeCurrent = 0; numberBeforeCurrent <= currentNumber - 1; numberBeforeCurrent++)
			{
				if (sequence[numberBeforeCurrent] < sequence[currentNumber] && 1 + lenght[numberBeforeCurrent] > lenght[currentNumber])
				{
					lenght[currentNumber] = 1 + lenght[numberBeforeCurrent];
					previouses[currentNumber] = numberBeforeCurrent;
					if (lenght[currentNumber] > longestLength)
					{
						longestLength = lenght[currentNumber];
						bestIndex = currentNumber;
					}
				}
			}
		}
		return bestIndex;
	}

	static void PrintLongestIncreasingSubsequence(int[] seq, int[] prev, int index)
	{
		List<int> lis = new List<int>();
		while (index != NO_PREVIOUS)
		{
			lis.Add(seq[index]);
			index = prev[index];
		}
		lis.Reverse();
		Console.WriteLine("subsequence = [{0}]", string.Join(", ", lis));
	}
}
