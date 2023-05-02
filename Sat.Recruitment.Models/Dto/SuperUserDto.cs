using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Models.Dto
{
    public class SuperUserDto : UserDto
    {
        public SuperUserDto(User user)
        {
            Percentage = 0.2M;
            FromUser(user);
        }
    }
}
