using System.Text.Json;
using Task2.Models;

namespace Task2.Services;

public class StudentStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public StudentStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void SaveStudents(List<Student> students)
    {
        string json = JsonSerializer.Serialize(students, options);
        File.WriteAllText(filePath, json);
    }

    public List<Student> LoadStudents()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Student>>(json, options) ?? new List<Student>();
    }
}
