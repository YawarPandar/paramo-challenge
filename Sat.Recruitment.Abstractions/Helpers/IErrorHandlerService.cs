using System;

namespace Sat.Recruitment.Abstractions.Helpers
{
    public interface IErrorHandlerService
    {
        Exception GetCustomException(string message);
    }
}
