namespace Ponto.Classes
{
    public class Employee : User
    {
        public WorkLoad WorkLoad;
        private DateTime hourWhoStartToday;
        private DateTime hourWhoEndsToday;

        private int timesPunchClock = 0;

        public Employee(
            CPF cpf,
            string name,
            string registration,
            string password,
            WorkLoad workLoad) : base(cpf, name, registration, password)
        {
            this.WorkLoad = workLoad;
        }

        public Employee()
        {
        }

        public void PunchClock()
        {
            if (timesPunchClock == 2)
                timesPunchClock = 0;

            PunchClock();
            
            if (timesPunchClock == 0)
            {
                if (DateTime.Now == workLoad.StartHour || DateTime.Now < workLoad.StartHour.AddMinutes(5))
                {
                    hourWhoStartToday = DateTime.Now;
                    timesPunchClock++;
                }
                else 
                {
                    throw new Exception("fora do horario");
                }
            }
            else if (timesPunchClock == 1)
            {
                if (DateTime.Now == workLoad.EndHour || DateTime.Now < workLoad.StartHour.RemoveMinutes(5))
                {
                    hourWhoEndsToday = DateTime.Now;
                    timesPunchClock++;
                }
                else 
                {
                    throw new Exception("fora do horario");
                }
            }
        }

        public int CalcWorkedHours()
        {
            return hourWhoEndsToday.Hour - hourWhoStartToday.Hour;
        }
    }
}
