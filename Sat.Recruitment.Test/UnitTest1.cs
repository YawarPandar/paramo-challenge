using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Models.View;
using Sat.Recruitment.Test.Helpers;
using Xunit;
using static Sat.Recruitment.Models.Configuration.Constants;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Theory]
        [InlineData("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124, true, USER_CREATED)]
        [InlineData("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124, false, DUPLICATED_USER)]
        public void UserCreation_Test(string name, string email, string address, string phone, string userType, decimal money, bool success, string returnedMessage)
        {
            var userAbstraction = Resources.GetUserAbstraction();

            var userController = new UsersController(userAbstraction);
            var result = userController.CreateUser(new User { Name = name, Address = address, Phone = phone, UserType = userType, Money = money, Email = email }).Result;
            Assert.Equal(success, result.IsSuccess);
            Assert.Equal(returnedMessage, result.Message);
        }
    }
}