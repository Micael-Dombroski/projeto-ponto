using NUnit.Framework;
using ElectronicPointControl.Library;
using System.IO;
using System;

namespace ElectronicPointControl.Tests
{
    public class PointCRUDTests
    {
        static string filePath = "../../../../ElectronicPointControl.Tests/points.txt";
        static Point point = new Point(employeeRegistration: "1234", startWorkLoad: new System.DateTime())
        {
            StartPause = null,
            FinishPause = null,
            FinishWorkLoad = null
        };
        static PointCRUD sut = new(filePath);

        [TearDown]
        public void TearDown()
        {
            File.WriteAllText(filePath, string.Empty);
        }

        [Test]
        public void EnsurePointCRUDImplementsIRepository()
        {
            Assert.That(sut, Is.InstanceOf<IPointRepository>());
        }

        [Test]
        public void Add_EnsureDataAreSaving()
        {
            sut.Add(point);

            using (Stream file = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new(file))
                {
                    string[] props = reader.ReadLine().Split(";");
                    var result = new Point(employeeRegistration: props[1], startWorkLoad: Convert.ToDateTime(props[2]))
                    {
                        ID = Guid.Parse(props[0]),
                        StartPause = props[3] != "null" ? Convert.ToDateTime(props[1]) : null,
                        FinishPause = props[4] != "null" ? Convert.ToDateTime(props[2]) : null,
                        FinishWorkLoad = props[5] != "null" ? Convert.ToDateTime(props[3]) : null
                    };
                    Assert.That(result, Is.EqualTo(point));
                }
            }
        }

        [Test]
        public void GetAll_EnsureReturnsAList()
        {
            sut.Add(point);

            var result = sut.GetAll();

            Assert.That(result, Is.InstanceOf<System.Collections.Generic.List<Point>>());
        }
    }
}
