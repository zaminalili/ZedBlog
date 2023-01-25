using AutoMapper;
using ZedBlog.Data.UnitOfWorks;
using ZedBlog.Entity.Entities;
using ZedBlog.Entity.Models;
using ZedBlog.Service.Services.Abstract;

namespace ZedBlog.Service.Services.Concrete
{
    public class BlogService: IBlogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper; 
        public BlogService(IUnitOfWork unitOfWork, IMapper maper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = maper;
        }

        public async Task<List<BlogViewModel>> GetAllBlogAsync()
        {
            var blogs = await unitOfWork.GetRepository<Blog>().GetAllAsync();
            var map = mapper.Map<List<BlogViewModel>>(blogs);

            return map;
        }
    }
}
