using NUnit.Framework;
using System.Collections.Generic;

namespace IteratorTests
{
    public class Class1
    {
        [Test]
        public void Constructor_AddingCollection_ShouldAddStrings()
        {
            var list = new List<string> { "a", "b", "c" };
            var iterator = new ListIterator(list);

            Assert.AreEqual(list, iterator.Collection);
        }

        [Test]
        public void Constructor_AddingNullCollection_ShouldThrowException()
        {
            var list = new List<string>();

            Assert.That(() => { new ListIterator(list); }, Throws.ArgumentNullException);
        }

        [Test]
        public void HasNext_IfNotLastIndex_ShouldReturnTrue()
        {
            var list = new List<string> { "a", "b", "c" };
            var iterator = new ListIterator(list);
            var expected = true;

            Assert.AreEqual(expected, iterator.HasNext());
        }

        [Test]
        public void HasNext_IfLastIndex_ShouldReturnFalse()
        {
            var list = new List<string> { "a" };
            var iterator = new ListIterator(list);
            var expected = false;

            Assert.AreEqual(expected, iterator.HasNext());
        }

        [Test]
        public void Move_IfNotLastIndex_ShouldReturnTrue()
        {
            var list = new List<string> { "a", "b", "c" };
            var iterator = new ListIterator(list);
            var expected = true;

            Assert.AreEqual(expected, iterator.Move());
        }

        [Test]
        public void Move_IfLastIndex_ShouldReturnFalse()
        {
            var list = new List<string> { "a" };
            var iterator = new ListIterator(list);
            var expected = false;

            Assert.AreEqual(expected, iterator.Move());
        }

        [Test]
        public void Print_IfThereAreItem_PrintTheCorrectOne()
        {
            var list = new List<string> { "a", "b", "c" };
            var iterator = new ListIterator(list);
            var expected = "b";

            iterator.Move();

            Assert.AreEqual(expected, iterator.Print());
        }
    }
}