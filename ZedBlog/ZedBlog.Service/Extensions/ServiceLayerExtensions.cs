using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZedBlog.Service.Services.Abstracts;
using ZedBlog.Service.Services.Concretes;

namespace ZedBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();

            return services;
        }
    }
}
}
