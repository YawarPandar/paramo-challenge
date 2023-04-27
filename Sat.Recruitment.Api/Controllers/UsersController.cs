using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sat.Recruitment.Models.View;
using Sat.Recruitment.Abstractions.Business;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpPost]
        [Route("/create-user")]
        public Task<BaseResult<User>> CreateUser([FromBody] User user)
        {
            var response = _users.Create(user);
            return Task.FromResult(response);
        }
    }
}
