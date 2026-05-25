using System.Text.Json;
using Task3.Models;

namespace Task3.Services;

public class AuthorStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public AuthorStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void SaveAuthor(Author author)
    {
        string json = JsonSerializer.Serialize(author, options);
        File.WriteAllText(filePath, json);
    }

    public string ReadJson()
    {
        return File.ReadAllText(filePath);
    }
}
