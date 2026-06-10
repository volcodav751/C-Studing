using System.Text;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class BookProcessing
{
    public List<Book> ListBook { get; } = new();

    public void CreateBook(int id, string title, string author)
    {
        Book book = new()
        {
            Id = id,
            Title = title,
            Author = author
        };

        ListBook.Add(book);
    }

    public string PrintAllBooks()
    {
        if (ListBook.Count == 0)
        {
            return "Книг не знайдено";
        }

        StringBuilder result = new();
        foreach (Book book in ListBook)
        {
            result.AppendLine($"Книга {book.Id}: {book.Title}, автор: {book.Author}");
        }

        return result.ToString();
    }

    public Task<string> PrintAllBooksAsync()
    {
        return Task.FromResult(PrintAllBooks());
    }

    public bool DeleteBook(int bookId)
    {
        Book? book = ListBook.FirstOrDefault(item => item.Id == bookId);
        if (book is null)
        {
            return false;
        }

        ListBook.Remove(book);
        return true;
    }
}
