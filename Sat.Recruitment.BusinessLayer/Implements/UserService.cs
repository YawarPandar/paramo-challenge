using System;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using Sat.Recruitment.Models.Dto;
using Sat.Recruitment.Models.View;
using static Sat.Recruitment.Models.Configuration.Constants;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class UserService : IUserService
    {
        private readonly IValidationService _validations;
        private readonly IUserRepository _userRepository;
        private readonly IErrorHandlerService _errorHandler;
        private readonly ILoggerService _logger;
        public UserService(IValidationService validations, IUserRepository userRepository, IErrorHandlerService errorHandler, ILoggerService logger)
        {
            _validations = validations;
            _userRepository = userRepository;
            _errorHandler = errorHandler;
            _logger = logger;
        }
        public BaseResult<User> Create(User newUser)
        {
            try
            {
                if (!_validations.ValidateInputs(newUser, out string errors))
                {
                    throw _errorHandler.GetCustomException(errors);
                }

                if (!_validations.ValidateUserType(newUser, out errors))
                {
                    throw _errorHandler.GetCustomException(errors);
                }

                if (!_validations.ValidateDuplicated(newUser, _userRepository.GetAllUsers()))
                    throw _errorHandler.GetCustomException(DUPLICATED_USER);

                var result = _userRepository.Create(GetUserFromType(newUser));

                _logger.Info(USER_CREATED);
                return new BaseResult<User> { IsSuccess = true, Message = USER_CREATED, Data = UserDto.ToUser(result) };
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return new BaseResult<User> { IsSuccess = false, Message = ex.Message };
            }
        }
        private UserDto GetUserFromType(User user)
        {
            Enum.TryParse(user.UserType, out UserType userType);
            switch (userType)
            {
                case UserType.Normal:
                    return new NormalUserDto(user);
                case UserType.SuperUser:
                    return new SuperUserDto(user);
                case UserType.Premium:
                    return new PremiumUserDto(user);
                default:
                    return new UserDto();
            }
        }
    }
}
