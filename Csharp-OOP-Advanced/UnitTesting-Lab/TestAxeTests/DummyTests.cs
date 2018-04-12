using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestAxeTests
{
    class DummyTests
    {
        private const string HeroName = "Ivan";
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private Hero hero;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.hero = new Hero(HeroName);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var attackDamage = 1;

            dummy.TakeAttack(attackDamage);

            Assert.That(dummy.Health, Is.EqualTo(DummyHealth- attackDamage), "Dummy doesn't loose health after attack.");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            var attackDamageToKill = DummyHealth;

            dummy.TakeAttack(attackDamageToKill);

            Assert.That(() => dummy.TakeAttack(1), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExpirience()
        { 
            hero.Attack(dummy);
            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(DummyXP));
        }

        [Test]
        public void AliveDummyCantGiveExpirience()
        {
            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(0));
        }
    }
}
