using System;
using System.Diagnostics;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using static Sat.Recruitment.Abstractions.Helpers.IConstants;
using Sat.Recruitment.Models.Dto;
using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class Users : IUsers
    {
        private readonly IValidations _validations;
        private readonly IFunctions _functions;
        private readonly IUserRepository _userRepository;
        public readonly IErrorHandler _errorHandler;
        public Users(IValidations validations, IFunctions functions, IUserRepository userRepository, IErrorHandler errorHandler)
        {
            _validations = validations;
            _functions = functions;
            _userRepository = userRepository;
            _errorHandler = errorHandler;
        }
        public BaseResult<User> Create(User newUser)
        {
            try
            {
                var user = UserDto.FromUser(newUser);
                if (!_validations.ValidateInputs(user, out string errors))
                {
                    throw _errorHandler.RaiseException(errors);
                }
                user.Email = _functions.NormalizeEmail(user.Email);

                if (!_validations.ValidateDuplicated(user, _userRepository.GetAllUsers()))
                    throw _errorHandler.RaiseException(DUPLICATED_USER);

                _functions.UpdateGif(ref user);

                var result = _userRepository.Create(user);

                return new BaseResult<User> { IsSuccess = true, Message = USER_CREATED, Data = UserDto.ToUser(result) };
            }
            catch(Exception ex)
            {
                return new BaseResult<User> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
