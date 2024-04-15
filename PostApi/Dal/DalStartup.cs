using Dal.Post.Contexts;
using Dal.Post.Interfaces;
using Dal.Post.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dal
{
    public static class DalStartup
    {
        public static IServiceCollection TryAddDal(this IServiceCollection services)
        {
            //services.TryAddSсoped<DbContext, PostContext>();
            services.TryAddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}
