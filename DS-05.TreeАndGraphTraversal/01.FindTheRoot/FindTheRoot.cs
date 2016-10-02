namespace _01.FindTheRoot
{
    using System;
    using System.Collections.Generic;

    public static class FindTheRoot
    {
        public static void Main()
        {
            var nodesCound = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            var hasRoot = new bool[nodesCound];
            for (int i = 0; i < edgesCount; i++)
            {
                var childNode = int.Parse(Console.ReadLine().Split()[1]);
                hasRoot[childNode] = true;
            }

            var nodesWithoutRoot = new List<int>();
            for (int node = 0; node < nodesCound; node++)
            {
                if (!hasRoot[node])
                {
                    nodesWithoutRoot.Add(node);
                }
            }

            switch (nodesWithoutRoot.Count)
            {
                case 0:
                    Console.WriteLine("No root!");
                    break;
                case 1:
                    Console.WriteLine(nodesWithoutRoot[0]);
                    break;
                default:
                    Console.WriteLine($"Multiple root nodes! [{string.Join(", ", nodesWithoutRoot)}],");
                    break;
            }
        }
    }
}
