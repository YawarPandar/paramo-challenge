using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Models.Dto
{
    public class PremiumUserDto : UserDto
    {
        public PremiumUserDto(User user)
        {
            Percentage = 2M;
            FromUser(user);
        }
    }
}
