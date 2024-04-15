using Logic.Post.Interface;
using Logic.Post.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic
{
    public static class LogicStartup
    {
        public static IServiceCollection TryAddLogic(this IServiceCollection services)
        {
            services.TryAddScoped<IPostLogicManager, PostLogicManager>();
            return services;
        }
    }
}
