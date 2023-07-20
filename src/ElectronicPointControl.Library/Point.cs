using System;

namespace ElectronicPointControl.Library
{
    public class Point
    {
        public Guid ID { get; set; }
        public string EmployeeRegistration { get; }
        public DateTime StartWorkLoad { get; set; }
        public DateTime? StartPause { get; set; }
        public DateTime? FinishPause { get; set; }
        public DateTime? FinishWorkLoad { get; set; }

        public Point(string employeeRegistration, DateTime startWorkLoad)
        {
            ID = Guid.NewGuid();
            EmployeeRegistration = employeeRegistration;
            StartWorkLoad = startWorkLoad;
        }

        public override string ToString()
        {
            return $"{ID};{EmployeeRegistration};{StartWorkLoad};{(StartPause is DateTime ? StartPause : "null")};{(FinishPause is DateTime ? FinishPause : "null")};{(FinishWorkLoad is DateTime ? FinishWorkLoad : "null")}";
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   point.ID == ID &&
                   point.EmployeeRegistration == EmployeeRegistration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, EmployeeRegistration);
        }
    }
}
