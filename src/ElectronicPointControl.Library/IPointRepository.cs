using System.Collections.Generic;

namespace ElectronicPointControl.Library
{
    public interface IPointRepository
    {
        void Add();
        Point Get();
        List<Point> GetAll();
    }
}
