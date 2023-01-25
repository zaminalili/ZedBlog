using AutoMapper;
using ZedBlog.Entity.Entities;
using ZedBlog.Entity.Models;

namespace ZedBlog.Service.AutoMapper.Blogs
{
    public class BlogProfile: Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogViewModel, Blog>().ReverseMap();
        }
    }
}
