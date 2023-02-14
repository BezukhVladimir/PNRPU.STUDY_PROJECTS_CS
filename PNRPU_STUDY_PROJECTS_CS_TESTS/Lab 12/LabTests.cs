using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryHeap;

namespace Lab12.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()] // TestMethod_Condition_ExpectedResult pattern
        public void Insert_InsertNewItem_IncreasingCounterByOne() {
            // AAA pattern
            // arrange
            int expectedCount = 1;

            // act
            MaxHeap<int> obj = new();
            obj.Insert(100);

            // assert
            Assert.AreEqual(expectedCount, obj.Count);
        }

        [TestMethod()]
        public void Peek_PeekRootItem_RootItemIsMax() {
            int [] items = {-2, -1, 0, 1, 2};
            int expectedMax = items.Max();

            MaxHeap<int> obj = new();
            foreach (int item in items) {
                obj.Insert(item);
            }

            Assert.AreEqual(expectedMax, obj.Peek());
        }

        [TestMethod()]
        public void Extract_ExtractRootItem_RootItemIsMax() {
            int [] items = {-2, -1, 0, 1, 2};
            int expectedMax = items.Max();

            MaxHeap<int> obj = new();
            foreach (int item in items) {
                obj.Insert(item);
            }

            Assert.AreEqual(expectedMax, obj.Extract());

            items = Array.FindAll(items, (item) => item != expectedMax).ToArray();
            int expectedNewMax = items.Max();

            Assert.AreEqual(expectedNewMax, obj.Peek());
        }
    }
}