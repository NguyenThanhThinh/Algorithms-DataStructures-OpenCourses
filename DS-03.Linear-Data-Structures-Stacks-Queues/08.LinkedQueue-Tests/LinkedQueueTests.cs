namespace _08.LinkedQueue_Tests
{
    using System;

    using _07.LinkedQueue;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void EnqueDequeue_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();
            var element = 20;

            Assert.AreEqual(0, linkedQueue.Count);
            linkedQueue.Enqueue(element);
            Assert.AreEqual(1, linkedQueue.Count);
            var popElement = linkedQueue.Dequeue();
            Assert.AreEqual(element, popElement);
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        public void EnqueDequeue_1000Elements_ShouldWorkCorrectly()
        {
            var linkedQueue = new LinkedQueue<string>();
            Assert.AreEqual(0, linkedQueue.Count);

            for (int i = 0; i < 1000; i++)
            {
                linkedQueue.Enqueue(i.ToString());
                Assert.AreEqual(i + 1, linkedQueue.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                var currentElement = linkedQueue.Dequeue();
                Assert.AreEqual(i.ToString(), currentElement);
                Assert.AreEqual(1000 - 1 - i, linkedQueue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldThrow()
        {
            var linkedQueue = new LinkedQueue<DateTime>();

            linkedQueue.Dequeue();
        }

        [TestMethod]
        public void ToArray_ShouldReturnCorrectArray()
        {
            var arr = new[] { 7, -2, 5, 3 };

            var linkedQueue = new LinkedQueue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                linkedQueue.Enqueue(arr[i]);
            }

            var convertedStack = linkedQueue.ToArray();
            CollectionAssert.AreEqual(arr, convertedStack);
        }

        [TestMethod]
        public void ToArray_EmptyEnque_ShouldReturnEmptyArray()
        {
            var initialArr = new DateTime[0];

            var linkedQueue = new LinkedQueue<DateTime>();

            var convertedStack = linkedQueue.ToArray();
            CollectionAssert.AreEqual(initialArr, convertedStack);
        }
    }
}
