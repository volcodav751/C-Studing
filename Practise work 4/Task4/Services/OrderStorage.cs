using System.Text.Json;
using System.Text.Json.Serialization;
using Task4.Models;

namespace Task4.Services;

public class OrderStorage
{
    private readonly string filePath;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public OrderStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void SaveOrder(Order order)
    {
        string json = JsonSerializer.Serialize(order, options);
        File.WriteAllText(filePath, json);
    }

    public Order? LoadOrder()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Order>(json, options);
    }

    public string ReadJson()
    {
        return File.ReadAllText(filePath);
    }
}
