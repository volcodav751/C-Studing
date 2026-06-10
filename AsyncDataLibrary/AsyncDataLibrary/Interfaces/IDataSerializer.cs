namespace AsyncDataLibrary.Interfaces;

public interface IDataSerializer
{
    string Serialize<T>(T data);
    T? Deserialize<T>(string json);

    void WriteToFile<T>(string path, T data);
    T? ReadFromFile<T>(string path);

    Task WriteToFileAsync<T>(string path, T data, CancellationToken cancellationToken = default);
    Task<T?> ReadFromFileAsync<T>(string path, CancellationToken cancellationToken = default);
}
