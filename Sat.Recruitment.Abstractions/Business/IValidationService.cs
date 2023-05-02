using Sat.Recruitment.Models.Dto;
using Sat.Recruitment.Models.View;
using System.Collections.Generic;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IValidationService
    {
        bool ValidateInputs(User user, out string validationResult);
        bool ValidateDuplicated(User user, List<UserDto> searchList);
        bool ValidateUserType(User user, out string validationResult);
    }
}
