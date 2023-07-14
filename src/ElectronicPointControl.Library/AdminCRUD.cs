using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicPointControl.Library
{
    public class AdminCRUD
    {
        private const string filePath
            = "/home/natan/www/jp/projeto-ponto/src/ElectronicPointControl.Library/administrators.txt";

        private Dictionary<string, Administrator> administrators = new();

        public void Add(Administrator administrator)
        {
            if (!File.Exists(filePath))
            {
                Stream file = File.Open(filePath, FileMode.Create);
                file.Close();
            }
            using (Stream file = File.Open(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new(file))
                {
                    writer.WriteLine(administrator);
                }
            }
        }
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
