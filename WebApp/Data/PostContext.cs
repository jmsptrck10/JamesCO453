using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialNetworkWebApp.Data
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
