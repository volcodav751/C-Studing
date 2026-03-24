using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SelfWorkForTraining
{
    public class FileProcessor
    {
        static string Path;
        public FileProcessor(string path) 
        { 
            Path=path;
        }
        
        public static void FileAnalyze(string path) 
        {
            string[] files = Directory.GetFiles(path,"*.txt");
            foreach(string file in files)    
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine(fileInfo.FullName);
                FileRead.FileReader(file);
            } 
        }
        
    }
}
