using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SelfWorkForTraining
{
    public class FileRead
    {
        public delegate void FileAnalyzer(string path);
        public event Action<string>? FileWarning;
        public static void FileReader (string fileName)
        {
            int lineCount = 0;
            int symbolCount = 0;
            int wordCount = 0;

            using (StreamReader sr = new StreamReader(fileName))
            {
                
                string? line;
                while((line = sr.ReadLine()) != null)
                {
                    lineCount++;                        
                    string[] word = line.Split(" ");
                    symbolCount += line.Length;

                    foreach (string w in word)
                    {
                        wordCount++;
                    }

                    symbolCount++;
                    wordCount++;
                    
                }
            }
            if (wordCount <= 3 || symbolCount == 0) 
            {
                WarningLogger.
            }
            string report =
                $"Аналіз файлу: {fileName}\n" +
                $"Кількість рядків: {lineCount}\n" +
                $"Кількість слів: {wordCount}\n" +
                $"Кількість символів: {symbolCount}\n";
            Console.WriteLine(report);
            File.WriteAllText("repor", report);
        }
    }
}
