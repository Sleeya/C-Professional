using System;
using System.Collections.Generic;
using System.Text;
using Hack;
using Moq;
using NUnit.Framework;

namespace HackTests
{
    public class MathFloorTests
    {
        private const double initialPositiveLowEndNumber = 13.1;
        private const double initialPositiveHighEndNumber = 13.9;
        private const double expectedPositiveNumber = 13;
        private const double initialNegativeLowEndNumber = -13.1;
        private const double initialNegativeHighEndNumber = -13.9;
        private const double expectedNegativeNumber = -14;

        [Test]
        public void PositiveLowEndNumber()
        {
            Mock<Data> data = new Mock<Data>(initialPositiveLowEndNumber);

            Assert.That(data.Object.RoundedData, Is.EqualTo(expectedPositiveNumber));
        }

        [Test]
        public void PositiveHighEndNumber()
        {
            Mock<Data> data = new Mock<Data>(initialPositiveHighEndNumber);

            Assert.That(data.Object.RoundedData, Is.EqualTo(expectedPositiveNumber));
        }

        [Test]
        public void NegativeLowEndNumber()
        {
            Mock<Data> data = new Mock<Data>(initialNegativeLowEndNumber);

            Assert.That(data.Object.RoundedData, Is.EqualTo(expectedNegativeNumber));
        }

        [Test]
        public void NegativeHighEndNumber()
        {
            Mock<Data> data = new Mock<Data>(initialNegativeHighEndNumber);

            Assert.That(data.Object.RoundedData, Is.EqualTo(expectedNegativeNumber));
        }


    }
}
