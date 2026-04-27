using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_Tracker
{
    public class TaskProcessing
    {
        public List<TaskItem> taskItems = new List<TaskItem>();

        public void CreateTask(int id, string title, bool isCompleted)
        {
            TaskItem newTask = new TaskItem
            {
                TaskID = id,
                Title = title,
                IsCompleted = isCompleted
            };

            taskItems.Add(newTask);
        }

        public void ChangeStatus()
        {
            Console.WriteLine("Введіть айді задачі: ");

            int readID;

            try
            {
                readID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неправильно введене айді");
                return;
            }

            TaskItem task = taskItems.FirstOrDefault(t => t.TaskID == readID);

            if (task == null)
            {
                Console.WriteLine("Задачу з таким ID не знайдено");
                return;
            }

            task.IsCompleted = !task.IsCompleted;

            Console.WriteLine($"Статус завдання {task.TaskID}: {task.Title} було змінено на {task.IsCompleted}");
        }
    }
}