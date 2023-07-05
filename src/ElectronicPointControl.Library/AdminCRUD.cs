using System.Collections.Generic;
using System.Linq;

namespace ElectronicPointControl.Library
{
    public class AdminCRUD
    {
        private Dictionary<string, Administrator> administrators = new();

        public void Add(Administrator administrator) => administrators.Add(administrator.Registration, administrator);

        public Administrator Get(string registration) => administrators.GetValueOrDefault(registration);

        public List<Administrator> GetAll() => administrators.Values.ToList();

        public void Update(Administrator administrator)
        {
            Delete(administrator.Registration);
            Add(administrator);
        }

        public void Delete(string registration) => administrators.Remove(registration);
    }
}
