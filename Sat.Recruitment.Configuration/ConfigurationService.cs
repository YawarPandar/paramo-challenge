using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using Sat.Recruitment.BusinessLayer.Helpers;
using Sat.Recruitment.BusinessLayer.Implements;
using Sat.Recruitment.Repository;

namespace Sat.Recruitment.Configuration
{
    public static class ConfigurationService
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IErrorHandlerService, ErrorHandlerService>();
            services.AddTransient<ILoggerService, LoggerService>();
        }
    }
}
