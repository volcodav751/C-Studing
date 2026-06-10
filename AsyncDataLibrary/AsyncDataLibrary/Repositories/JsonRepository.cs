using System.Text.Json;
using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Repositories;

public class JsonRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly IDataSerializer _serializer;
    private readonly string _filePath;
    private readonly object _syncLock = new();

    public JsonRepository(FileStorageProvider storageProvider, IDataSerializer serializer)
    {
        _serializer = serializer;
        _filePath = storageProvider.GetFilePath<T>();
    }

    public List<T> GetAll()
    {
        lock (_syncLock)
        {
            return Load();
        }
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await LoadAsync(cancellationToken);
    }

    public T? GetById(int id)
    {
        return GetAll().FirstOrDefault(item => item.Id == id);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var items = await GetAllAsync(cancellationToken);
        return items.FirstOrDefault(item => item.Id == id);
    }

    public void Add(T item)
    {
        lock (_syncLock)
        {
            var items = Load();
            PrepareId(item, items);
            items.Add(item);
            Save(items);
        }
    }

    public async Task AddAsync(T item, CancellationToken cancellationToken = default)
    {
        var items = await LoadAsync(cancellationToken);
        PrepareId(item, items);
        items.Add(item);
        await SaveAsync(items, cancellationToken);
    }

    public bool Update(T item)
    {
        lock (_syncLock)
        {
            var items = Load();
            int index = items.FindIndex(existing => existing.Id == item.Id);
            if (index < 0)
            {
                return false;
            }

            items[index] = item;
            Save(items);
            return true;
        }
    }

    public async Task<bool> UpdateAsync(T item, CancellationToken cancellationToken = default)
    {
        var items = await LoadAsync(cancellationToken);
        int index = items.FindIndex(existing => existing.Id == item.Id);
        if (index < 0)
        {
            return false;
        }

        items[index] = item;
        await SaveAsync(items, cancellationToken);
        return true;
    }

    public bool Delete(int id)
    {
        lock (_syncLock)
        {
            var items = Load();
            T? item = items.FirstOrDefault(existing => existing.Id == id);
            if (item is null)
            {
                return false;
            }

            items.Remove(item);
            Save(items);
            return true;
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var items = await LoadAsync(cancellationToken);
        T? item = items.FirstOrDefault(existing => existing.Id == id);
        if (item is null)
        {
            return false;
        }

        items.Remove(item);
        await SaveAsync(items, cancellationToken);
        return true;
    }

    private List<T> Load()
    {
        try
        {
            return _serializer.ReadFromFile<List<T>>(_filePath) ?? new List<T>();
        }
        catch (JsonException)
        {
            return new List<T>();
        }
        catch (IOException)
        {
            return new List<T>();
        }
    }

    private async Task<List<T>> LoadAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _serializer.ReadFromFileAsync<List<T>>(_filePath, cancellationToken) ?? new List<T>();
        }
        catch (JsonException)
        {
            return new List<T>();
        }
        catch (IOException)
        {
            return new List<T>();
        }
    }

    private void Save(List<T> items)
    {
        _serializer.WriteToFile(_filePath, items);
    }

    private async Task SaveAsync(List<T> items, CancellationToken cancellationToken)
    {
        await _serializer.WriteToFileAsync(_filePath, items, cancellationToken);
    }

    private static void PrepareId(T item, List<T> items)
    {
        if (item.Id <= 0)
        {
            item.Id = items.Count == 0 ? 1 : items.Max(existing => existing.Id) + 1;
            return;
        }

        if (items.Any(existing => existing.Id == item.Id))
        {
            throw new InvalidOperationException($"Об'єкт з Id {item.Id} вже існує.");
        }
    }
}
