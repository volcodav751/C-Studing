using System;
using System.IO;
using System.Text;

namespace ModuleWork
{
    internal class FileProcessor
    {
        public static void ProcessFile(string inputFile, string outputFile, TextOperation operation, string operationName)
        {
            string[] lines = File.ReadAllLines(inputFile, Encoding.UTF8);

            using (StreamWriter writer = new StreamWriter(outputFile, true, Encoding.UTF8))
            {
                writer.WriteLine($"{operationName}");

                foreach (string line in lines)
                {
                    string result = operation(line);
                    writer.WriteLine($"Вхідний рядок: {line}");
                    writer.WriteLine($"Результат: {result}");
                    writer.WriteLine();
                }

                writer.WriteLine();
            }
        }
    }
}