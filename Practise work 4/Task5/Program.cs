using System.Text;
using Task5.Models;
using Task5.Services;

namespace Task5;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        AnimalStorage storage = new("animals.json");
        List<Animal> animals = AnimalFactory.CreateAnimals();

        storage.SaveAnimals(animals);

        Console.WriteLine("Список Animal серіалізовано у animals.json.");
        Console.WriteLine("Поле $type потрібне, щоб після десеріалізації не втратити Dog і Cat.");
        Console.WriteLine(storage.ReadJson());
        Console.WriteLine();

        List<Animal> loadedAnimals = storage.LoadAnimals();
        AnimalPrinter.PrintAnimals(loadedAnimals);
    }
}
