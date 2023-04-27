using Sat.Recruitment.Abstractions.Helpers;
using System;

namespace Sat.Recruitment.BusinessLayer.Helpers
{
    public class ErrorHandler : IErrorHandler
    {
        public Exception RaiseException(string message)
        {
            return new Exception(message);
        }
    }
}
