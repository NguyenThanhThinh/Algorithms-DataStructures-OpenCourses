namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RoundDance
    {
        private static int longestRoundDance;
        private static IDictionary<int, IList<int>> nodes =
            new Dictionary<int, IList<int>>();
        
        private static int leader;

        public static void Main()
        {
            ReadInput();

            // As we know that there will be no loops in the graph, we pass the leader node as current and previous node, to avoid endless recursion when foreaching childs of its childs.
            FindLongestRoundDance(leader, leader); 

            Console.WriteLine(longestRoundDance);
        }

        public static void FindLongestRoundDance(int node, int prevNode, int count = 0)
        {
            count++;

            foreach (var neighbour in nodes[node])
            {
                if (neighbour == prevNode)
                {
                    continue;
                }

                FindLongestRoundDance(neighbour, node, count);
            }

            if (count > longestRoundDance)
            {
                longestRoundDance = count;
            }
        }
        
        private static void ReadInput()
        {
            var edgesCount = int.Parse(Console.ReadLine());
            leader = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                AddNode(edge[0], edge[1]);
                AddNode(edge[1], edge[0]);
            }
        }

        private static void AddNode(int node, int neighbour)
        {
            if (!nodes.ContainsKey(node))
            {
                nodes[node] = new List<int>();
            }

            nodes[node].Add(neighbour);
        }
    }
}