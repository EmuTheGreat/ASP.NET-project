using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileApi.Dal.User;

namespace ProfileApi.Dal
{
    public static class DalStartUp
    {
        public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}
