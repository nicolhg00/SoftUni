namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorInitiazlieCorrectly()
        {
            string name = "aname";
            int capacity = 1;
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);
        }

        [Test]
        public void SetNameThrowExc()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 1));
        }

        [Test]
        public void CapacityThrowExc()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("a", -1));
        }

        [Test]
        public void Count()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("a"));
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExc()
        {
            Aquarium aquarium = new Aquarium("testA", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("fishy")));
        }

        [Test]
        public void RemoveThrowExc()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void Remove()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("aaa"));
            aquarium.RemoveFish("aaa");

            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void SellFishShouldThrowExc()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void SellFish()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("aaa"));
            Fish fish = aquarium.SellFish("aaa");

            Assert.AreEqual(fish.Name, "aaa");
            Assert.AreEqual(fish.Available, false);
        }

        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("aaa"));

            string expectedMessage = $"Fish available at a: aaa";
            Assert.AreEqual(expectedMessage, aquarium.Report());
        }
    }
}
