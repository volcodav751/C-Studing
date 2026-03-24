using System;
using System.IO;
using System.Text;

namespace Practise3
{
    internal class FileAnalizer
    {
        public static void Analize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            int lineCount = 0;
            int symbolCount = 0;
            int wordCount = 0;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    symbolCount += line.Length;

                    string[] words = line.Split(
                        new char[] { ' ', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);

                    wordCount += words.Length;
                }
            }

            string report =
                $"Аналіз файлу: {fileName}\n" +
                $"Кількість рядків: {lineCount}\n" +
                $"Кількість слів: {wordCount}\n" +
                $"Кількість символів: {symbolCount}\n";

            string folder = Path.GetDirectoryName(fileName) ?? Environment.CurrentDirectory;
            string reportPath = Path.Combine(folder, "report.txt");

            File.WriteAllText(reportPath, report, Encoding.UTF8);

            Console.WriteLine(report);
            Console.WriteLine("Результат записано у: " + reportPath);
        }
    }
}