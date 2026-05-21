using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseWork6
{
    internal class ReadingCommand
    {
        private readonly CommandMethods commandMethods;

        public ReadingCommand(CommandMethods commandMethods)
        {
            this.commandMethods = commandMethods;
        }

        public void ReadCommands()
        {
            while (true)
            {
                string? command = Console.ReadLine();

                if (command == null)
                    continue;

                command = command.ToLower();

                if (command == "p")
                {
                    commandMethods.PauseOrContinue();
                }
                else if (command == "r")
                {
                    commandMethods.ResetCounter();
                }
                else if (command == "c")
                {
                    commandMethods.ChangeColor();
                }
                else if (command == "q")
                {
                    commandMethods.Quit();
                    break;
                }
                else
                {
                    Console.WriteLine("Невідома команда.");
                }
            }
        }
    }
}
