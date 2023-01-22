using ZedBlog.Entity.Entities;

namespace ZedBlog.Service.Services.Abstract
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogAsync();
    }
}
