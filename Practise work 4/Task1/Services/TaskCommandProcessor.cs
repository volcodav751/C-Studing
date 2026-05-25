namespace Task1.Services;

public class TaskCommandProcessor
{
    private const string AddTaskCommand = "1";
    private const string ChangeStatusCommand = "2";
    private const string ShowTasksCommand = "3";
    private const string ExitCommand = "4";

    private readonly TaskService taskService;
    private readonly TaskConsole taskConsole;

    public TaskCommandProcessor(TaskService taskService, TaskConsole taskConsole)
    {
        this.taskService = taskService;
        this.taskConsole = taskConsole;
    }

    public bool ProcessCommand(string command)
    {
        switch (command)
        {
            case AddTaskCommand:
                AddTask();
                return true;

            case ChangeStatusCommand:
                ChangeStatus();
                return true;

            case ShowTasksCommand:
                taskConsole.PrintTasks(taskService.GetTasks());
                return true;

            case ExitCommand:
                taskService.SaveTasks();
                Console.WriteLine("Дані збережено у файл tasks.json.");
                return false;

            default:
                Console.WriteLine("Неправильний вибір.");
                return true;
        }
    }

    private void AddTask()
    {
        string title = taskConsole.ReadTaskTitle();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Назва задачі не може бути порожньою.");
            return;
        }

        taskService.AddTask(title);
        Console.WriteLine("Задачу додано.");
    }

    private void ChangeStatus()
    {
        if (taskService.GetTasks().Count == 0)
        {
            Console.WriteLine("Список задач порожній.");
            return;
        }

        taskConsole.PrintTasks(taskService.GetTasks());
        int? taskNumber = taskConsole.ReadTaskNumber();

        if (taskNumber is null)
        {
            Console.WriteLine("Номер задачі введено неправильно.");
            return;
        }

        bool isChanged = taskService.ChangeTaskStatus(taskNumber.Value);
        Console.WriteLine(isChanged ? "Статус задачі змінено." : "Такої задачі немає.");
    }
}
