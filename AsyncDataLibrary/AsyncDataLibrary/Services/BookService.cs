using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class BookService
{
    private readonly IRepository<Book> _repository;

    public BookService(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public List<Book> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Book? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    public void Add(Book book)
    {
        Validate(book);
        _repository.Add(book);
    }

    public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        Validate(book);
        await _repository.AddAsync(book, cancellationToken);
    }

    public bool Update(Book book)
    {
        Validate(book);
        return _repository.Update(book);
    }

    public async Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken = default)
    {
        Validate(book);
        return await _repository.UpdateAsync(book, cancellationToken);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }

    public List<Book> SearchByTitle(string titlePart)
    {
        return _repository.GetAll()
            .Where(book => book.Title.Contains(titlePart, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private static void Validate(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
        {
            throw new ArgumentException("Назва книги не може бути порожньою.");
        }

        if (string.IsNullOrWhiteSpace(book.Author))
        {
            throw new ArgumentException("Автор книги не може бути порожнім.");
        }
    }
}
