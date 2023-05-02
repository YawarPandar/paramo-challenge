using Sat.Recruitment.Models.Dto;
using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IUserService
    {
        BaseResult<User> Create(User newUser);
    }
}