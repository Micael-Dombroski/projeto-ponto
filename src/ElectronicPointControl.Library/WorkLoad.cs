using System;

namespace ElectronicPointControl.Library
{
    public class WorkLoad
    {
        public DateTime StartTime { get; set; }
        public DateTime? StartPause { get; set; }
        public DateTime? FinishPause { get; set; }
        public DateTime FinishTime { get; set; }

        public WorkLoad(DateTime startTime, DateTime finishTime, DateTime? startPause = null, DateTime? finishPause = null)
        {
            StartTime = startTime;
            StartPause = startPause;
            FinishPause = finishPause;
            FinishTime = finishTime;
        }

        public string StartToString()
        {
            return StartTime.ToString("H:mm:ss");
        }

        public string EndToString()
        {
            return FinishTime.ToString("H:mm:ss");
        }

        public string SPauseToString()
        {
            if (StartPause is null)
            {
                return "Não Informado";
            }
            else
            {
                DateTime SPause = Convert.ToDateTime(StartPause);
                return SPause.ToString("H:mm:ss");
            }
        }
        public string FPauseToString()
        {
            if (FinishPause is null)
            {
                return "Não Informado";
            }
            else
            {
                DateTime FPause = Convert.ToDateTime(FinishPause);
                return FPause.ToString("H:mm:ss");
            }
        }

        public override string ToString()
        {
            return $"{StartTime};{FinishTime};{(StartPause is null ? "null" : StartPause)};{(FinishPause is null ? "null" : FinishPause)}";
        }
    }
}
