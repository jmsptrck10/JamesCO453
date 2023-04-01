using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApps.Models;


namespace WebApps.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MessagePost> MessagePosts { get; set; }
        public DbSet<PhotoPost> PhotoPosts { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
z
}
