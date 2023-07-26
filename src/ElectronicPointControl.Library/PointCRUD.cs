using System.Collections.Generic;
using System;
using System.IO;

namespace ElectronicPointControl.Library
{
    public class PointCRUD : IPointRepository
    {
        private string filePath;

        public PointCRUD(string filePath
                = "../ElectronicPointControl.Library/Database/pointhistory.txt")
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

        public Point FindByID(Guid id)
        {
            var points = GetAll();
            return points.Find(point => point.ID == id);
        }

        public List<Point> GetAll()
        {
            List<Point> points = new();
            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                using (StreamReader reader = new(file))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var props = line.Split(";");
                        var point = new Point(employeeRegistration: props[1], startWorkLoad: Convert.ToDateTime(props[2]))
                        {
                            ID = Guid.Parse(props[0]),
                            StartPause = props[3] != "null" ? Convert.ToDateTime(props[3]) : null,
                            FinishPause = props[4] != "null" ? Convert.ToDateTime(props[4]) : null,
                            FinishWorkLoad = props[5] != "null" ? Convert.ToDateTime(props[5]) : null

                        };
                        points.Add(point);
                        line = reader.ReadLine();
                    }
                }
            }
            return points;
        }

        public void Update(Point point)
        {
            Delete(point.ID);
            Add(point);
        }

        private void Delete(Guid id)
        {
            var points = GetAll();
            points.Remove(FindByID(id));
            using (Stream file = File.Open(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new(file))
                {
                    foreach (var point in points)
                    {
                        writer.WriteLine(point);
                    }
                }
            }

        }
    }
}
