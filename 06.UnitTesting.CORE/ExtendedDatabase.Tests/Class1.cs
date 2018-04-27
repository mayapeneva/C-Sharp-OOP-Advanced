using NUnit.Framework;
using System.Collections.Generic;

namespace ExtendedDatabaseTests
{
    public class Class1
    {
        [Test]
        public void Constructor_AddsLessThan16People_ShouldAddThem()
        {
            var expected = 3;

            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.AreEqual(expected, db.Count);
        }

        [Test]
        public void Constructor_AddsMoreThan16People_ShouldThrowException()
        {
            Assert.That(
                () =>
                {
                    new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"), new Person(4, "d"),
                        new Person(5, "e"), new Person(6, "f"), new Person(7, "g"), new Person(8, "h"),
                        new Person(9, "i"), new Person(10, "j"), new Person(11, "k"), new Person(12, "l"),
                        new Person(13, "m"), new Person(14, "n"), new Person(15, "o"), new Person(16, "p"),
                        new Person(17, "q"));
                }, Throws.InvalidOperationException);
        }

        [Test]
        public void Add_IfCountLessThan16_ShouldAddPersonAsLast()
        {
            var expected = new Person(3, "c");
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"));

            db.Add(new Person(3, "c"));

            Assert.AreEqual(expected, db.Fetch()[db.Count - 1]);
        }

        [Test]
        public void Add_IfCountMoreThan16_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"),
                new Person(4, "d"), new Person(5, "e"), new Person(6, "f"), new Person(7, "g"), new Person(8, "h"),
                new Person(9, "i"), new Person(10, "j"), new Person(11, "k"), new Person(12, "l"), new Person(13, "m"),
                new Person(14, "n"), new Person(15, "o"), new Person(16, "p"));

            Assert.That(() => { db.Add(new Person(17, "q")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Add_ThereIsUserWithTheSameUsername_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.Add(new Person(4, "b")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Add_IfThereisUserWithTheSameId_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.Add(new Person(2, "d")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_IfCountMoreThan0_ShouldRemoveLastPerson()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));
            var last = new Person(3, "c");

            db.Remove();

            Assert.That(!db.Fetch().Contains(last));
        }

        [Test]
        public void Remove_IfCountZero_ShouldThrowException()
        {
            var db = new ExtendedDatabase();

            Assert.That(() => { db.Remove(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_IfPresent_ShouldFindPerson()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));
            var expected = new Person(2, "b");

            Assert.AreEqual(expected, db.FindByUsername("b"));
        }

        [Test]
        public void FindByUsername_IfNotPresent_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.FindByUsername("d"); }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_IfUsernameLowerCase_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "Aaa"), new Person(2, "Bbb"), new Person(3, "Ccc"));

            Assert.That(() => { db.FindByUsername("aaa"); }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_IfUsernameIsNull_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.FindByUsername(null); }, Throws.ArgumentNullException);
        }

        [Test]
        public void FindById_IfPresent_ShouldFindPerson()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));
            var expected = new Person(2, "b");

            Assert.AreEqual(expected, db.FindById(2));
        }

        [Test]
        public void FindById_IfNotPresent_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.FindById(4); }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_IfIdIsNegative_ShouldThrowException()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));

            Assert.That(() => { db.FindById(-1); }, Throws.ArgumentException);
        }

        [Test]
        public void Fetch_ReturnFullCollection()
        {
            var db = new ExtendedDatabase(new Person(1, "a"), new Person(2, "b"), new Person(3, "c"));
            var list = new List<Person> { new Person(1, "a"), new Person(2, "b"), new Person(3, "c") };

            Assert.That(db.Fetch(), Is.EqualTo(list));
        }
    }
}