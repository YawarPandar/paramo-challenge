using Sat.Recruitment.Models.Dto;
using System.Collections.Generic;

namespace Sat.Recruitment.Abstractions.Repositories
{
    public interface IUserRepository
    {
        UserDto Create(UserDto user);
        List<UserDto> GetAllUsers();
    }
}
