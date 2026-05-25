using Task5.Models;

namespace Task5.Services;

public static class AnimalPrinter
{
    public static void PrintAnimals(List<Animal> animals)
    {
        Console.WriteLine("Після десеріалізації:");

        foreach (Animal animal in animals)
        {
            Console.WriteLine($"Тип: {animal.GetType().Name}, ім'я: {animal.Name}");
        }
    }
}
