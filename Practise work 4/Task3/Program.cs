using System.Text;
using Task3.Models;
using Task3.Services;

namespace Task3;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        AuthorStorage storage = new("author.json");
        Author author = AuthorFactory.CreateAuthorWithBooks();

        CycleExplanation.PrintExplanation();
        storage.SaveAuthor(author);

        Console.WriteLine("Автор серіалізований у файл author.json.");
        Console.WriteLine("JSON після виправлення:");
        Console.WriteLine(storage.ReadJson());
    }
}
