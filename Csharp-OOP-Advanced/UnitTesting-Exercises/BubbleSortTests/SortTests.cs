using System;
using BubbleSortTest;
using BubbleSortTest;
using NUnit.Framework;

namespace BubbleSortTests
{
    public class SortTests
    {
        [Test]
        public void TestSortingAlgoritmOutput()
        {
            Buble bubble = new Buble(5,1,4,2,8);
            
            Assert.That(()=>bubble.Sort(),Is.EqualTo("1 2 4 5 8"));
        }
    }
}
