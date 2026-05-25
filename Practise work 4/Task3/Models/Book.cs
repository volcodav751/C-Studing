using System.Text.Json.Serialization;

namespace Task3.Models;

public class Book
{
    public string Title { get; set; } = string.Empty;

    [JsonIgnore]
    public Author? Author { get; set; }
}
