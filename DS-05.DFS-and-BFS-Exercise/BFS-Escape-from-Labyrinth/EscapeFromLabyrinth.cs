using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private const string VisitedCell = "s";

    private static int width = 9;

    private static int height = 7;

    private static string[,] labyrinth =
        {
        };

    public static void Main()
    {
        ReadLab();
        string shortestPath = FindShortestPathToExit();
        if (shortestPath == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPath == string.Empty)
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPath);
        }
    }

    public static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPos = FindStartPos();
        if (startPos == null)
        {
            return null;
        }
        queue.Enqueue(startPos);
        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }
            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", +1, 0);
            TryDirection(queue, currentCell, "L", -1, 0);
            TryDirection(queue, currentCell, "D", 0, +1);
        }

        return null;
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;
        if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newX, newY] == "_")
        {
            labyrinth[newY, newX] = VisitedCell;
            var nextCell = new Point() { X = newX, Y = newY, Direction = direction, PrevPoint = currentCell };
            queue.Enqueue(nextCell);
        }
    }

    private static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PrevPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PrevPoint;
        }
        var pathReversed = new StringBuilder(path.Length);
        for (int i = path.Length - 1; i >= 0; i--)
        {
            pathReversed.Append(path[i]);
        }
        return pathReversed.ToString();
    }

    private static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;
        return isOnBorderY || isOnBorderX;
    }

    private static Point FindStartPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labyrinth[y, x] == VisitedCell)
                {
                    return new Point { X = x, Y = y };
                }
            }
        }
        return null;
    }

    private static void ReadLab()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new string[height,width];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                labyrinth[row, col] = Console.ReadLine();
            }
        }
    }
}
