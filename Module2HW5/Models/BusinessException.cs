using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Models
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base($"Skipped logic in method {message}")
        {
        }
    }
}
