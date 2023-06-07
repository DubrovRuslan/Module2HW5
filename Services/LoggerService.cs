using System;
using Module2HW5.Models;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly IConfigService _configService;
        private readonly INotificationService _notificationService;
        private LoggerConfig _loggerConfig;
        private string _rootDirectory = "./";
        private bool _loggerIsRunning;
        public LoggerService(IFileService fileService, IConfigService configService, INotificationService notificationService)
        {
            _fileService = fileService;
            _configService = configService;
            _notificationService = notificationService;
        }

        public bool LoggerIsRunning
        {
            get
            {
                return _loggerIsRunning;
            }
        }

        public void Start()
        {
            if (_loggerIsRunning)
            {
                return;
            }

            _loggerConfig = _configService.ReadConfig().Logger;

            if (_loggerConfig == null)
            {
                return;
            }

            if (_fileService.CreateDirectory(_rootDirectory, _loggerConfig.DirectoryPath))
            {
                var fileName = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)}{_loggerConfig.FileExtension}";
                if (!_fileService.CreateFile($"{_rootDirectory}{_loggerConfig.DirectoryPath}", fileName))
                {
                    return;
                }
            }

            _loggerIsRunning = true;
        }

        public void Stop()
        {
            var logCount = _fileService.CurrentCountFilesInDirectory(_loggerConfig.DirectoryPath);
            if (logCount != null)
            {
                if (logCount > _loggerConfig.MaxLogCount)
                {
                    _fileService.CreateDirectory(_rootDirectory, _loggerConfig.BackUpDirectotyPath);
                    string sourcePath = $"{_rootDirectory}{_loggerConfig.DirectoryPath}";
                    string destinationPath = $"{_rootDirectory}{_loggerConfig.BackUpDirectotyPath}";
                    _fileService.MoveOldFiles(sourcePath, destinationPath, _loggerConfig.MaxLogCount);
                }
            }

            _loggerIsRunning = false;
            _fileService.Dispose();
        }

        public void Log(LogType type, string message)
        {
            var time = DateTime.UtcNow;
            var log = $"{time.ToShortTimeString()}: {type.ToString()}: {message}";
            if (_loggerIsRunning)
            {
                _fileService.WriteToFile(log);
                _notificationService.Notify(log);
            }
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }
    }
}
