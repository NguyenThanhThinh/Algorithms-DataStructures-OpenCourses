namespace _03.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public static class RideTheHorse
    {
        private const int StartValue = 1;

        private static int[,] matrix;
        private static Queue<Knight> possibleMoves; 

        public static void Main()
        {
            var matrixHeight = int.Parse(Console.ReadLine());
            var matrixWidth = int.Parse(Console.ReadLine());
            var horseStartRow = int.Parse(Console.ReadLine());
            var horseStartCol = int.Parse(Console.ReadLine());

            matrix = new int[matrixHeight, matrixWidth];
            possibleMoves = new Queue<Knight>();

            var horse = new Knight(horseStartRow, horseStartCol, StartValue);
            possibleMoves.Enqueue(horse);
            MakeMove();

            var colToPrint = matrixWidth / 2;
            for (int row = 0; row < matrixHeight; row++)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    if (col == colToPrint)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }

                Console.WriteLine();
            }
        }

        private static void MakeMove()
        {
            while (possibleMoves.Count > 0)
            {
                var horse = possibleMoves.Dequeue();
                matrix[horse.X, horse.Y] = horse.Value;

                TryMove(horse, -2, 1);
                TryMove(horse, -1, 2);
                TryMove(horse, 1, 2);
                TryMove(horse, 2, 1);
                TryMove(horse, 2, -1);
                TryMove(horse, 1, -2);
                TryMove(horse, -1, -2);
                TryMove(horse, -2, -1);
            }
        }

        private static void TryMove(Knight knight, int deltaX, int deltaY)
        {
            var newX = knight.X + deltaX;
            var newY = knight.Y + deltaY;

            var isInsideTheMatrix = newX >= 0 && newX < matrix.GetLength(0) &&
                                    newY >= 0 && newY < matrix.GetLength(1);

            if (isInsideTheMatrix)
            {
                var isFreeCell = matrix[newX, newY] == 0;
                if (isFreeCell)
                {
                    possibleMoves.Enqueue(new Knight(newX, newY, knight.Value + 1));
                }
            }
        }
    }
}
