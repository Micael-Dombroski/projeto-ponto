using System;

namespace ElectronicPointControl.Library
{
    public class PunchClock
    {
        public Employee Employee;
        public DateTime TimeWhenPunchClockWasHit;
        public Point Point;
        public PointCRUD Points= new();
        public PunchClock(Employee employee)
        {
            this.Employee = employee;
        }
        public void PunchClocked()
        {
            if (Employee.TimesPunchClockGetValue() == 2)
                Employee.TimesPunchClockReset();


            if (Employee.TimesPunchClockGetValue() == 0)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao entrar: {Employee.WorkLoad.StartHour.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao entrar: {Employee.WorkLoad.StartHour.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= Employee.WorkLoad.StartHour.AddMinutes(-5) && DateTime.Now <= Employee.WorkLoad.StartHour.AddMinutes(5))
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    Employee.GetHourWhoStartTodayValue(TimeWhenPunchClockWasHit);
                    Employee.TimesPunchClockAddition();
                    Point = new Point(Employee.Registration, TimeWhenPunchClockWasHit);
                    Employee.GetPointIdToday(Point.ID);
                    Points.Add(Point);
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
            }
            else if (Employee.TimesPunchClockGetValue() == 1)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao sair: {Employee.WorkLoad.EndHour.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao sair: {Employee.WorkLoad.EndHour.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= Employee.WorkLoad.EndHour.AddMinutes(-5)
                    && DateTime.Now <= Employee.WorkLoad.EndHour.AddMinutes(5))
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    Employee.GetHourWhoEndsTodayValue(TimeWhenPunchClockWasHit);
                    Employee.TimesPunchClockAddition();
                    Points.FindByID(Employee.SendPointIdToday());
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
                CalcWorkedHours();
            }
        }

        private void CalcWorkedHours()
        {
            TimeSpan calcWorkedHours = Employee.SendHourWhoEndsTodayValue().Subtract(Employee.SendHourWhoStartTodayValue());
            DateTime convertCalcWorkedHoursToDateTime = new DateTime(1996, 6, 3, 0, 0, 0);
            DateTime workedHours = convertCalcWorkedHoursToDateTime + calcWorkedHours;
            Console.WriteLine($"Hoje seu tempo trabalhado foi: {workedHours.ToString("H:mm:ss")}, parabéns!");
        }
    }
}