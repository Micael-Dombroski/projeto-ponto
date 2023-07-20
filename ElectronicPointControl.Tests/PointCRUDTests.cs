using NUnit.Framework;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.Tests
{
    public class PointCRUDTests
    {
        [Test]
        public void EnsurePointCRUDImplementsIRepository()
        {
            var sut = new PointCRUD();

            Assert.That(sut, Is.InstanceOf<IPointRepository>());
        }
    }
}
