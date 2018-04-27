using NUnit.Framework;
using Programm;
using System;

namespace Constructor.Tests
{
    [TestFixture]
    public class ConstTests
    {
        private Database Db;

        [Test]
        public void DbConstructorAcceptsPeopleList()
        {
            var collection = new[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C"), new Person(4, "D") };

            this.Db = new Database(collection);

            Assert.AreEqual(collection.Length, this.Db.Count, "Constructor does not accept Person's list");
        }

        [Test]
        public void NotAbleToCreateDbWithAListBiggerThanSixteenDigits()
        {
            var collection = new Person[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C"), new Person(4, "D"), new Person(5, "E"), new Person(6, "F"), new Person(7, "G"), new Person(8, "H"), new Person(9, "I"), new Person(10, "J"), new Person(11, "K"), new Person(12, "L"), new Person(13, "M"), new Person(14, "N"), new Person(15, "O"), new Person(16, "P"), new Person(17, "Q") };

            Assert.Throws<InvalidOperationException>(() => new Database(collection));
        }

        [Test]
        public void NotAbleToCreateDbWithEmptyList()
        {
            var collection = new Person[] { };

            Assert.Throws<InvalidOperationException>(() => new Database(collection));
        }
    }
}