using AsyncDataLibrary.Attributes;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Models;

[StorageFile("users.json")]
public class User : IEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
