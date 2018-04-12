using System;
using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TirePressureTests
{
    public class AlarmTests
    {


        [Test]
        [TestCase(16)]
        public void AlarmActivatesOnPressureValueOutsideOfTheBoundries(int returnCase)
        {
           
            Mock<Alarm> alarm = new Mock<Alarm>();
            alarm.
            

           Assert.That(()=>alarm.Object.AlarmOn,Is.EqualTo(true));
        }
    }
}
