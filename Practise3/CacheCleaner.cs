using System;
using System.Collections.Generic;
using System.IO;

namespace Practise3
{
    public static class CacheCleaner
    {
        public static CleanupResult CleanRecursive(string path)
        {
            CleanupResult result = new CleanupResult();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папку не знайдено.");
                return result;
            }

            CleanRecursiveInternal(path, result);
            return result;
        }

        private static void CleanRecursiveInternal(string path, CleanupResult result)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                result.TotalBytesDeleted += info.Length;
                result.FilesDeleted++;
                File.Delete(file);
            }

            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                CleanRecursiveInternal(dir, result);
            }
        }

        public static CleanupResult CleanWithoutRecursion(string path)
        {
            CleanupResult result = new CleanupResult();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папку не знайдено.");
                return result;
            }

            Stack<string> stack = new Stack<string>();
            stack.Push(path);

            while (stack.Count > 0)
            {
                string current = stack.Pop();

                foreach (string file in Directory.GetFiles(current))
                {
                    FileInfo info = new FileInfo(file);
                    result.TotalBytesDeleted += info.Length;
                    result.FilesDeleted++;
                    File.Delete(file);
                }

                foreach (string dir in Directory.GetDirectories(current))
                {
                    stack.Push(dir);
                }
            }

            return result;
        }
    }
}