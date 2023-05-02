using Sat.Recruitment.Models.Dto;

namespace Sat.Recruitment.Abstractions.Business
{
    public interface IFunctionService
    {
        string NormalizeEmail(string email);
    }
}
