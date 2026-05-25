using System.Text.Json;
using Task1.Models;

namespace Task1.Services;

public class TaskStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public TaskStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public List<TaskItem> LoadTasks()
    {
        if (!File.Exists(filePath))
        {
            return new List<TaskItem>();
        }

        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json, options) ?? new List<TaskItem>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Файл tasks.json пошкоджений. Створено новий список задач.");
            return new List<TaskItem>();
        }
    }

    public void SaveTasks(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(filePath, json);
    }
}
