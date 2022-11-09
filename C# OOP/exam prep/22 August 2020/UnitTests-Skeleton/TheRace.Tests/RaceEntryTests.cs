using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver = new UnitDriver("Driver Ivo", new UnitCar("e60", 350, 3000));
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_ThrowExceptionWhenDriverIsNull()
        {
            UnitDriver unitDriver = null;
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriver_ThrowsExceptionWhenDriverIsAlreadyExist()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ReturnsProperMessage()
        {
            string expected = $"Driver {driver.Name} added in race.";

            string actual = raceEntry.AddDriver(driver);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsExc()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            int totalHorsePower = 0;

            for (int i = 0; i < 100; i++)
            {
                raceEntry.AddDriver(new UnitDriver($"{i}", new UnitCar($"{i}", i + 100, i + 100)));
                totalHorsePower += i + 100;
            }

            double expected = totalHorsePower * 1.0 / raceEntry.Counter;

            double actual = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }
    }
}