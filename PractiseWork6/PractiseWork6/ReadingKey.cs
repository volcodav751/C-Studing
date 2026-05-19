using System;

namespace PractiseWork6
{
    public class ReadingKey
    {
        private Counter _counter;

        public ReadingKey(Counter counter)
        {
            _counter = counter;
        }

        public void ReadKeys()
        {
            while (_counter.IsRunning)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                KeyMetods.ProcessKey(keyInfo.Key, _counter);
            }
        }
    }
}