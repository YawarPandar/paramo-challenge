using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IUsers
    {
        BaseResult<User> Create(User newUser);
    }
}