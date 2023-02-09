using Microsoft.AspNetCore.Identity;

namespace ZedBlog.Entity.Entities
{
    public class AppUser: IdentityUser<Guid>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
