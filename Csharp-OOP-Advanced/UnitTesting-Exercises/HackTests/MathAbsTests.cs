using System;
using Hack;
using Moq;
using NUnit.Framework;

namespace HackTests
{
    public class MathAbsTests
    {
        private const double positiveInitialNumber = 13;
        private const double negativeInitialNumber = -13;

        [Test]
        public void PositiveInputTestExpectingPositiveOutput()
        {
            Mock<Data> data = new Mock<Data>(positiveInitialNumber);
           
            Assert.That(data.Object.AbsData,Is.EqualTo(positiveInitialNumber));
        }

        [Test]
        public void NegativeInputTestExpectingPositiveOutput()
        {
            Mock<Data> data = new Mock<Data>(negativeInitialNumber);

            Assert.That(data.Object.AbsData, Is.EqualTo(positiveInitialNumber));
        }
    }
}
