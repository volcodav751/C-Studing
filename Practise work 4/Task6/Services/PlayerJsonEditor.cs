namespace Task6.Services;

public static class PlayerJsonEditor
{
    public static void CreateFileWithoutInventory(string filePath)
    {
        const string jsonWithoutInventory = "{\n  \"Name\": \"PlayerOne\"\n}";
        File.WriteAllText(filePath, jsonWithoutInventory);
    }
}
