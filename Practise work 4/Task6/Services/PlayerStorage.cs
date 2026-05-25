using System.Text.Json;
using Task6.Models;

namespace Task6.Services;

public class PlayerStorage
{
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public void SavePlayer(string filePath, Player player)
    {
        string json = JsonSerializer.Serialize(player, options);
        File.WriteAllText(filePath, json);
    }

    public Player LoadPlayer(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Player>(json, options) ?? new Player();
    }
}
