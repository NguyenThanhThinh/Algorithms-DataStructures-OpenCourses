namespace _06.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PathsBetweenCells
    {
        private static char[,] firstLab =
        {
            {'s', ' ', ' ', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', 'e', ' '},
            {' ', ' ', ' ', ' '}
        };

        private static char[,] secondLab =
         {
            { 's', ' ', ' ', ' ', ' ', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', 'e', ' ', ' ', ' '},
            { ' ', ' ', ' ', '*', ' ', ' '},
         };

        private static List<char> steps = new List<char>();

        private static int countSize = 0;

        private static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        public static void Main()
        {
            FindPathToExit(firstLab, 0, 0, 's');
            PrintTotalPaths();
            countSize = 0;
            Console.WriteLine();
            FindPathToExit(secondLab, 0, 0, 's');
            PrintTotalPaths();

        }

        public static bool InRange(int row, int col, char[,] matrix)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        public static void FindPathToExit(char[,] matrix, int row, int col, char direction)
        {
            if (!InRange(row, col, matrix))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }
            steps.Add(direction);

            // Check if we have found the exit
            if (matrix[row, col] == 'e')
            {
                countSize++;
                PrintPath();
            }


            if (matrix[row, col] == ' ' || matrix[row, col] == 's')
            {
                // Temporary mark the current cell as visited to avoid cycles
                matrix[row, col] = '.';
                // Invoke recursion the explore all possible directions
                FindPathToExit(matrix, row, col - 1, 'L'); // left
                FindPathToExit(matrix, row - 1, col, 'U'); // up
                FindPathToExit(matrix, row, col + 1, 'R'); // right
                FindPathToExit(matrix, row + 1, col, 'D'); // down
                // Mark back the current cell as free
                // Comment the below line to visit each cell at most once
                matrix[row, col] = ' ';
            }
            steps.RemoveAt(steps.Count - 1);

        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join(" ", steps.Skip(1)));
        }

        private static void PrintTotalPaths()
        {
            Console.WriteLine($"Total paths found: {countSize}");
        }
    }
}
