using NUnit.Framework;
using Programm;
using System;

namespace Add.Tests
{
    [TestFixture]
    public class AddTests
    {
        private Database Db;

        [SetUp]
        public void InitialTest()
        {
            this.Db = new Database(new[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C"), new Person(4, "D"), new Person(5, "E"), new Person(6, "F"), new Person(7, "G"), new Person(8, "H"), new Person(9, "I"), new Person(10, "J"), new Person(11, "K"), new Person(12, "L"), new Person(13, "M"), new Person(14, "N"), new Person(15, "O"), new Person(16, "P") });
        }

        [Test]
        public void AddPersonToDb()
        {
            Assert.AreEqual(16, this.Db.People[this.Db.Count - 1].Id, "You cannot add a Person to the database.");
        }

        [Test]
        public void NotAbleToAddSixteenthPersonToDb()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.Add(new Person(17, "Q")));
        }

        public void NotAbleToAddPersonWithTheSameId()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.Add(new Person(4, "S")));
        }

        public void NotAbleToAddPersonWithTheSameName()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.Add(new Person(20, "A")));
        }
    }
}