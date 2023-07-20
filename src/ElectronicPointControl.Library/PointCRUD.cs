using System.Collections.Generic;
using System.IO;

namespace ElectronicPointControl.Library
{
    public class PointCRUD : IPointRepository
    {
        private string filePath;

        public PointCRUD(string filePath
                = "../ElectronicPointControl.Library/Database/employee.txt")
        {
            this.filePath = filePath;
        }

        public void Add(Point point)
        {
            if (!File.Exists(filePath))
            {
                Stream file = File.Open(filePath, FileMode.Create);
                file.Close();
            }
            using (Stream file = File.Open(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new(file))
                {
                    writer.WriteLine(point);
                }
            }
        }

        public Point Get()
        {
            throw new System.NotImplementedException();
        }

        public List<Point> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
