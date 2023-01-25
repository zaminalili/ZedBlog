using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZedBlog.Service.Services.Abstract;
using ZedBlog.Service.Services.Concrete;

namespace ZedBlog.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<IBlogService, BlogService>();
            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
