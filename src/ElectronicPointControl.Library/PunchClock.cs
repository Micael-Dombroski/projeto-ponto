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
            if (Employee.TimesPunchClockGetValue() == 4)
                Employee.TimesPunchClockReset();


            if (Employee.TimesPunchClockGetValue() == 0)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao entrar: {Employee.WorkLoad.StartTime.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao entrar: {Employee.WorkLoad.StartTime.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= Employee.WorkLoad.StartTime.AddMinutes(-5) && DateTime.Now <= Employee.WorkLoad.StartTime.AddMinutes(5))
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    Employee.TimesPunchClockAddition();
                    Point = new Point(Employee.Registration, TimeWhenPunchClockWasHit);
                    Employee.GetPointIdToday(Point.ID);
                    Points.Add(Point);
                }
                else
                {
                    throw new Exception("Fora do horário de começo");
                }
            }
            else if (Employee.TimesPunchClockGetValue() == 1)
            {
                if (DateTime.Now > Employee.WorkLoad.StartTime && DateTime.Now < Employee.WorkLoad.FinishTime)
                {
                    if (Employee.WorkLoad.StartPause is null)
                    {
                        TimeWhenPunchClockWasHit = DateTime.Now;
                        Point point = Points.FindByID(Employee.SendPointIdToday());
                        point.StartPause = TimeWhenPunchClockWasHit;
                        Employee.TimesPunchClockAddition();
                        Points.Update(point);
                    }
                    else
                    {
                        var StartPause = Convert.ToDateTime(Employee.WorkLoad.StartPause);
                        if (DateTime.Now >= StartPause.AddMinutes(-5) && DateTime.Now <= StartPause.AddMinutes(5))
                        {
                            TimeWhenPunchClockWasHit = DateTime.Now;
                            Point point = Points.FindByID(Employee.SendPointIdToday());
                            point.StartPause = TimeWhenPunchClockWasHit;
                            Employee.TimesPunchClockAddition();
                            Points.Update(point);
                        }
                        else
                        {
                            throw new Exception("Fora do horário de começo de pausa");
                        }
                    } 
                }
                else
                {
                    throw new Exception("Fora do horário de começo de pausa");
                }
            }
            else if (Employee.TimesPunchClockGetValue() == 2)
            {
                if (DateTime.Now > Employee.WorkLoad.StartTime && DateTime.Now < Employee.WorkLoad.FinishTime)
                {
                    if (Employee.WorkLoad.FinishPause is null)
                    {
                        TimeWhenPunchClockWasHit = DateTime.Now;
                        Point point = Points.FindByID(Employee.SendPointIdToday());
                        point.FinishPause = TimeWhenPunchClockWasHit;
                        DateTime startPause = Convert.ToDateTime(point.StartPause);
                        DateTime finishPause = Convert.ToDateTime(point.FinishPause);
                        if (startPause.AddMinutes(70) >= finishPause)
                        {
                            Employee.TimesPunchClockAddition();
                        Points.Update(point);
                        }
                        else
                        {
                            throw new Exception("Fora do horário de fim de pausa");
                        }
                    }
                    else
                    {
                        var FinishPause = Convert.ToDateTime(Employee.WorkLoad.FinishPause);
                        if (DateTime.Now >= FinishPause.AddMinutes(-5) && DateTime.Now <= FinishPause.AddMinutes(5))
                        {
                            TimeWhenPunchClockWasHit = DateTime.Now;
                            Point point = Points.FindByID(Employee.SendPointIdToday());
                            point.FinishPause = TimeWhenPunchClockWasHit;
                            Employee.TimesPunchClockAddition();
                        }
                        else
                        {
                            throw new Exception("Fora do horário de fim de pausa");
                        }
                    }
                        
                }
                else
                {
                    throw new Exception("Fora do horário de fim de pausa");
                }
            }
            else if (Employee.TimesPunchClockGetValue() == 3)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao sair: {Employee.WorkLoad.FinishTime.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao sair: {Employee.WorkLoad.FinishTime.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= Employee.WorkLoad.FinishTime.AddMinutes(-5)
                    && DateTime.Now <= Employee.WorkLoad.FinishTime.AddMinutes(5))
                {
                    TimeWhenPunchClockWasHit = DateTime.Now;
                    Employee.TimesPunchClockAddition();
                    Point point = Points.FindByID(Employee.SendPointIdToday());
                    point.FinishWorkLoad = TimeWhenPunchClockWasHit;
                    Employee.TimesPunchClockAddition();
                    Points.Update(point);
                }
                else
                {
                    throw new Exception("Fora do horário de saída");
                }
                CalcWorkedHours();
            }
        }

        private void CalcWorkedHours()
        {
            Point point = Points.FindByID(Employee.SendPointIdToday());
            DateTime startPause = Convert.ToDateTime(point.StartPause);
            DateTime finishPause = Convert.ToDateTime(point.FinishPause);
            DateTime finishWorkLoad = Convert.ToDateTime(point.FinishWorkLoad);
            TimeSpan calcWorkedHoursPrePause = startPause.Subtract(point.StartWorkLoad);
            DateTime convertCalcWorkedHoursPrePauseToDateTime = new DateTime(1996, 6, 3, 0, 0, 0);
            DateTime workedHoursPrePause = convertCalcWorkedHoursPrePauseToDateTime + calcWorkedHoursPrePause;
            TimeSpan calcWorkedHourPosPause = finishWorkLoad.Subtract(finishPause);
            DateTime convertCalcWorkedHoursPosPauseToDateTime = new DateTime(1996, 6, 3, 0, 0, 0);
            DateTime TodayWorkedHours = workedHoursPrePause + calcWorkedHourPosPause;
            Console.WriteLine($"Hoje seu tempo trabalhado foi: {TodayWorkedHours.ToString("H:mm:ss")}, parabéns!");
        }
    }
}