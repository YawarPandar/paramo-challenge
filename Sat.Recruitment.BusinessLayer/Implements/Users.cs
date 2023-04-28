using System;
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
        private readonly IErrorHandler _errorHandler;
        private readonly ILogger _logger;
        public Users(IValidations validations, IFunctions functions, IUserRepository userRepository, IErrorHandler errorHandler, ILogger logger)
        {
            _validations = validations;
            _functions = functions;
            _userRepository = userRepository;
            _errorHandler = errorHandler;
            _logger = logger;
        }
        public BaseResult<User> Create(User newUser)
        {
            try
            {
                var user = UserDto.FromUser(newUser);
                if (!_validations.ValidateInputs(user, out string errors))
                {
                    throw _errorHandler.GetCustomException(errors);
                }
                user.Email = _functions.NormalizeEmail(user.Email);

                if (!_validations.ValidateDuplicated(user, _userRepository.GetAllUsers()))
                    throw _errorHandler.GetCustomException(DUPLICATED_USER);

                _functions.UpdateGif(ref user);

                var result = _userRepository.Create(user);

                _logger.Info(USER_CREATED);
                return new BaseResult<User> { IsSuccess = true, Message = USER_CREATED, Data = UserDto.ToUser(result) };
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return new BaseResult<User> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
