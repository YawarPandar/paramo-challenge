using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using Sat.Recruitment.BusinessLayer.Helpers;
using Sat.Recruitment.BusinessLayer.Implements;
using Sat.Recruitment.Repository;

namespace Sat.Recruitment.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUsers, Users>();
            services.AddTransient<IValidations, Validations>();
            services.AddTransient<IFunctions, Functions>();
            services.AddTransient<IErrorHandler, ErrorHandler>();
            services.AddTransient<ILogger, Logger>();
        }
    }
}
