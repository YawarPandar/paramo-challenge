using Microsoft.Extensions.Options;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Models.Configuration;
using System;
using System.Diagnostics;

namespace Sat.Recruitment.BusinessLayer.Helpers
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly IOptions<AppSettings> _settings;
        public ErrorHandler(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public Exception RaiseException(string message)
        {
            if (_settings.Value.SaveLog) Debug.WriteLine(message);
            return new Exception(message);
        }
    }
}
