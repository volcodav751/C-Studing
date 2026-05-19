using System;
using System.Text;
using System.Threading;

namespace PractiseWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.White;

            Counter counter = new Counter();
            ReadingKey readingKey = new ReadingKey(counter);

            Thread keyThread = new Thread(readingKey.ReadKeys);
            keyThread.Start();

            Console.WriteLine("Програма запущена.");
            Console.WriteLine("Керування:");
            Console.WriteLine("P - пауза / продовження");
            Console.WriteLine("R - скинути лічильник");
            Console.WriteLine("C - змінити колір тексту");
            Console.WriteLine("Q - завершити програму");
            Console.WriteLine();

            while (counter.IsRunning)
            {
                counter.PrintCounter();

                Thread.Sleep(1000);
            }

            keyThread.Join();

            Console.ResetColor();
            Console.WriteLine("Програма завершена.");
        }
    }
}