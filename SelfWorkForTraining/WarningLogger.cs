using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.IO.Enumeration;

namespace SelfWorkForTraining
{
    internal class WarningLogger
    {
        public string filename;
        public event Action<string>?  FileWarning;
        public void WarningLog(string fileName) 
        {

            string warning;
            if (string.IsNullOrEmpty(fileName))
            {
                warning = "Файл " + fileName + "Пустий";
                File.WriteAllText("warning.txt", warning);
            }    
            
        }
        public void SendWarning()
        {
            Console.WriteLine($"Файл {fileName}");
        }
    }
}
