using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06.LinkedStack_Tests
{
    using _05.LinkedStack;

    [TestClass]
    public class LinkedStackTests
    {
        public LinkedStack<int> LinkedStack;
        [TestInitialize]
        public void Initialize()
        {
            this.LinkedStack = new LinkedStack<int>();
        }
        [TestMethod]
        public void PushPop_ShouldWork()
        {
            var element = 5;

            Assert.AreEqual(0, this.LinkedStack.Count);
            this.LinkedStack.Push(element);
            Assert.AreEqual(1, this.LinkedStack.Count);
            var popedElement = this.LinkedStack.Pop();
            Assert.AreEqual(popedElement, element);
            Assert.AreEqual(0, this.LinkedStack.Count);
        }

        [TestMethod]
        public void PushPop_1000Elements_ShouldWork()
        {
            Assert.AreEqual(0, this.LinkedStack.Count);

            for (int i = 0; i < 1000; i++)
            {
                this.LinkedStack.Push(i);
                Assert.AreEqual(i + 1, this.LinkedStack.Count);
            }

            for (int i = 1000 - 1; i >= 0; i--)
            {
                var currentElement = this.LinkedStack.Pop();
                Assert.AreEqual(i, currentElement);
                Assert.AreEqual(i, this.LinkedStack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_Empty_ShouldThrow()
        {
            this.LinkedStack.Pop();
        }

        [TestMethod]
        public void ToArray_ShouldReturnArray()
        {
            var initialArr = new[] { 7, -2, 5, 3 };

            for (int i = initialArr.Length - 1; i >= 0; i--)
            {
                this.LinkedStack.Push(initialArr[i]);
            }

            var convertedStack = this.LinkedStack.ToArray();
            CollectionAssert.AreEqual(initialArr, convertedStack);
        }

        [TestMethod]
        public void Peek_ShouldReturnCorrect()
        {
            var element = 200;
            this.LinkedStack.Push(element);
            var peekElement = this.LinkedStack.Peek();
            Assert.AreEqual(element, peekElement);
        }
    }
}
