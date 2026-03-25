using System;
using System.Text;

namespace Task2_PD21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string logFile = "C:\\Users\\maxim\\Documents\\С#Studing\\ModuleWorkSecond\\logPD21.txt";

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(logFile);

            publisher.MessageSent += logger.LogMessage;

            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Введіть повідомлення {i}: ");
                string? message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "(порожнє повідомлення)";
                }

                publisher.Send(message);
            }

            Console.WriteLine("Повідомлення записані у logPD21.txt");
        }
    }
}