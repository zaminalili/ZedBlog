using Microsoft.EntityFrameworkCore;
using ZedBlog.Entity.Entities;

namespace ZedBlog.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Blog> Blogs { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Image> Images { get; set; }
    }
}
