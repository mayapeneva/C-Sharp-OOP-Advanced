using NUnit.Framework;
using Programm;
using System;

namespace Remove.Tests
{
    [TestFixture]
    public class RemoveTests
    {
        private Database Db;

        [Test]
        public void RemoveNumberFromDb()
        {
            this.Db = new Database(new[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C") });

            this.Db.Remove();

            Assert.AreEqual(2, this.Db.Count, "You cannot remove a number from the database.");
        }

        [Test]
        public void NotAbleToRemoveNumberFromEmptyDb()
        {
            this.Db = new Database(new[] { new Person(1, "A") });

            this.Db.Remove();

            Assert.Throws<InvalidOperationException>(() => this.Db.Remove());
        }
    }
}