using System.Collections.Generic;
using System;

namespace ElectronicPointControl.Library
{
    public interface IPointRepository
    {
        void Add(Point point);
        Point FindByID(Guid id);
        List<Point> GetAll();
    }
}
