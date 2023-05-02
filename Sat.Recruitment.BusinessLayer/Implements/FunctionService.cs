using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using System;
using System.Text.RegularExpressions;
using static Sat.Recruitment.Models.Configuration.Constants;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class FunctionService : IFunctionService
    {
        private readonly IErrorHandlerService _errorHandler;
        public FunctionService(IErrorHandlerService errorHandler)
        {
            _errorHandler = errorHandler;
        }
        public string NormalizeEmail(string email)
        {
            if (!IsValid(email)) throw _errorHandler.GetCustomException(INVALID_EMAIL);

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            return string.Join("@", aux[0], aux[1]);
        }
        private bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
