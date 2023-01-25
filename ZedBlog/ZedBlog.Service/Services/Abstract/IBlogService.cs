using ZedBlog.Entity.Entities;
using ZedBlog.Entity.Models;

namespace ZedBlog.Service.Services.Abstract
{
    public interface IBlogService
    {
        //Task<List<Blog>> GetAllBlogAsync();
        Task<List<BlogViewModel>> GetAllBlogAsync();
    }
}
