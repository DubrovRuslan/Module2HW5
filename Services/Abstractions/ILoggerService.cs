using Module2HW5.Models;

namespace Module2HW5.Services.Abstractions
{
    public interface ILoggerService
    {
        public void Start();
        public void Stop();
        public void LogInfo(string message);

        public void LogError(string message);

        public void LogWarning(string message);

        public void Log(LogType type, string message);
    }
}
