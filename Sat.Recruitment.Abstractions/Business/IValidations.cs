using Sat.Recruitment.Models.Dto;
using System.Collections.Generic;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IValidations
    {
        bool ValidateInputs(UserDto user, out string validationResult);
        bool ValidateDuplicated(UserDto user, List<UserDto> searchList);
    }
}
