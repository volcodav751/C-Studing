using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2_PD21
{
    internal class FileLogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void LogMessage(string message)
        {
            string log = $"[{DateTime.Now:HH:mm:ss}] {message} {Environment.NewLine}";
            File.AppendAllText(_filePath, log, Encoding.UTF8);
        }
    }
}
