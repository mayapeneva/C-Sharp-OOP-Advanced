using NUnit.Framework;
using Programm;

namespace Fetch.Tests
{
    [TestFixture]
    public class FetchTests
    {
        [Test]
        public void FetchReturnsArrayWithAllElements()
        {
            var collection = new[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C"), new Person(4, "D"), new Person(5, "E") };
            var db = new Database(collection);

            Assert.AreEqual(collection, db.Fetch(), "Fetch doesn't return Array with all elements.");
        }
    }
}