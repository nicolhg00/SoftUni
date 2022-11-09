    using System;
using System.Collections.Generic;

namespace Robots.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(10);
        }

        [Test]
        public void Add_ThrowExceptionWhenIsHaveAlready()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
            
        }

        [Test]
        public void Add_ThrowsExceptionWhenIsNotHaveCapacity()
        {
            Robot robot = new Robot("ivo", 1);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void Counter()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            robotManager.Remove("ivo");
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_throwsExc()
        {
            Robot robot = new Robot(null, 1);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(null));
        }

        [Test]
        public void Work_TrowsExcNotExist()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("ivo", "nz", 90));
        }

        [Test]
        public void Work_ThrowsExcBatt()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("ivo", "nz", 40));
        }

        [Test]
        public void Work()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            robotManager.Work("ivo", "nz", 1);

            Assert.That(robot.Battery, Is.EqualTo(29));
        }

        [Test]
        public void Charge_ok()
        {
            Robot robot = new Robot("ivo", 30);
            robotManager.Add(robot);
            robotManager.Work("ivo", "nz", 1);
            robotManager.Charge("ivo");

            Assert.That(robot.Battery, Is.EqualTo(30));
        }
    }
}
