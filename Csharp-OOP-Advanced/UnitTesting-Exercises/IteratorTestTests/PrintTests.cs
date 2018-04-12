using System;
using System.Collections.Generic;
using System.Text;
using IteratorTest;
using NUnit.Framework;

namespace IteratorTestTests
{
    class PrintTests
    {
        [Test]
        public void PrintElementInEmptyCollection()
        {
            ListIterator iterator = new ListIterator();

            Assert.That(() => iterator.Print(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot print items off empty collection."));
        }
    }
}
