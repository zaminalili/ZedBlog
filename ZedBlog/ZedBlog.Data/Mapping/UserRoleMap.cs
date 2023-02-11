using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZedBlog.Entity.Entities;

namespace ZedBlog.Data.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            //builder.HasData(
            //        new AppUserRole
            //        {
            //            UserId = Guid.Parse("660e6282-5226-48f0-9acf-40550889c16b"),
            //            RoleId = Guid.Parse("d570bcc7-d4ed-499a-bb45-9a20ebbdffcb")

            //        }
            //    );
        }
    }
}
