namespace _02.RoundDance.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoundDanceTests
    {
        [TestInitialize]
        public void TestInitialze()
        {
            RoundDance.longestRoundDance = 0;
            RoundDance.nodes = new Dictionary<int, IList<int>>();
        }

        [TestMethod]
        public void FindLongestRoundDance_CustomTest_ShouldFind()
        {
            RoundDance.nodes[0] = new List<int> { 2 };
            RoundDance.nodes[1] = new List<int> { 5, 2 };
            RoundDance.nodes[2] = new List<int> { 0, 1, 3 };
            RoundDance.nodes[3] = new List<int> { 2 };
            RoundDance.nodes[5] = new List<int> { 1, 6, 7 };
            RoundDance.nodes[6] = new List<int> { 5 };
            RoundDance.nodes[7] = new List<int> { 5 };

            RoundDance.FindLongestRoundDance(0, 0);

            // Longest is: 0 -> 2 -> 1 -> 5 -> (6, 7) | Count 5 [testNode.jpg]
            Assert.AreEqual(5, RoundDance.longestRoundDance);
        }

        [TestMethod]
        public void FindLongestRoundDance_ZeroTest1_ShouldFind()
        {
            RoundDance.nodes[1] = new List<int> { 2, 3, 7 };
            RoundDance.nodes[2] = new List<int> { 1 };
            RoundDance.nodes[3] = new List<int> { 1 };
            RoundDance.nodes[7] = new List<int> { 1, 8 };
            RoundDance.nodes[8] = new List<int> { 7, 11 };
            RoundDance.nodes[11] = new List<int> { 8 };

            RoundDance.FindLongestRoundDance(1, 1);

            Assert.AreEqual(4, RoundDance.longestRoundDance);
        }

        [TestMethod]
        public void FindLongestRoundDance_ZeroTest2_ShouldFind()
        {
            RoundDance.nodes[1] = new List<int> { 2, 3, 7 };
            RoundDance.nodes[2] = new List<int> { 1 };
            RoundDance.nodes[3] = new List<int> { 1 };
            RoundDance.nodes[7] = new List<int> { 1, 8 };
            RoundDance.nodes[8] = new List<int> { 7, 11 };
            RoundDance.nodes[11] = new List<int> { 8 };

            RoundDance.FindLongestRoundDance(7, 7);

            Assert.AreEqual(3, RoundDance.longestRoundDance);
        }

        [TestMethod]
        public void FindLongestRoundDance_ZeroTest3_ShouldFind()
        {
            RoundDance.nodes[-1] = new List<int> { -5, 4, 2, 7, 8, 9 };
            RoundDance.nodes[-5] = new List<int> { -1 };
            RoundDance.nodes[4] = new List<int> { -1 };
            RoundDance.nodes[7] = new List<int> { -1 };
            RoundDance.nodes[9] = new List<int> { -1 };
            RoundDance.nodes[2] = new List<int> { -1 };
            RoundDance.nodes[8] = new List<int> { -1, 11 };
            RoundDance.nodes[11] = new List<int> { 8 };

            RoundDance.FindLongestRoundDance(-1, -1);

            Assert.AreEqual(3, RoundDance.longestRoundDance);
        }
    }
}
