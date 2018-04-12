using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DatabaseTests
{
    public class RemoveTests
    {
        private Database db;

        [SetUp]
        public void TestInit()
        {
            this.db = new Database();
        }

        [Test]
        public void ThrowsExceptionIfTryingToRemoveElementFromEmptyDatabase()
        {
            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove element from empty database."));
        }
    }
}
