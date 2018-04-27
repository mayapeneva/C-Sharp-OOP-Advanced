using NUnit.Framework;
using Programm;
using System;

namespace Find.Tests
{
    [TestFixture]
    public class FindTests
    {
        private Database Db;

        [SetUp]
        public void InitialTest()
        {
            this.Db = new Database(new[] { new Person(1, "A"), new Person(2, "B"), new Person(3, "C"), new Person(4, "D"), new Person(5, "E") });
        }

        [Test]
        public void NotAbleToFindPersonWithThisUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.FindByName("F"));
        }

        [Test]
        public void NotAbleToFindPersonWithNullUsernameParameter()
        {
            Assert.Throws<ArgumentNullException>(() => this.Db.FindByName(null));
        }

        [Test]
        public void NotAbleToFindPersonWithLowerCaseUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.FindByName("a"));
        }

        [Test]
        public void NotAbleToFindPersonWithThisId()
        {
            Assert.Throws<InvalidOperationException>(() => this.Db.FindById(6));
        }

        [Test]
        public void NotAbleToFindPersonWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.Db.FindById(-1));
        }
    }
}