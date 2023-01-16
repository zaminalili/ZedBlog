using ZedBlog.Core.Entities;

namespace ZedBlog.Entity.Entities
{
    public class Image: EntityBase
    {
        public string fileName { get; set; }
        public string fileType { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
