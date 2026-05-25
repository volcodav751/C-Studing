using System.Text;
using Task6.Models;
using Task6.Services;

namespace Task6;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        const string normalFilePath = "player.json";
        const string fileWithoutInventoryPath = "player_without_inventory.json";

        PlayerStorage storage = new();
        Player player = PlayerFactory.CreatePlayer();

        storage.SavePlayer(normalFilePath, player);
        Console.WriteLine("Повний об'єкт Player збережено у player.json.");

        PlayerJsonEditor.CreateFileWithoutInventory(fileWithoutInventoryPath);
        Player loadedPlayer = storage.LoadPlayer(fileWithoutInventoryPath);

        loadedPlayer.Inventory ??= new Inventory();

        Console.WriteLine("Завантажено JSON без поля Inventory.");
        Console.WriteLine($"Гравець: {loadedPlayer.Name}");
        Console.WriteLine($"Кількість предметів в інвентарі: {loadedPlayer.Inventory.Items.Count}");
    }
}
