using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Domain
{
    public static class DependencyInjections
    {
        public static IServiceCollection TryAddDomain(this IServiceCollection services)
        {
            services.TryAddScoped<IUserService, UserService>();
            return services;
        }
    }
}
