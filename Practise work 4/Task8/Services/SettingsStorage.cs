using System.Text.Json;
using Task8.Models;

namespace Task8.Services;

public class SettingsStorage
{
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public void SaveSettings(string filePath, UserSettings settings)
    {
        string json = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(filePath, json);
    }

    public UserSettings LoadSettingsSafely(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<UserSettings>(json, options) ?? new UserSettings();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не знайдено. Створено стандартні налаштування.");
            return new UserSettings();
        }
        catch (JsonException)
        {
            Console.WriteLine("JSON-файл пошкоджений. Програма продовжує роботу зі стандартними налаштуваннями.");
            return new UserSettings();
        }
    }
}
