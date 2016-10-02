using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ConnectedAreasInMatrix
{
    public class Area
    {
        public int TopLeftXCoor { get; set; }

        public int TopLeftYCoor { get; set; }

        public int Size { get; set; }
    }

    public class ConnectedAreas
    {
        private static IList<Area> areas = new List<Area>();
        private static int tempSize = 0;

        private static string[,] matrix =
        {
            {" ", " ", " ", "*", " ", " ", " ", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", "*", " "},
            {" ", " ", " ", " ", "*", " ", "*", " ", " "},
        };

        //private static string[,] matrix = 
        //{
        //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
        //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
        //    {"*", " ", " ", "*", "*", "*", "*", "*", " ", " "},
        //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
        //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
        //};

        static void Main()
        {
            int x = 0;
            int y = 0;

            FindNextAreaTopLeftCoorinates(out x, out y);

            while (x != -1)
            {
                Area currentArea = new Area() { TopLeftXCoor = x, TopLeftYCoor = y };

                tempSize = 0;
                TraverseMatrix(x, y);

                currentArea.Size = tempSize;
                areas.Add(currentArea);

                FindNextAreaTopLeftCoorinates(out x, out y);
            }

            Console.WriteLine("Total areas found: " + areas.Count);
            var sortedAreas = areas.OrderByDescending(a => a.Size)
                .ThenBy(a => a.TopLeftXCoor)
                .ThenBy(a => a.TopLeftYCoor);

            int iter = 1;

            foreach (var area in sortedAreas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", iter, area.TopLeftXCoor, area.TopLeftYCoor, area.Size);
                iter++;
            }
        }

        public static void TraverseMatrix(int row, int col)
        {
            bool legitMovement = row < matrix.GetLength(0) &&
                                    row >= 0 &&
                                    col < matrix.GetLength(1) &&
                                    col >= 0;

            if (!legitMovement)
            {
                return;
            }

            if (matrix[row, col] == "*" || matrix[row, col] == "V")
            {
                return;
            }

            matrix[row, col] = "V";
            tempSize++;

            TraverseMatrix(row + 1, col);
            TraverseMatrix(row, col + 1);
            TraverseMatrix(row - 1, col);
            TraverseMatrix(row, col - 1);
        }

        public static void FindNextAreaTopLeftCoorinates(out int x, out int y)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == " ")
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }

            x = -1;
            y = -1;
        }
    }
}
