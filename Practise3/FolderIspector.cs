using System;
using System.IO;

namespace Practise3
{
    public class FolderIspector
    {
        public static void Inspect(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папку не знайдено.");
                return;
            }

            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);

            Console.WriteLine("\n===== Файли =====");
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine(
                    $"{fileInfo.Name} - створено: {fileInfo.CreationTime}, розмір: {fileInfo.Length} байт");
            }

            Console.WriteLine("\n===== Підпапки =====");
            foreach (string dir in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                Console.WriteLine($"{dirInfo.Name} - створено: {dirInfo.CreationTime}");
            }
        }
    }
}