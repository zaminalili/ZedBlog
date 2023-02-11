﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZedBlog.Entity.Entities;

namespace ZedBlog.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            //var admin = new AppUser
            //{
            //    Id = Guid.Parse("660e6282-5226-48f0-9acf-40550889c16b"),
            //    UserName = "zamin@mail.com",
            //    NormalizedUserName = "ZAMIN@MAIL.COM",
            //    Email = "zamin@mail.com",
            //    NormalizedEmail = "ZAMIN@MAIL.COM",
            //    PhoneNumber = "505578212",
            //    FirsName = "Zamin",
            //    LastName = "Alili",
            //    PhoneNumberConfirmed = true,
            //    EmailConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //admin.PasswordHash = CreatePasswordHash(admin,
            //    "Zamin2003");
                
        }

        //private string CreatePasswordHash(AppUser user, string password)
        //{
        //    var passwordHasher = new PasswordHasher<AppUser>();

        //    return passwordHasher.HashPassword(user, password);
        //}
    }
}
