using System;

namespace PractiseWork6
{
    public class Counter
    {
        private int _counter = 0;
        private bool _isPaused = false;
        private bool _isRunning = true;

        private readonly object _locker = new object();

        private ConsoleColor[] _colors =
        {
            ConsoleColor.White,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Red
        };

        private int _colorIndex = 0;

        public bool IsRunning
        {
            get
            {
                lock (_locker)
                {
                    return _isRunning;
                }
            }
        }

        public void PrintCounter()
        {
            lock (_locker)
            {
                if (!_isPaused && _isRunning)
                {
                    _counter++;
                    Console.WriteLine($"Counter: {_counter}");
                }
            }
        }

        public void TogglePause()
        {
            lock (_locker)
            {
                _isPaused = !_isPaused;

                if (_isPaused)
                {
                    Console.WriteLine("Пауза.");
                }
                else
                {
                    Console.WriteLine("Продовження роботи.");
                }
            }
        }

        public void ResetCounter()
        {
            lock (_locker)
            {
                _counter = 0;
                Console.WriteLine("Лічильник скинуто до 0.");
            }
        }

        public void ChangeColor()
        {
            lock (_locker)
            {
                _colorIndex++;

                if (_colorIndex >= _colors.Length)
                {
                    _colorIndex = 0;
                }

                Console.ForegroundColor = _colors[_colorIndex];
                Console.WriteLine("Колір тексту змінено.");
            }
        }

        public void Stop()
        {
            lock (_locker)
            {
                _isRunning = false;
                Console.WriteLine("Завершення програми...");
            }
        }
    }
}