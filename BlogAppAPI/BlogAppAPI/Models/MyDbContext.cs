using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace BlogAppAPI.Models
{
    public class MyDbContext : IdentityDbContext<CustomUser>
    {   
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            // Phương thức khởi tạo này chứa options để kết nối đến MS SQL Server
            // Thực hiện điều này khi Inject trong dịch vụ hệ thống
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {   
                    tableName = tableName.Substring(6);
                    entityType.SetTableName(tableName);
                }
            }
            modelBuilder.Entity<PostCategory>(builder => {
                builder.HasKey( p => new { p.PostId,p.CategoryId} );
            });

            modelBuilder.Entity<PostTag>(builder =>
            {
                builder.HasKey( p => new {p.PostId, p.TagId} );
            });

            modelBuilder.Entity<Tag>(builder => {
                builder.HasIndex(t => t.TagName)
                    .IsUnique();
            });
            modelBuilder.Entity<CustomUser>(builder => {
                builder.HasIndex(u=>u.Email)
                    .IsUnique();
                builder.HasIndex(u => u.UserName)
                    .IsUnique();
            });
            modelBuilder.Entity<Category>(builder => {
                builder.HasIndex(c => c.CategorySlug)
                    .IsUnique();
            });
            modelBuilder.Entity<Author>(builder => {
                builder.Property(a => a.AuthorSlug);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            /*
            //có thể cấu hình cái này ngay trong Program.cs
            var configBuilder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                      .AddJsonFile("appconfig.json");                    // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();                // Tạo configurationroot
            optionsBuilder.UseSqlServer(configurationroot["ConnectionStrings:BlogAppAPI"]);
            */
        }
    }
}
