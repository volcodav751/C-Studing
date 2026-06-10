using AsyncDataLibrary.Attributes;

namespace AsyncDataLibrary.Infrastructure;

public class FileStorageProvider
{
    public FileStorageProvider(string basePath)
    {
        BasePath = basePath;
        Directory.CreateDirectory(BasePath);
    }

    public string BasePath { get; }

    public string GetFilePath<T>() where T : class
    {
        var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(StorageFileAttribute)) as StorageFileAttribute;
        string fileName = attribute?.FileName ?? $"{typeof(T).Name.ToLowerInvariant()}s.json";
        return Path.Combine(BasePath, fileName);
    }
}
