using NUnit.Framework;
using ElectronicPointControl.Library;
using System.IO;
using System;

namespace ElectronicPointControl.Tests
{
    public class PointCRUDTests
    {
        static string filePath = "../../../../ElectronicPointControl.Tests/points.txt";
        static Point point = new Point()
        {
            StartTime = new System.DateTime(),
            StartPause = null,
            EndPause = null,
            EndTime = null
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
                    var result = new Point()
                    {
                        StartTime = Convert.ToDateTime(props[0]),
                        StartPause = props[1] != "null" ? Convert.ToDateTime(props[1]) : null,
                        EndPause = props[2] != "null" ? Convert.ToDateTime(props[2]) : null,
                        EndTime = props[3] != "null" ? Convert.ToDateTime(props[3]) : null
                    };
                    Assert.That(result, Is.EqualTo(point));
                }
            }
        }
    }
}
