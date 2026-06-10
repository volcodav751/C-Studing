using System.Text.Json;
using System.Text.Json.Serialization;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Infrastructure;

public class JsonDataSerializer : IDataSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public JsonDataSerializer()
    {
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    public string Serialize<T>(T data)
    {
        return JsonSerializer.Serialize(data, _options);
    }

    public T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public void WriteToFile<T>(string path, T data)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = Serialize(data);
        File.WriteAllText(path, json);
    }

    public T? ReadFromFile<T>(string path)
    {
        if (!File.Exists(path))
        {
            return default;
        }

        string json = File.ReadAllText(path);
        return Deserialize<T>(json);
    }

    public async Task WriteToFileAsync<T>(string path, T data, CancellationToken cancellationToken = default)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = Serialize(data);
        await File.WriteAllTextAsync(path, json, cancellationToken);
    }

    public async Task<T?> ReadFromFileAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            return default;
        }

        string json = await File.ReadAllTextAsync(path, cancellationToken);
        return Deserialize<T>(json);
    }
}
