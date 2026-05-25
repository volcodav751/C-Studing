using System.Text;
using Task7.Models;
using Task7.Services;

namespace Task7;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        PlayerVersionStorage storage = new("old_player.json");

        storage.CreateOldJsonFile();

        Console.WriteLine("Старий JSON без поля Level:");
        Console.WriteLine(storage.ReadJson());
        Console.WriteLine();

        Player player = storage.LoadPlayerWithNewModel();

        Console.WriteLine("Після завантаження у нову модель:");
        Console.WriteLine($"Name = {player.Name}");
        Console.WriteLine($"Level = {player.Level}");
        Console.WriteLine("Якщо старий файл не має нового поля, використовується значення за замовчуванням.");
    }
}
