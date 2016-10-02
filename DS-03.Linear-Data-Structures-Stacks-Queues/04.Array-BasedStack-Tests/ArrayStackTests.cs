using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04.Array_BasedStack_Tests
{
    using _03.ImplementArray_BasedStack;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PushPop_OneElement()
        {
            var stack = new ArrayStack<int>();
            var testElement = 84;

            Assert.AreEqual(0, stack.Count);
            stack.Push(testElement);
            Assert.AreEqual(1, stack.Count);
            var popElement = stack.Pop();
            Assert.AreEqual(testElement, popElement);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushPop_1000Elements()
        {
            var stack = new ArrayStack<string>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
                Assert.AreEqual(i + 1, stack.Count);
            }

            for (int i = 999; i >= 0; i--)
            {
                var currElement = stack.Pop();
                Assert.AreEqual(i.ToString(), currElement);
                Assert.AreEqual(i, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ThrowException()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void PushPop_InitialCapacity_ShouldPass()
        {
            var stack = new ArrayStack<int>(1);
            Assert.AreEqual(stack.Count, 0);
            stack.Push(2);
            Assert.AreEqual(stack.Count, 1);
            stack.Push(3);
            Assert.AreEqual(stack.Count, 2);
            var popedElement = stack.Pop();
            Assert.AreEqual(popedElement, 3);
            Assert.AreEqual(stack.Count, 1);
            var popedElement2 = stack.Pop();
            Assert.AreEqual(popedElement2, 2);
            Assert.AreEqual(stack.Count, 0);




        }
    }
}
