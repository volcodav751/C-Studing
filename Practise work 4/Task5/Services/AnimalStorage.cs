using System.Text.Json;
using Task5.Models;

namespace Task5.Services;

public class AnimalStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public AnimalStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void SaveAnimals(List<Animal> animals)
    {
        string json = JsonSerializer.Serialize(animals, options);
        File.WriteAllText(filePath, json);
    }

    public List<Animal> LoadAnimals()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Animal>>(json, options) ?? new List<Animal>();
    }

    public string ReadJson()
    {
        return File.ReadAllText(filePath);
    }
}
