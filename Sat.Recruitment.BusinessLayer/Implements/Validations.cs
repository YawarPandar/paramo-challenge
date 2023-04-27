using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class Validations : IValidations
    {
        public bool ValidateInputs(UserDto user, out string validationResult)
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

        public bool ValidateDuplicated(UserDto user, List<UserDto> searchList)
        {
            var isDuplicated = searchList.Any(u => u.Email.Equals(user.Email)
                        || u.Phone.Equals(user.Phone)
                        || (u.Name.Equals(user.Name) && u.Address.Equals(user.Address))
                    );

            return !isDuplicated;
        }
    }
}