using System;

namespace ElectronicPointControl.Library
{
    public struct Point
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public DateTime? StartPause { get; set; }
        public DateTime? EndPause { get; set; }

        public override string ToString()
        {
            return $"{StartTime};{(StartPause is DateTime ? StartPause : "null")};{(EndPause is DateTime ? EndPause : "null")};{(EndTime is DateTime ? EndTime : "null")}";
        }
    }
}
