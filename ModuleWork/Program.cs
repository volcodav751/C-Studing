using System.Text;
using System.IO;

namespace ModuleWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "C:\\Users\\maxim\\Documents\\С#Studing\\ModuleWork\\textPD21.txt";
            string resultFile = "C:\\Users\\maxim\\Documents\\С#Studing\\ModuleWork\\resultPD21.txt";

            File.WriteAllText(resultFile, "", Encoding.UTF8);

            FileProcessor.ProcessFile(inputFile, resultFile, TextOperate.ToUpperCase, "UPPERCASE");
            FileProcessor.ProcessFile(inputFile, resultFile, line => TextOperate.CountSymbols(line).ToString(), "КІЛЬКІСТЬ СИМВОЛІВ");
            FileProcessor.ProcessFile(inputFile, resultFile, line => TextOperate.CountWords(line).ToString(), "КІЛЬКІСТЬ СЛІВ");

            Console.WriteLine("Готово. Результат записано у resultPD21.txt");
        }
    }
}