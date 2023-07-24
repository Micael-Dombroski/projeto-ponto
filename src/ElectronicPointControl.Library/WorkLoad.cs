using System;

namespace ElectronicPointControl.Library
{
    public class WorkLoad
    {
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }

        public WorkLoad(DateTime startHour, DateTime endHour)
        {
            StartHour = startHour;
            EndHour = endHour;
        }
    }
}
