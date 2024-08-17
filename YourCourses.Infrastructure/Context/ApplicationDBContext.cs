using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;


namespace YourCourses.Infrastructure.Context
{

    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration config;

        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration _configuration) : base(options)
        {
            config = _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("Default"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments  { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews  { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure Identity-related entities
            builder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
            builder.Entity<IdentityUserClaim<string>>().HasKey(c => c.Id);
            builder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            builder.Entity<IdentityRoleClaim<string>>().HasKey(rc => rc.Id);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            builder.Entity<ApplicationUser>().HasOne(u => u.Student).WithOne(s => s.AppUser).HasForeignKey<Student>(s => s.AppUserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasOne(u => u.Teacher).WithOne(t => t.AppUser).HasForeignKey<Teacher>(t => t.AppUserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Teacher>().HasMany(t =>t.Courses).WithOne(c => c.Teacher).HasForeignKey(c => c.TeacherId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Student>().HasMany(s =>s.Reviews).WithOne(r => r.Student).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Course>().HasMany(c =>c.Reviews).WithOne(r => r.Course).HasForeignKey(r => r.CourseId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Category>().HasMany(c => c.SubCategories).WithOne(s => s.Category).HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SubCategory>().HasMany(s=> s.Courses).WithOne(c => c.SubCategory).HasForeignKey(c => c.SubCategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Course>().HasMany(c=> c.Videos).WithOne(v => v.Course).HasForeignKey(v=> v.CourseId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Video>().HasMany(v=> v.Comments).WithOne(c => c.Video).HasForeignKey(c=> c.VideoId).OnDelete(DeleteBehavior.Cascade);
        
        
        }


    }

}
