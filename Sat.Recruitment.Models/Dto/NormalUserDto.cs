using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Models.Dto
{
    public class NormalUserDto : UserDto
    {
        public NormalUserDto(User user)
        {
            if (user.Money > 100) //If new user is normal and has more than USD100
            {
                Percentage = 0.12M;
            }
            else if (user.Money < 100 && user.Money > 10)
            {
                Percentage = 0.8M;
            }
            FromUser(user);
        }
    }
}
