using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;
namespace DeleteIfOld
{
    class Delete
    {
        public void ControlAndDelete()
        {
            var path = ConfigurationManager.AppSettings["FilePath"];
            var Year = ConfigurationManager.AppSettings["Year"];
            int i = 0;

            if (!(Directory.Exists(path)))
            {
                Console.WriteLine("Bu isimde bir klasör yok");
                return;
            }

            if (!(int.TryParse(Year,out i)))
            {
                Console.WriteLine("Sayı doğru formtta girilmedi");
                return;
            }
            int y = Int32.Parse(Year);
            var now = DateTime.Now;
            string[] files = Directory.GetFiles(path);

            foreach (string fileName in files)
            {
                DateTime lastWriteTime = File.GetLastWriteTime(fileName);
                DateTime FewYears = lastWriteTime.AddYears(y);
                if (FewYears < now)
                {
                    File.Delete(fileName);
                }
            }
           
        }
    }
}
