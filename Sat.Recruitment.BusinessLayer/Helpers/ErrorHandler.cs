
using Sat.Recruitment.Abstractions.Helpers;
using System;

namespace Sat.Recruitment.BusinessLayer.Helpers
{
    public class ErrorHandler : IErrorHandler
    {
        public Exception GetCustomException(string message)
        {
            return new Exception(message);
        }
    }
}
