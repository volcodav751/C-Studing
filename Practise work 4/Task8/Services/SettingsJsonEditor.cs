namespace Task8.Services;

public static class SettingsJsonEditor
{
    public static void CreateBrokenSettingsFile(string filePath)
    {
        const string brokenJson = "{ \"UserName\": \"Maxim\", \"Theme\": ";
        File.WriteAllText(filePath, brokenJson);
    }
}
