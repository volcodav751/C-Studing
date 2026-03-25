using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ModuleWork
{
    public delegate string TextOperation(string line);

    public class TextOperate
    {
        public static string ToUpperCase(string line)
        {
            return line.ToUpper();
        }
        public static int CountSymbols(string line)
        {
            int SCount = line.Length;
            return SCount;
        }
        public static int CountWords(string line)
        {
            string[] words = line.Split(" ");
            return words.Length;
        }
    }
}
