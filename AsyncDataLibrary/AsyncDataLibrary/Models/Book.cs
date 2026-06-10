using AsyncDataLibrary.Attributes;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Models;

[StorageFile("books.json")]
public class Book : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public bool IsAvailable { get; set; } = true;
}
