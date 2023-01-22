using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZedBlog.Data.Repositories;
using ZedBlog.Data.UnitOfWorks;

namespace ZedBlog.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
