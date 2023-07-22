using System;

namespace ElectronicPointControl.Library
{
    public class Employee
    {
        public CPF CPF { get; set; }
        public string Name { get; set; }
        public string Registration { get; protected set; }
        public string Password { get; protected set; }
        public WorkLoad WorkLoad;

        private DateTime hourWhoStartToday;
        private DateTime hourWhoEndsToday;

        private int timesPunchClock = 0;
        private Guid  PointIDToday;

        public Employee(
            CPF cpf,
            string name,
            string registration,
            string password,
            WorkLoad workLoad)
        {
            this.CPF =cpf;
            this.Name=name;
            this.Registration=registration;
            this.Password=password;
            this.WorkLoad = workLoad;
        }

        public bool PasswordIsCorrect(string password)
        {
            return Password == password;
        }

        public override string ToString()
        {
            return $"{CPF};{Name};{Registration};{Password};{WorkLoad.StartHour};{WorkLoad.EndHour}";
        }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                    employee.Registration == Registration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Registration);
        }

        public void TimesPunchClockAddition()
        {
            timesPunchClock++;
        }

        public void TimesPunchClockReset()
        {
            timesPunchClock = 0;
        }

        public int TimesPunchClockGetValue()
        {
            return timesPunchClock;
        }

        public void GetHourWhoStartTodayValue(DateTime datetime)
        {
            hourWhoStartToday = datetime;
        }

        public void GetHourWhoEndsTodayValue(DateTime datetime)
        {
            hourWhoEndsToday = datetime;
        }

        public DateTime SendHourWhoStartTodayValue()
        {
            return hourWhoStartToday;
        }

        public DateTime SendHourWhoEndsTodayValue()
        {
            return hourWhoEndsToday;
        }

        public void GetPointIdToday(Guid ID)
        {
            PointIDToday = ID;
        }

        public Guid SendPointIdToday()
        {
            return PointIDToday;
        }
    
    }
}
