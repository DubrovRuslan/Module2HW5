using Module2HW5.Models;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IConsoleNotificator _consoleNotificator;

        public NotificationService(IConsoleNotificator consoleNotificator)
        {
            _consoleNotificator = consoleNotificator;
        }

        public void Notify(string notifyString)
        {
            _consoleNotificator.WriteToConsole(notifyString);
        }
    }
}
