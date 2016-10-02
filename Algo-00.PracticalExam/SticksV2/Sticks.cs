using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SticksV2
{
    class Sticks
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            List<List<int>> graph = new List<List<int>>();

            for (int j = 0; j < n; j++)
            {
                graph.Add(new List<int>());
                                         }

            for (int i = 0; i < p; i++)
            {
                int[] connections = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int dependOn = connections[0];
                int connection = connections[1];
                graph[dependOn].Add(connection); 
            }

            // Calculate the predecessorsCount
            var predecessorsCount = new int[graph.Count];
            for (int node = 0; node < graph.Count; node++)
            {
                foreach (var childNode in graph[node])
                {
                    predecessorsCount[childNode]++;
                }
            }

            // Topological sorting: source removal algorithm
            var isRemoved = new bool[graph.Count];
            var removedNodes = new List<int>();
            bool nodeRemoved = true;
            while (nodeRemoved)
            {
                nodeRemoved = false;
                for (int node = graph.Count-1; node >= 0; node--)
                {
                    if (predecessorsCount[node] == 0 && !isRemoved[node])
                    {
                        // Found a node with 0 predecessors -> remove it from the graph
                        foreach (var childNode in graph[node])
                        {
                            predecessorsCount[childNode]--;
                        }
                        isRemoved[node] = true;
                        removedNodes.Add(node);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (removedNodes.Count == graph.Count)
            {
                Console.WriteLine(string.Join(" ", removedNodes));
            }
            else
            {
                Console.WriteLine("Cannot lift all sticks");
                Console.WriteLine(string.Join(" ", removedNodes));
            }
        }
    }
}
