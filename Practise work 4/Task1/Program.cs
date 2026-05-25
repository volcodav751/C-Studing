using System.Text;
using Task1.Services;

namespace Task1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        TaskStorage storage = new("tasks.json");
        TaskService taskService = new(storage);
        TaskConsole taskConsole = new();
        TaskCommandProcessor commandProcessor = new(taskService, taskConsole);

        bool isWorking = true;

        while (isWorking)
        {
            taskConsole.ShowMenu();
            string command = taskConsole.ReadCommand();
            isWorking = commandProcessor.ProcessCommand(command);
        }
    }
}
