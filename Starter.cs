using System;
using Module2HW5.Models;
using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Services.Abstractions;
using Module2HW5.Services;

namespace Module2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        private readonly ILoggerService _loggerService;
        public Starter(IActions actions, ILoggerService loggerService)
        {
            _actions = actions;
            _loggerService = loggerService;
        }

        public void Run()
        {
            _loggerService.Start();
            var rnd = new Random();
            var result = new Result();

            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (rnd.Next(3))
                    {
                        case 0:
                            result = _actions.Method_1();
                            _loggerService.LogInfo($"Start method: {nameof(_actions.Method_1)}");
                            break;
                        case 1:
                            result = _actions.Method_2();
                            break;
                        case 2:
                            result = _actions.Method_3();
                            break;
                    }
                }
                catch (BusinessException exception)
                {
                    _loggerService.LogError($"Action got this custom Exception: {exception.Message}");
                }
                catch (Exception exception)
                {
                    _loggerService.LogError($"Action failed by reason: {exception.Message}");
                }
            }

            _loggerService.Stop();
        }
    }
}
