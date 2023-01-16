using ZedBlog.Core.Entities;

namespace ZedBlog.Entity.Entities
{
    public class Category: EntityBase
    {
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
