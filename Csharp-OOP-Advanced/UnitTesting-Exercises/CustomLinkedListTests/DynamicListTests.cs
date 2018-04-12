using System;
using CustomLinkedList;
using NUnit.Framework;

namespace CustomLinkedListTests
{
    public class DynamicListTests
    {
        private DynamicList<int> list;

        [SetUp]
        public void TestInit()
        {
            this.list = new DynamicList<int>();
        }


        [Test]
        public void CannotGetNegativeIndex()
        {
            var negativeIndex = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = this.list[negativeIndex];
            }, $"Invalid index: {negativeIndex}");
        }

        [Test]
        public void CannotGetIndexHighThanAvailable()
        {
            var index = 1;
            this.list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = this.list[index];
            }, $"Invalid index: {index}");
        }

        [Test]
        public void CannotSetNegativeIndex()
        {
            var negativeIndex = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.list[negativeIndex] = 5;
            }, $"Invalid index: {negativeIndex}");
        }

        [Test]
        public void CannotSetIndexHighThanAvailable()
        {
            var index = 1;
            this.list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.list[index] = 0;
            }, $"Invalid index: {index}");
        }

        [Test]
        public void AddIncreasesCollectionCount()
        {
            var initialSize = this.list.Count;

            this.list.Add(1);

            Assert.That(this.list.Count, Is.EqualTo(initialSize + 1));
        }

        [Test]
        [TestCase(10, 7)]
        [TestCase(9, 6)]
        public void AddSavesTheElementToTheCollectoin(int numberOfElementsToAdd, int indexToCheck)
        {
            AddElements(numberOfElementsToAdd);

            Assert.That(this.list[indexToCheck], Is.EqualTo(indexToCheck));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAtCannotRemoveInvalidIndexes(int index)
        {
            this.list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.list.RemoveAt(index);
            });
        }

        [Test]
        [TestCase(6,5)]
        [TestCase(7,6)]
        public void RemoveAtRemovesTheCorrectElement(int numberOfElementsToAdd,int removeIndex)
        {
            this.AddElements(numberOfElementsToAdd);

            this.list.RemoveAt(removeIndex);

            Assert.That(()=>this.list.Contains(removeIndex),Is.False);
        }

        [Test]
        [TestCase(6, 5)]
        [TestCase(7, 6)]
        public void RemoveRemovesTheCorrectElement(int numberOfElementsToAdd, int removeIndex)
        {
            this.AddElements(numberOfElementsToAdd);

            this.list.Remove(removeIndex);

            Assert.That(() => this.list.Contains(removeIndex), Is.False);
        }

        [Test]
        [TestCase(6, 5)]
        [TestCase(7, 6)]
        public void IndexOfPointsToTheCorrectIndexOfTheElement(int numberOfElementsToAdd, int indexToFind)
        {
            this.AddElements(numberOfElementsToAdd);
           
            Assert.That(this.list.IndexOf(indexToFind), Is.EqualTo(indexToFind));
        }

        [Test]
        [TestCase(6, 6)]
        [TestCase(7, 8)]
        [TestCase(1,-1)]
        public void IndexOfReturnsNegativeNumberIfElementIsNotFound(int numberOfElementsToAdd, int invalidIndex)
        {
            this.AddElements(numberOfElementsToAdd);

            Assert.That(this.list.IndexOf(invalidIndex), Is.EqualTo(-1));
        }

        [Test]
        [TestCase(6, 5,true)]
        [TestCase(7, 7,false)]
        public void ContainsReturnsCorrectBoolStatement(int numberOfElementsToAdd, int elementToFind,bool expectedStatement)
        {
            this.AddElements(numberOfElementsToAdd);

            Assert.That(this.list.Contains(elementToFind), Is.EqualTo(expectedStatement));
        }
        private void AddElements(int numberOfElementsToAdd)
        {
            for (int i = 0; i < numberOfElementsToAdd; i++)
            {
                this.list.Add(i);
            }
        }
    }
}
