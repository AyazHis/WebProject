using Microsoft.EntityFrameworkCore;
using WebProject.Blogging.Models;

namespace WebProject.Blogging
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options ) 
        { 
        }

        public DbSet<Blog> Blogs { get; set; }


    }
}
