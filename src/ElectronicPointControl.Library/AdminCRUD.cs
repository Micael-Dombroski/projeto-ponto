using System.IO;

namespace ElectronicPointControl.Library
{
    public class AdminCRUD
    {
        private string filePath;

        public AdminCRUD(string filePath
                = "../ElectronicPointControl.Library/Database/administrator.txt")
        {
            this.filePath = filePath;
            if (!File.Exists(filePath))
            {
                Stream file = File.Open(filePath, FileMode.Create);
                file.Close();
            }
        }

        public void Add(Administrator administrator)
        {
            using (Stream file = File.Open(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new(file))
                {
                    writer.WriteLine(administrator);
                }
            }
        }

        public Administrator Get()
        {
            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                using (StreamReader reader = new(file))
                {
                    var line = reader.ReadLine();
                    if (line is null)
                        return null;

                    var props = line.Split(";");
                    return new Administrator(login: props[0], password: props[1]);
                }
            }
        }

        public void Update(Administrator administrator)
        {
            Delete();
            Add(administrator);
        }

        public void Delete()
        {
            using (Stream file = File.Open(filePath, FileMode.Create))
            {
            }
        }
    }
}
