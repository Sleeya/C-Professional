using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ExtendedDatabaseTests
{
    class FindByTests
    {
        [Test]
        public void AttemptToFindByInvalidUsername()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId, initialName);
            Database db = new Database();

            db.Add(person);

            Assert.That(() => db.FindByUsername("Gosho"), Throws.InvalidOperationException.With.Message.EqualTo($"User with username Gosho doesn't exists."));
        }

        [Test]
        public void AttemptToFindByNullUsername()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId, initialName);
            Database db = new Database();

            db.Add(person);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AttemptToFindByInvalidId()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId, initialName);
            Database db = new Database();

            db.Add(person);

            Assert.That(() => db.FindById(2), Throws.InvalidOperationException.With.Message.EqualTo($"User with id 2 doesn't exists."));
        }

        [Test]
        public void AttemptToFindByNegativeId()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId, initialName);
            Database db = new Database();

            db.Add(person);

            Assert.That(() => db.FindById(-2), Throws.Exception);
        }

    }
}
