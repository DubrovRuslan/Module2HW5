using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Services.Abstractions;
using Module2HW5.Services;
using Module2HW5;

var serviceProvider = new ServiceCollection()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IConsoleNotificator, ConsoleNotificator>()
                .AddTransient<INotificationService, NotificationService>()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IActions, Actions>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
var start = serviceProvider.GetService<Starter>();
start.Run();