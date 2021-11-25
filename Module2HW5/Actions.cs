using System;
using Module2HW5.Models;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Actions : IActions
    {
        public Result Method_1()
        {
            return new Result() { Status = true };
        }

        public Result Method_2()
        {
            throw new BusinessException($"{nameof(Method_2)}");
        }

        public Result Method_3()
        {
            throw new Exception("I broke a logic");
        }
    }
}
