using Task5.Models;

namespace Task5.Services;

public static class AnimalFactory
{
    public static List<Animal> CreateAnimals()
    {
        return new List<Animal>
        {
            new Dog { Name = "Барсик", BarkVolume = 8 },
            new Cat { Name = "Мурка", Lives = 9 }
        };
    }
}
