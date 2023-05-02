using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Models.Dto;
using Sat.Recruitment.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Sat.Recruitment.Models.Configuration.Constants;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class ValidationService : IValidationService
    {
        private readonly IFunctionService _functions;
        public ValidationService(IFunctionService functions)
        {
            _functions = functions;
        }
        public bool ValidateInputs(User user, out string validationResult)
        {
            StringBuilder validationMessage = new StringBuilder();
            user
                .GetType()
                .GetProperties()
                .Where(p => p.GetValue(user) == null)
                .Select(i => i.Name)
                .ToList()
                .ForEach(p => validationMessage.AppendLine($"The {p} is required"));
            validationResult = validationMessage.ToString();
            return string.IsNullOrEmpty(validationResult);
        }

        public bool ValidateDuplicated(User user, List<UserDto> searchList)
        {

            user.Email = _functions.NormalizeEmail(user.Email);
            var isDuplicated = searchList.Any(u => u.Email.Equals(user.Email)
                        || u.Phone.Equals(user.Phone)
                        || (u.Name.Equals(user.Name) && u.Address.Equals(user.Address))
                    );

            return !isDuplicated;
        }
        public bool ValidateUserType(User user, out string validationResult)
        {
            validationResult = string.Empty;
            bool isValid = Enum.TryParse(user.UserType, out UserType _);
            if (!isValid) validationResult = INVALID_USER_TYPE;
            return isValid;
        }
    }
}