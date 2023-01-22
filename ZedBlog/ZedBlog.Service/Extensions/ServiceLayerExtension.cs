using Microsoft.Extensions.DependencyInjection;
using ZedBlog.Service.Services.Abstract;
using ZedBlog.Service.Services.Concrete;

namespace ZedBlog.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            return services;
        }
    }
}
