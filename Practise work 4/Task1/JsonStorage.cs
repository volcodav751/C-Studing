using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task_Tracker
{
    public static class JsonStorage
    {
        private static string filePath = "tasks.json";

        public static void SaveTasks(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(filePath))
            {
                return new List<TaskItem>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<TaskItem>();
            }

            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}