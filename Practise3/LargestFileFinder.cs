using System;
using System.IO;

namespace Practise3
{
    public static class LargestFileFinder
    {
        public static void FindLargest(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папку не знайдено.");
                return;
            }

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                Console.WriteLine("У папці та підпапках немає файлів.");
                return;
            }

            FileInfo? largest = null;

            foreach (string file in files)
            {
                FileInfo current = new FileInfo(file);

                if (largest == null || current.Length > largest.Length)
                {
                    largest = current;
                }
            }

            Console.WriteLine("\n===== Найбільший файл =====");
            Console.WriteLine("Name: " + largest!.Name);
            Console.WriteLine("Size: " + largest.Length + " байт");
            Console.WriteLine("Path: " + largest.FullName);
        }
    }
}