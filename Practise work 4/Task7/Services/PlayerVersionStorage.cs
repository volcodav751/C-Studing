using System.Text.Json;
using Task7.Models;

namespace Task7.Services;

public class PlayerVersionStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public PlayerVersionStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void CreateOldJsonFile()
    {
        const string oldJson = "{\n  \"Name\": \"OldPlayer\"\n}";
        File.WriteAllText(filePath, oldJson);
    }

    public Player LoadPlayerWithNewModel()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Player>(json, options) ?? new Player();
    }

    public string ReadJson()
    {
        return File.ReadAllText(filePath);
    }
}
