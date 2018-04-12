using System;
using System.Collections.Generic;
using System.Text;
using IteratorTest;
using NUnit.Framework;

namespace IteratorTestTests
{
    class HasNextTests
    {
        [Test]
        public void ReturnTrueIfThereIsNextIndex()
        {
            ListIterator iterator = new ListIterator("one","two");

            Assert.That(()=>iterator.HasNext(),Is.True);
        }

        [Test]
        public void ReturnFalseIfThereIsNoNextIndex()
        {
            ListIterator iterator = new ListIterator("one");

            Assert.That(() => iterator.HasNext(), Is.False);
        }
    }
}
