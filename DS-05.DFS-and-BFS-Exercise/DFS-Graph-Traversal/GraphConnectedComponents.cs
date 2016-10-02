using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static bool[] visited;

    private static new List<int>[] graph = new List<int>[]
                                {
                                    new List<int> { 3, 6 },
                                    new List<int> { 3, 4, 5, 6 },
                                    new List<int> { 8 },
                                    new List<int> { 0, 1, 5 },
                                    new List<int> { 1, 6 },
                                    new List<int> { 1, 3 },
                                    new List<int> { 0, 1, 4 },
                                    new List<int> { },
                                    new List<int> { 2 }
                                };

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    public static void Dfs(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var childNode in graph[node])
            {
                Dfs(childNode);
            }
            Console.Write(" " + node);
        }
    }

    public static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                Dfs(i);
                Console.WriteLine();
            }
        }
    }

    public static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
        }
        return graph;
    } 
}
