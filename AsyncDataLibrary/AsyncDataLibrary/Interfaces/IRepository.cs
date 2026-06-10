namespace AsyncDataLibrary.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    List<T> GetAll();
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    T? GetById(int id);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(T item);
    Task AddAsync(T item, CancellationToken cancellationToken = default);

    bool Update(T item);
    Task<bool> UpdateAsync(T item, CancellationToken cancellationToken = default);

    bool Delete(int id);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
