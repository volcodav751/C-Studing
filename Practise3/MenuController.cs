using System;

namespace Practise3
{
    public static class MenuController
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\n===== Практична робота №3 =====");
                Console.WriteLine("1 - Аналізатор текстового файлу");
                Console.WriteLine("2 - Інспектор папки");
                Console.WriteLine("3 - Пошук найбільшого файлу");
                Console.WriteLine("4 - Очищення кешу");
                Console.WriteLine("0 - Вихід");
                Console.Write("Оберіть пункт меню: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "3":
                        RunTask3();
                        break;
                    case "4":
                        RunTask4();
                        break;
                    case "0":
                        Console.WriteLine("Програму завершено.");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private static void RunTask1()
        {
            Console.Write("Введіть шлях до текстового файлу: ");
            string? path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Шлях не введено.");
                return;
            }

            FileAnalizer.Analize(path);
        }

        private static void RunTask2()
        {
            Console.Write("Введіть шлях до папки: ");
            string? path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Шлях не введено.");
                return;
            }

            FolderIspector.Inspect(path);
        }

        private static void RunTask3()
        {
            Console.Write("Введіть шлях до папки: ");
            string? path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Шлях не введено.");
                return;
            }

            LargestFileFinder.FindLargest(path);
        }

        private static void RunTask4()
        {
            Console.Write("Введіть шлях до папки cache: ");
            string? path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Шлях не введено.");
                return;
            }

            Console.WriteLine("1 - Очищення з рекурсією");
            Console.WriteLine("2 - Очищення без рекурсії");
            Console.Write("Оберіть варіант: ");

            string? mode = Console.ReadLine();
            CleanupResult result;

            switch (mode)
            {
                case "1":
                    result = CacheCleaner.CleanRecursive(path);
                    PrintCleanupResult(result);
                    break;

                case "2":
                    result = CacheCleaner.CleanWithoutRecursion(path);
                    PrintCleanupResult(result);
                    break;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }

        private static void PrintCleanupResult(CleanupResult result)
        {
            Console.WriteLine("\n===== Звіт очищення =====");
            Console.WriteLine("Видалено файлів: " + result.FilesDeleted);
            Console.WriteLine("Сумарний розмір: " + result.TotalBytesDeleted + " байт");
        }
    }
}