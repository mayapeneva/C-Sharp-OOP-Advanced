using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{
    public class Class1
    {
        [Test]
        public void Constructor_ShouldHaveZeroElement()
        {
            var list = new DynamicList<int>();
            var expected = 0;

            Assert.AreEqual(expected, list.Count);
        }

        [Test]
        public void Indexer_IndexInBounds_ShouldReturnTheRightItem()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var index = 1;
            var expected = 2;

            Assert.AreEqual(expected, list[index]);
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void Indexer_IndexOusideBounds_ShouldThrowException(int index)
        {
            var list = new DynamicList<int>();
            list.Add(1);

            Assert.That(() => { list[index].ToString(); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Add_ShouldAddItem()
        {
            var list = new DynamicList<int>();
            list.Add(3);
            var expected = 1;

            Assert.AreEqual(expected, list.Count);
        }

        [Test]
        public void RemoveAt_CorrectIndex_ShouldRemoveTheRightItem()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var itemToRemove = 2;
            list.RemoveAt(1);
            var expected = false;

            Assert.AreEqual(expected, list.Contains(itemToRemove));
        }

        [Test]
        public void RemoveAt_CorrectIndex_ShouldRemoveTheReturnTheRightItem()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var itemToRemove = 2;

            Assert.AreEqual(itemToRemove, list.RemoveAt(1));
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAt_IncorrectIndex_ShouldThrowException(int index)
        {
            var list = new DynamicList<int>();
            list.Add(3);

            Assert.That(() => { list.RemoveAt(index); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Remove_ExistingItem_ShouldRemoveTheRightItem()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var itemToRemove = 2;
            list.Remove(itemToRemove);
            var expected = false;

            Assert.AreEqual(expected, list.Contains(itemToRemove));
        }

        [Test]
        public void Remove_ExistingItem_ShouldReturnTheRightIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var itemToRemove = 2;
            var expectedIndex = 1;

            Assert.AreEqual(expectedIndex, list.Remove(itemToRemove));
        }

        [Test]
        public void Remove_NonExistingItem_ShouldReturnNegativeIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var itemToRemove = 4;
            var expectedIndex = -1;

            Assert.AreEqual(expectedIndex, list.Remove(itemToRemove));
        }

        [Test]
        public void IndexOf_ExistingItem_ShouldReturnTheRightIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var item = 2;
            var expectedIndex = 1;

            Assert.AreEqual(expectedIndex, list.Remove(item));
        }

        [Test]
        public void IndexOf_NonExistingItem_ShouldReturnNegativeIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var item = 4;
            var expectedIndex = -1;

            Assert.AreEqual(expectedIndex, list.Remove(item));
        }
    }
}