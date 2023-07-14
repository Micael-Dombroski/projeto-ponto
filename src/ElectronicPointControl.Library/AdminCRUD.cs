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
        public Administrator Get(string registration)
        {
            List<Administrator> admins = new();
            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                using (StreamReader reader = new(file))
                {
                    var line = reader.ReadLine().Trim();
                    while (line != null)
                    {
                        var props = line.Split(";");
                        Administrator admin = new(
                                cpf: new CPF(props[0]),
                                name: props[1],
                                registration: props[2],
                                password: props[3]);
                        admins.Add(admin);
                        line = reader.ReadLine();
                    }
                }
            }
            foreach (var admin in admins)
                if (admin.Registration == registration)
                    return admin;

            return null;
        }

        public List<Administrator> GetAll()
        {
            List<Administrator> admins = new();

            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                using (StreamReader reader = new(file))
                {
                    var line = reader.ReadLine().Trim();
                    while (line != null)
                    {
                        var props = line.Split(";");
                        Administrator admin = new(
                                cpf: new CPF(props[0]),
                                name: props[1],
                                registration: props[2],
                                password: props[3]);
                        admins.Add(admin);
                        line = reader.ReadLine();
                    }
                }
            }
            return admins;
        }
        public void Update(Administrator administrator)
        {
            Delete(administrator.Registration);
            Add(administrator);
        }

        public void Delete(string registration) => administrators.Remove(registration);
    }
}
