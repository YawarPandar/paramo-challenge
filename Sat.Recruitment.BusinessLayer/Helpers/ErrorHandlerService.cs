
using Sat.Recruitment.Abstractions.Helpers;
using System;

namespace Sat.Recruitment.BusinessLayer.Helpers
{
    public class ErrorHandlerService : IErrorHandlerService
    {
        public Exception GetCustomException(string message)
        {
            return new Exception(message);
        }
    }
}
