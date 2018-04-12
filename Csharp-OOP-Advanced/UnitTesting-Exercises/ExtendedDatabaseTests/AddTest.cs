using System;
using NUnit.Framework;

namespace ExtendedDatabaseTests
{
    public class AddTest
    {
        [Test]
        public void AttemptToAddExistingUsername()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId,initialName);
            Database db = new Database();

            db.Add(person);

            Assert.That(()=>db.Add(person),Throws.InvalidOperationException.With.Message.EqualTo($"User with username {person.Username} already exists."));
        }

        [Test]
        public void AttemptToAddExistingId()
        {
            var initialId = 1;
            var initialName = "Ivan";
            Person person = new Person(initialId, initialName);
            Person secondPerson = new Person(initialId,"Gosho");
            Database db = new Database();

            db.Add(person);

            Assert.That(() => db.Add(secondPerson), Throws.InvalidOperationException.With.Message.EqualTo($"User with id {person.Id} already exists."));
        }
    }
}
