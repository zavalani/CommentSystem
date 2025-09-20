using Microsoft.EntityFrameworkCore;

namespace CommentSystem.Models
{
    public class CommentsDbContext : DbContext
    {
        public CommentsDbContext(DbContextOptions<CommentsDbContext> options) :
     base(options)
        { }

        public DbSet<Comments> Comments { get; set; }
        


       
    }
}
