using ZedBlog.Entity.Entities;

namespace ZedBlog.Service.Services.Abstracts
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogsAsync();
    }
}
