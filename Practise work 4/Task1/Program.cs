using System;
using System.Linq;
using System.Text;

namespace Task_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            TaskProcessing taskProcessing = new TaskProcessing();

            taskProcessing.taskItems = JsonStorage.LoadTasks();

            int nextID;

            if (taskProcessing.taskItems.Count == 0)
            {
                nextID = 1;
            }
            else
            {
                nextID = taskProcessing.taskItems.Max(t => t.TaskID) + 1;
            }

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("===== TASK TRACKER =====");
                Console.WriteLine("1. Додати задачу");
                Console.WriteLine("2. Змінити статус задачі");
                Console.WriteLine("3. Переглянути список задач");
                Console.WriteLine("4. Вийти");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введіть назву задачі:");
                        string title = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Назва задачі не може бути порожньою.");
                            break;
                        }

                        taskProcessing.CreateTask(nextID, title, false);

                        Console.WriteLine($"Задачу додано з ID: {nextID}");

                        nextID++;
                        break;

                    case "2":
                        taskProcessing.ChangeStatus();
                        break;

                    case "3":
                        ShowTasks(taskProcessing);
                        break;

                    case "4":
                        JsonStorage.SaveTasks(taskProcessing.taskItems);
                        Console.WriteLine("Дані збережено у файл tasks.json.");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неправильний вибір.");
                        break;
                }
            }
        }

        static void ShowTasks(TaskProcessing taskProcessing)
        {
            if (taskProcessing.taskItems.Count == 0)
            {
                Console.WriteLine("Список задач порожній.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Список задач:");

            foreach (TaskItem task in taskProcessing.taskItems)
            {
                string status = task.IsCompleted ? "Виконано" : "Не виконано";

                Console.WriteLine($"{task.TaskID}. {task.Title} - {status}");
            }
        }
    }
}