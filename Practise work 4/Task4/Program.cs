using System.Text;
using Task4.Models;
using Task4.Services;

namespace Task4;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        OrderStorage storage = new("order.json");
        Order order = new()
        {
            Id = 1,
            Status = OrderStatus.Processing
        };

        storage.SaveOrder(order);

        Console.WriteLine("Об'єкт Order серіалізовано у order.json.");
        Console.WriteLine("Enum збережено як текст:");
        Console.WriteLine(storage.ReadJson());

        Order? loadedOrder = storage.LoadOrder();
        Console.WriteLine();
        Console.WriteLine($"Після десеріалізації: Id = {loadedOrder?.Id}, Status = {loadedOrder?.Status}");
    }
}
