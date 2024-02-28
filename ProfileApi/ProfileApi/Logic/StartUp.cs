using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileApi.Logic.User;

namespace ProfileApi.Logic
{
    public static class LogicStartUp
    {
        public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IUserManager, UserManager>();
            return serviceCollection;
        }
    }
}
