using NUnit.Framework;
using System.Collections.Generic;

namespace Database.Tests
{
    public class DatabaseTests
    {
        [Test]
        public void Constructor_AddsLessThan16Integets_ShouldHaveTheInts()
        {
            var expected = 5;

            var db = new DataBase(1, 2, 3, 4, 5);

            Assert.AreEqual(expected, db.Count);
        }

        [Test]
        public void Constructor_AddsMoreThan16Integets_ShouldThrowException()
        {
            Assert.That(() => { new DataBase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Add_IfCountLessThan16_ShouldAddNumberAsLast()
        {
            var expectedNumber = 3;
            var db = new DataBase(1, 2);

            db.Add(3);

            Assert.AreEqual(expectedNumber, db.Fetch()[db.Count - 1]);
        }

        [Test]
        public void Add_IfCountMoreThan16_ShouldThrowException()
        {
            var db = new DataBase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.That(() => { db.Add(17); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_IfCountMoreThan0_ShouldRemoveLastNumber()
        {
            var db = new DataBase(1, 2, 3, 4, 5);
            var lastNumber = 5;

            db.Remove();

            Assert.That(!db.Fetch().Contains(lastNumber));
        }

        [Test]
        public void Remove_IfCountZero_ShouldThrowException()
        {
            var db = new DataBase();

            Assert.That(() => { db.Remove(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Fetch_ReturnFullCollection()
        {
            var db = new DataBase(1, 2, 3, 4, 5);
            var list = new List<int> { 1, 2, 3, 4, 5 };

            Assert.That(db.Fetch(), Is.EqualTo(list));
        }
    }
}