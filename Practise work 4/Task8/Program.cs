using System.Text;
using Task8.Models;
using Task8.Services;

namespace Task8;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        const string correctFilePath = "settings.json";
        const string brokenFilePath = "broken_settings.json";

        SettingsStorage storage = new();
        UserSettings settings = new()
        {
            UserName = "Maxim",
            Theme = "Dark"
        };

        storage.SaveSettings(correctFilePath, settings);
        Console.WriteLine("Коректний файл settings.json створено.");

        SettingsJsonEditor.CreateBrokenSettingsFile(brokenFilePath);
        UserSettings loadedSettings = storage.LoadSettingsSafely(brokenFilePath);

        Console.WriteLine();
        Console.WriteLine("Налаштування після безпечного завантаження:");
        Console.WriteLine($"UserName = {loadedSettings.UserName}");
        Console.WriteLine($"Theme = {loadedSettings.Theme}");
    }
}
