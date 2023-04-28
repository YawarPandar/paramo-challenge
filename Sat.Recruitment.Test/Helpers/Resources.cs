using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using Sat.Recruitment.BusinessLayer.Helpers;
using Sat.Recruitment.BusinessLayer.Implements;
using Sat.Recruitment.Repository;
using System.IO;
using Moq;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Models.Configuration;

namespace Sat.Recruitment.Test.Helpers
{
    public static class Resources
    {
        public static IUsers GetUserAbstraction()
        {
            Mock<IOptions<AppSettings>> appSettingsMock = new Mock<IOptions<AppSettings>>();
            appSettingsMock.Setup(x => x.Value).Returns(new AppSettings { LogFilePath = "", SaveLog = true });

            Logger logger = new Logger(appSettingsMock.Object);

            return new Users(GetValidationsAbstraction(), GetFunctionsAbstraction(), GetUserRepositoryAbstraction(), GetErrorHandlerAbstraction(), logger);
        }
        private static IValidations GetValidationsAbstraction()
        {
            return new Validations();
        }
        private static IFunctions GetFunctionsAbstraction()
        {
            return new Functions(GetErrorHandlerAbstraction());
        }
        private static IErrorHandler GetErrorHandlerAbstraction()
        {
            return new ErrorHandler();
        }
        private static IUserRepository GetUserRepositoryAbstraction()
        {
            return new UserRepository(GetConfiguration(), GetErrorHandlerAbstraction());
        }
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.Development.json", true, true)
              .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
