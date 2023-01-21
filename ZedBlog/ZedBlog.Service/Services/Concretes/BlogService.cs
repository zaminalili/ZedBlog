using ZedBlog.Data.UnitOfWorks;
using ZedBlog.Entity.Entities;
using ZedBlog.Service.Services.Abstracts;

namespace ZedBlog.Service.Services.Concretes
{
    public class BlogService: IBlogService
    {
        private readonly IUnitOfWork unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await unitOfWork.GetRepository<Blog>().GetAllAsync();
        }
    }
}
