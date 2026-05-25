using Task1.Models;

namespace Task1.Services;

public class TaskService
{
    private readonly TaskStorage storage;
    private readonly List<TaskItem> tasks;

    public TaskService(TaskStorage storage)
    {
        this.storage = storage;
        tasks = storage.LoadTasks();
    }

    public IReadOnlyList<TaskItem> GetTasks()
    {
        return tasks;
    }

    public void AddTask(string title)
    {
        tasks.Add(new TaskItem
        {
            Title = title,
            IsCompleted = false
        });
    }

    public bool ChangeTaskStatus(int taskNumber)
    {
        int index = taskNumber - 1;

        if (index < 0 || index >= tasks.Count)
        {
            return false;
        }

        tasks[index].IsCompleted = !tasks[index].IsCompleted;
        return true;
    }

    public void SaveTasks()
    {
        storage.SaveTasks(tasks);
    }
}
