namespace PractiseWork6;

public class Program
{
    private const int DelayMs = 1000;

    static void Main()
    {
        Counter counter = new Counter();
        CommandMethods commandMethods = new CommandMethods(counter);
        ReadingCommand readingCommand = new ReadingCommand(commandMethods);

        Thread readingThread = new Thread(readingCommand.ReadCommands);
        readingThread.Start();

        Console.WriteLine("Команди:");
        Console.WriteLine("p - пауза / продовження");
        Console.WriteLine("r - скинути лічильник");
        Console.WriteLine("c - змінити колір");
        Console.WriteLine("q - завершити програму");
        Console.WriteLine();

        while (counter.IsRunning)
        {
            if (!counter.IsPaused)
            {
                counter.Increase();

                Console.ForegroundColor = counter.CurrentColor;
                Console.WriteLine($"Counter: {counter.Value}");
                Console.ResetColor();
            }

            Thread.Sleep(DelayMs);
        }

        Console.WriteLine("Програму завершено.");
    }
}