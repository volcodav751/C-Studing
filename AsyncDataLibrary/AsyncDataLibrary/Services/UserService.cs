using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class UserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public User? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    public void Add(User user)
    {
        Validate(user);
        _repository.Add(user);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        Validate(user);
        await _repository.AddAsync(user, cancellationToken);
    }

    public bool Update(User user)
    {
        Validate(user);
        return _repository.Update(user);
    }

    public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        Validate(user);
        return await _repository.UpdateAsync(user, cancellationToken);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }

    private static void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FullName))
        {
            throw new ArgumentException("ПІБ користувача не може бути порожнім.");
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            throw new ArgumentException("Email користувача не може бути порожнім.");
        }
    }
}
