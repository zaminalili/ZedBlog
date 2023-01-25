namespace ZedBlog.Entity.Models
{
    public class BlogViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
