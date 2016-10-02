using System;

namespace _02._8QueensPuzzle
{
    using System.Collections.Generic;

    public class EightQueenPuzzle
    {
        public const int Size = 8;

        private static int solutionsFound = 0;

        private static bool[,] chessboard = new bool[Size, Size];
        private static HashSet<int> attackedColumns = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);
            Console.WriteLine(solutionsFound);
        }

        public static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutionsFound++;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedColumns.Remove(col);
            attackedRightDiagonals.Remove(row + col);
            attackedLeftDiagonals.Remove(col - row);
            chessboard[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedColumns.Add(col);
            attackedRightDiagonals.Add(row + col);
            attackedLeftDiagonals.Add(col - row);
            chessboard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionsOccupied =
                attackedColumns.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(row + col);
            return !positionsOccupied;
        }
    }
}
