using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    public class AdminCRUD
    {
        private Dictionary<String, Administrator> administrators = new();

        public void Add(Administrator administrator)
        {
            administrators.Add(administrator.Registration, administrator);
        }

        public Administrator Get(string registration)
        {
            return administrators.GetValueOrDefault(registration);
        }

        public List<Administrator> GetAll()
        {
            return administrators.Values.ToList();
        }

        public void Update(Administrator administrator)
        {
            Delete(administrator.Registration);
            Add(administrator);
        }

        public void Delete(string registration)
        {
            administrators.Remove(registration);
        }
    }
}