using ZedBlog.Data.UnitOfWorks;
using ZedBlog.Entity.Entities;
using ZedBlog.Service.Services.Abstract;

namespace ZedBlog.Service.Services.Concrete
{
    public class BlogService: IBlogService
    {
        private readonly IUnitOfWork unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await unitOfWork.GetRepository<Blog>().GetAllAsync();
        }
    }
}
