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

        public void PunchClock()
        {
            if (timesPunchClock == 2)
                timesPunchClock = 0;


            if (timesPunchClock == 0)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao entrar: {WorkLoad.StartHour.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao entrar: {WorkLoad.StartHour.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= WorkLoad.StartHour.AddMinutes(-5) && DateTime.Now <= WorkLoad.StartHour.AddMinutes(5))
                {
                    hourWhoStartToday = DateTime.Now;
                    timesPunchClock++;
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
            }
            else if (timesPunchClock == 1)
            {
                Console.WriteLine($"Horário Mínimo permitido para bater ponto ao sair: {WorkLoad.EndHour.AddMinutes(-5).ToString("H:mm:ss")}");
                Console.WriteLine($"Horário Limite permitido para bater ponto ao sair: {WorkLoad.EndHour.AddMinutes(5).ToString("H:mm:ss")}");
                if (DateTime.Now >= WorkLoad.EndHour.AddMinutes(-5)
                    && DateTime.Now <= WorkLoad.EndHour.AddMinutes(5))
                {
                    hourWhoEndsToday = DateTime.Now;
                    timesPunchClock++;
                }
                else
                {
                    throw new Exception("Fora do horario");
                }
                CalcWorkedHours();
            }
        }

        public void CalcWorkedHours()
        {
            TimeSpan WorkedHours = hourWhoEndsToday.Subtract(hourWhoStartToday);
            DateTime IgnoreIt = new DateTime(1996, 6, 3, 0, 0, 0);
            DateTime workedHours = IgnoreIt + WorkedHours;
            Console.WriteLine($"Hoje seu tempo trabalhado foi: {workedHours.ToString("H:mm:ss")}, parabéns!");
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
    }
}
