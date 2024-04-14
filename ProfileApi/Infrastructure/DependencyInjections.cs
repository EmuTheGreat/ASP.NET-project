using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection TryAddInfrastructure(this IServiceCollection services)
        {
            services.TryAddScoped<UserDbContext, UserDbContext>();
            services.TryAddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
