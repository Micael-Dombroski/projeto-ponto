using System;

namespace ElectronicPointControl.Library
{
    public class PunchClock
    {
        public DateTime TimeWhenPunchClockWasHit;
        private IPointRepository PointCRUD;

        public PunchClock(PointCRUD crud)
        {
            this.PointCRUD = crud;
        }

        public void PunchClocked(Employee employee)
        {
            if (employee.TimesPunchClockGetValue() == 2)
                employee.TimesPunchClockReset();


            if (employee.TimesPunchClockGetValue() == 0)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao entrar: {employee.WorkLoad.StartTime.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao entrar: {employee.WorkLoad.StartTime.AddMinutes(5).ToString("H:mm:ss")}");

                Point point;
                if (
                        DateTime.Now >= employee.WorkLoad.StartTime.AddMinutes(-5) &&
                        DateTime.Now <= employee.WorkLoad.StartTime.AddMinutes(5)
                    )
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    employee.GetHourWhoStartTodayValue(TimeWhenPunchClockWasHit);
                    employee.TimesPunchClockAddition();
                    point = new Point(employee.Registration, TimeWhenPunchClockWasHit);
                    employee.GetPointIdToday(point.ID);
                    PointCRUD.Add(point);
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
            }
            else if (employee.TimesPunchClockGetValue() == 1)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao sair: {employee.WorkLoad.FinishTime.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao sair: {employee.WorkLoad.FinishTime.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= employee.WorkLoad.FinishTime.AddMinutes(-5)
                    && DateTime.Now <= employee.WorkLoad.FinishTime.AddMinutes(5))
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    employee.GetHourWhoEndsTodayValue(TimeWhenPunchClockWasHit);
                    employee.TimesPunchClockAddition();
                    PointCRUD.FindByID(employee.SendPointIdToday());
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
                CalcWorkedHours(employee);
            }
        }

        private void CalcWorkedHours(Employee employee)
        {
            TimeSpan calcWorkedHours = employee.SendHourWhoEndsTodayValue().Subtract(employee.SendHourWhoStartTodayValue());
            DateTime convertCalcWorkedHoursToDateTime = new DateTime(1996, 6, 3, 0, 0, 0);
            DateTime workedHours = convertCalcWorkedHoursToDateTime + calcWorkedHours;
            Console.WriteLine($"Hoje seu tempo trabalhado foi: {workedHours.ToString("H:mm:ss")}, parabéns!");
        }
    }
}
