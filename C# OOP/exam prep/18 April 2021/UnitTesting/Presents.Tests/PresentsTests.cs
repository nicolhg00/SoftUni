using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }

        [Test]
        public void Create_ThrowExceptionWhenPresentIsNull()
        {
            Present present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void Create_ThrowExcpetionWhenPresentIsAlreadyExist()
        {
            Present present = new Present("game", 2);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_AddPresent()
        {
            Present present = new Present("game", 2);
            bag.Create(present);

            Assert.That(present, Is.EqualTo(bag.GetPresent(present.Name)));
        }

        [Test]
        public void Remove_RemovePresent()
        {
            Present present = new Present("game", 2);
            bag.Create(present);
            bag.Remove(present);

            Assert.That(bag.GetPresent(present.Name), Is.Null);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present truck = new Present("Truck", 69);
            Present bus = new Present("Bus", 100);
            Present leastMagic = new Present("No Magic", 1);

            bag.Create(truck);
            bag.Create(bus);
            bag.Create(leastMagic);

            Assert.That(leastMagic, Is.EqualTo(bag.GetPresentWithLeastMagic()));
        }

        [Test]
        public void GetPresent()
        {
            Present truck = new Present("Truck", 69);
            Present bus = new Present("Bus", 100);

            bag.Create(truck);
            bag.Create(bus);

            Present expectedPresent = bus;
            Present actualPresent = bag.GetPresent(bus.Name);

            Assert.AreEqual(expectedPresent, actualPresent);
        }
    }
}
