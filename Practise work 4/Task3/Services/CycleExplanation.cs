namespace Task3.Services;

public static class CycleExplanation
{
    public static void PrintExplanation()
    {
        Console.WriteLine("Причина проблеми: Author має список Books, а кожен Book знову має Author.");
        Console.WriteLine("Так утворюється циклічне посилання Author -> Book -> Author.");
        Console.WriteLine("Виправлення: властивість Book.Author позначена атрибутом [JsonIgnore].");
        Console.WriteLine();
    }
}
