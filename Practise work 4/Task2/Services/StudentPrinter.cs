using Task2.Models;

namespace Task2.Services;

public static class StudentPrinter
{
    public static void PrintStudents(List<Student> students)
    {
        Console.WriteLine();
        Console.WriteLine("Дані після десеріалізації:");

        foreach (Student student in students)
        {
            Console.WriteLine($"Ім'я: {student.Name}, вік: {student.Age}, середній бал: {student.AverageScore}");
        }
    }
}
