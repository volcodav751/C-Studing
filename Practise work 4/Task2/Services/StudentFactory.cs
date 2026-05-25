using Task2.Models;

namespace Task2.Services;

public static class StudentFactory
{
    public static List<Student> CreateDefaultStudents()
    {
        return new List<Student>
        {
            new() { Name = "Максим", Age = 18, AverageScore = 88.5 },
            new() { Name = "Ірина", Age = 19, AverageScore = 91.2 },
            new() { Name = "Олег", Age = 18, AverageScore = 76.4 },
            new() { Name = "Анна", Age = 20, AverageScore = 84.7 },
            new() { Name = "Дмитро", Age = 19, AverageScore = 79.9 }
        };
    }
}
