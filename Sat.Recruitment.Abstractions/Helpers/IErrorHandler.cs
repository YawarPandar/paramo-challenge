using System;

namespace Sat.Recruitment.Abstractions.Helpers
{
    public interface IErrorHandler
    {
        Exception GetCustomException(string message);
    }
}
