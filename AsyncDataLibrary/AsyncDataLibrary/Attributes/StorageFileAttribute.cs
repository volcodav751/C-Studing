namespace AsyncDataLibrary.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class StorageFileAttribute : Attribute
{
    public StorageFileAttribute(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
}
