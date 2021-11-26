using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Services.Abstractions
{
    public interface IConsoleNotificator
    {
        public void WriteToConsole(string message);
    }
}
