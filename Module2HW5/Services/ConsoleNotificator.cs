using System;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class ConsoleNotificator : IConsoleNotificator
    {
        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
