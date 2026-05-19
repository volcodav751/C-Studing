using System;

namespace PractiseWork6
{
    public static class KeyMetods
    {
        public static void ProcessKey(ConsoleKey key, Counter counter)
        {
            switch (key)
            {
                case ConsoleKey.P:
                    counter.TogglePause();
                    break;

                case ConsoleKey.R:
                    counter.ResetCounter();
                    break;

                case ConsoleKey.C:
                    counter.ChangeColor();
                    break;

                case ConsoleKey.Q:
                    counter.Stop();
                    break;
            }
        }
    }
}