using NUnit.Framework;
using ElectronicPointControl.Library;
using System;
using System.Collections.Generic;
using System.IO;

namespace ElectronicPointControl.Tests
{
    public class PunchClockTests
    {
        string filePath = "fakePoints.txt";
        Employee fakeEmployee;
        CPF fakeCPF;
        WorkLoad fakeWorkload;
        PunchClock fakePunchClock;

        [SetUp]
        public void SetUp()
        {
            fakeCPF = new CPF("123.456.789-09");
            fakeWorkload = new WorkLoad
            {
                StartHour = DateTime.Now,
                EndHour = DateTime.Now
            };
            fakeEmployee = new Employee(
                workLoad: fakeWorkload,
                cpf: fakeCPF,
                name: "name",
                registration: "registration",
                password: "password");
            fakePunchClock = new PunchClock(fakeEmployee);
            fakePunchClock.Points = new PointCRUD(filePath);
        }

        [TearDown]
        public void TearDown()
        {
            File.WriteAllText(filePath, string.Empty);
        }

        [Test]
        public void TestPuchClockingIsOutOfLimitTimeForStartHour()
        {
            var StartHour = fakeEmployee.WorkLoad.StartHour;
            StartHour = StartHour.AddMinutes(-20);
            fakePunchClock.PunchClocked();
            var TimeNow = fakePunchClock.TimeWhenPunchClockWasHit;
            Assert.IsFalse(TimeNow >= StartHour.AddMinutes(5) && TimeNow <= StartHour.AddMinutes(-5));
        }

        [Test]
        public void TestPuchClockingIsInLimitTimeForStartHour()
        {
            var StartHour = fakeEmployee.WorkLoad.StartHour;
            fakePunchClock.PunchClocked();
            var TimeNow = fakePunchClock.TimeWhenPunchClockWasHit;
            Assert.IsTrue(StartHour.AddMinutes(5) > TimeNow && StartHour.AddMinutes(-5) < TimeNow);
        }

                [Test]
        public void TestPuchClockingIsOutOfLimitTimeForEndHour()
        {
            fakeEmployee.TimesPunchClockReset();
            fakePunchClock.PunchClocked();
            var EndHour = fakeEmployee.WorkLoad.EndHour;
            EndHour.AddMinutes(15);
            fakePunchClock.PunchClocked();
            var TimeNow = fakePunchClock.TimeWhenPunchClockWasHit;
            Assert.IsFalse(TimeNow >= EndHour.AddMinutes(5) && TimeNow <= EndHour.AddMinutes(-5));
        }

        [Test]
        public void TestPuchClockingIsInLimitTimeForEndHour()
        {
            fakeEmployee.TimesPunchClockReset();
            fakePunchClock.PunchClocked();
            var EndHour = fakeEmployee.WorkLoad.EndHour;
            fakePunchClock.PunchClocked();
            var TimeNow = fakePunchClock.TimeWhenPunchClockWasHit;
            Assert.IsTrue(EndHour.AddMinutes(5) > TimeNow && EndHour.AddMinutes(-5) < TimeNow);
        }

        [Test]
        public void CheckIfPointHasBeenCreated()
        {

            fakePunchClock.PunchClocked();
            Assert.IsFalse(fakePunchClock.Point is null);
        }

    }
}