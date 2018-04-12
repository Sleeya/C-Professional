using System;
using IteratorTest;
using NUnit.Framework;

namespace IteratorTestTests
{
    public class MoveTests
    {
        [Test]
        public void AttemptToMoveWhenNoNextIndex()
        {
            ListIterator iterator = new ListIterator("one", "two");

            iterator.Move();
            iterator.Move();

            Assert.That(() => iterator.Move(),Is.False);
        }

        [Test]
        public void AttemptToMoveToNextIndex()
        {
            ListIterator iterator = new ListIterator("one","two");

            Assert.That(()=>iterator.Move(),Is.True);
        }

        
    }
}
