using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
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
        public static IUserService GetUserAbstraction()
        {
            IConfiguration _configuration = GetConfiguration();
            Mock<IOptions<AppSettings>> appSettingsMock = new Mock<IOptions<AppSettings>>();
            IErrorHandlerService errorHandler = new ErrorHandlerService();
            appSettingsMock.Setup(x => x.Value).Returns(new AppSettings { LogFilePath = "", SaveLog = true });

            LoggerService logger = new LoggerService(appSettingsMock.Object);

            return new UserService(new ValidationService(new FunctionService(errorHandler)), new UserRepository(_configuration, errorHandler), errorHandler, logger);
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
