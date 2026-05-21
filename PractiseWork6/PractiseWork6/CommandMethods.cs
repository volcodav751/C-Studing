using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseWork6
{
    public class CommandMethods
    {
        private readonly Counter counter;

        public CommandMethods(Counter counter)
        {
            this.counter = counter;
        }

        public void PauseOrContinue()
        {
            counter.TogglePause();

            if (counter.IsPaused)
                Console.WriteLine("Пауза.");
            else
                Console.WriteLine("Продовження роботи.");
        }

        public void ResetCounter()
        {
            counter.Reset();
            Console.WriteLine("Лічильник скинуто до 0.");
        }

        public void ChangeColor()
        {
            counter.ChangeColor();
            Console.WriteLine("Колір змінено.");
        }

        public void Quit()
        {
            counter.Stop();
            Console.WriteLine("Завершення програми...");
        }
    }
}
