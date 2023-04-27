using Sat.Recruitment.Models.View;

namespace Sat.Recruitment.Models.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
        public static UserDto FromUser(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email, 
                Address = user.Address,
                Phone = user.Phone,
                UserType = user.UserType,
                Money = user.Money
            };
        }
        public static User ToUser(UserDto user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                UserType = user.UserType,
                Money = user.Money
            };
        }
    }
}
