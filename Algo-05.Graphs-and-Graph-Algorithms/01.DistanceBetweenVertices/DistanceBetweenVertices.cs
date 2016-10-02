namespace _01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;

    public static class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph;

        public static void Main()
        {
            graph = new Dictionary<int, List<int>>
            {
                { 11, new List<int> { 4 } },
                { 4, new List<int> { 12, 1 } },
                { 1, new List<int> { 12, 21, 7 } },
                { 7, new List<int> { 21 } },
                { 12, new List<int> { 4, 19 } },
                { 19, new List<int> {1, 21} },
                { 21, new List<int> { 14, 31} },
                { 14, new List<int> {14} },
                { 31, new List<int>() }
            };

            var distancesToFind = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(11, 7),
                new Tuple<int, int>(11, 21),
                new Tuple<int, int>(21, 4),
                new Tuple<int, int>(19, 14),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(1, 11),
                new Tuple<int, int>(31, 21),
                new Tuple<int, int>(11, 14),
            };

            foreach (var verticesPair in distancesToFind)
            {
                var shortestDistance = FindShortestDistance(verticesPair.Item1, verticesPair.Item2);
                Console.WriteLine($"{{{verticesPair.Item1}, {verticesPair.Item2}}} -> {shortestDistance}");
            }
        }

        private static int FindShortestDistance(int startVertex, int endVertex)
        {
            var visited = new HashSet<int>();

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(startVertex, 0));

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                visited.Add(currentNode.Item1);

                if (currentNode.Item1 == endVertex)
                {
                    return currentNode.Item2;
                }

                foreach (var child in graph[currentNode.Item1])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(new Tuple<int, int>(child, currentNode.Item2 + 1));
                    }
                }
            }

            return -1;
        }
    }
}
