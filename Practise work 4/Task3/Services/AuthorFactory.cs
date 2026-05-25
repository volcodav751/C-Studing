using Task3.Models;

namespace Task3.Services;

public static class AuthorFactory
{
    public static Author CreateAuthorWithBooks()
    {
        Author author = new()
        {
            Name = "Тарас Шевченко"
        };

        Book firstBook = new()
        {
            Title = "Кобзар",
            Author = author
        };

        Book secondBook = new()
        {
            Title = "Гайдамаки",
            Author = author
        };

        author.Books.Add(firstBook);
        author.Books.Add(secondBook);

        return author;
    }
}
