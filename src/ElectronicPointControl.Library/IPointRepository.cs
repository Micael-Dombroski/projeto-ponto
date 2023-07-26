using System.Collections.Generic;
using System;

namespace ElectronicPointControl.Library
{
    public interface IPointRepository
    {
        void Add(Point point);
        void Delete(Guid id);
        Point FindByID(Guid id);
        List<Point> GetAll();
        void Update(Point point);
    }
}
