using Task1.Models;

namespace Task1.Services;

public class TaskConsole
{
    public void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== TASK TRACKER =====");
        Console.WriteLine("1. Додати задачу");
        Console.WriteLine("2. Змінити статус задачі");
        Console.WriteLine("3. Переглянути список задач");
        Console.WriteLine("4. Вийти");
        Console.Write("Ваш вибір: ");
    }

    public string ReadCommand()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public string ReadTaskTitle()
    {
        Console.Write("Введіть назву задачі: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public int? ReadTaskNumber()
    {
        Console.Write("Введіть номер задачі: ");

        if (!int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            return null;
        }

        return taskNumber;
    }

    public void PrintTasks(IReadOnlyList<TaskItem> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач порожній.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Список задач:");

        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "Виконано" : "Не виконано";
            Console.WriteLine($"{i + 1}. {tasks[i].Title} - {status}");
        }
    }
}
