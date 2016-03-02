using System.Collections;

namespace _01.PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeMain
    {
        private static readonly Dictionary<int, Tree<int>> NodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');

                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);

                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int subTreeSum = int.Parse(Console.ReadLine());

            var rootNode = FindRootNode();
            Console.WriteLine("Root node: {0}", rootNode.Value);

            var leafNodeValues = FindLeafNodes()
                .Select(leaf => leaf.Value)
                .OrderBy(value => value);
            Console.WriteLine("Leaf nodes:");
            Console.WriteLine(string.Join(", ", leafNodeValues));

            var middleNodeValues = FindMiddleNodes()
                .Select(middle => middle.Value)
                .OrderBy(value => value);
            Console.WriteLine("Middle nodes:");
            Console.WriteLine(string.Join(", ", middleNodeValues));

            var longestPath = FindLongestPath(rootNode).ToArray();
            Array.Reverse(longestPath);
            Console.WriteLine("Longest path: ");
            Console.WriteLine("{0} length = {1}", string.Join("->", longestPath.Select(n => n.Value)), longestPath.Count());

            var subtrees = FindSubtreesWithSum(rootNode, subTreeSum);
            Console.WriteLine("Paths of sum {0}:", subTreeSum);
            foreach (var subtree in subtrees)
            {
                var list = new List<int>();
                subtree.Each(list.Add);
                Console.WriteLine(string.Join(" + ", list));
            }
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!NodeByValue.ContainsKey(value))
            {
                NodeByValue[value] = new Tree<int>(value);
            }

            return NodeByValue[value];
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = NodeByValue.Values.FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNode = NodeByValue.Values
                .Where(node => node.Children.Count > 0
                    && node.Parent != null);

            return middleNode;
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = NodeByValue.Values
                .Where(node => node.Children.Count == 0)
                .ToList();
            return leafNodes;
        }

        private static IList<Tree<int>> FindLongestPath(Tree<int> treeNode)
        {
            IList<Tree<int>> longestPath = new List<Tree<int>>();

            foreach (var childNode in treeNode.Children)
            {
                var currentPath = FindLongestPath(childNode);

                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            longestPath.Add(treeNode);
            return longestPath;
        }

        private static int FindTreeSum(Tree<int> node)
        {
            return node.Value + node.Children.Sum(child => FindTreeSum(child));
        }

        private static IEnumerable<Tree<int>> FindSubtreesWithSum(Tree<int> root, int targetSum)
        {
            var results = new List<Tree<int>>();
            var currentSum = FindTreeSum(root);

            if (currentSum == targetSum)
            {
                results.Add(root);
            }

            foreach (var child in root.Children)
            {
                results.AddRange(FindSubtreesWithSum(child, targetSum));
            }

            return results;
        }
    }
}