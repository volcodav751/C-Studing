using System.Text;
using Task2.Models;
using Task2.Services;

namespace Task2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        StudentStorage storage = new("students.json");
        List<Student> students = StudentFactory.CreateDefaultStudents();

        storage.SaveStudents(students);
        Console.WriteLine("Список студентів серіалізовано у students.json.");

        List<Student> loadedStudents = storage.LoadStudents();
        StudentPrinter.PrintStudents(loadedStudents);
    }
}
