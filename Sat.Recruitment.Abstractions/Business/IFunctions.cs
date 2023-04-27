using Sat.Recruitment.Models.Dto;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IFunctions
    {
        void UpdateGif(ref UserDto user);
        string NormalizeEmail(string email);
    }
}
