using Microsoft.EntityFrameworkCore;

namespace BlogSite_API.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<BlogItem> BlogItems { get; set; }
    }
}
