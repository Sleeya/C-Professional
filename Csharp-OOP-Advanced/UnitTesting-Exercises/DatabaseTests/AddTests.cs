using System;
using NUnit.Framework;

namespace DatabaseTests
{
    public class AddTests
    {
        private Database fullDb;

        [SetUp]
        public void TestInit()
        {
            this.fullDb = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16);
        }

        [Test]
        public void ThrowsExceptionIfAddMoreElementsThanPossible()
        {
            Assert.That(()=>fullDb.Add(1),Throws.InvalidOperationException.With.Message.EqualTo("Cannot add more elements."));
        }

    }
}
