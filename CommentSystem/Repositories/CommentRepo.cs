using CommentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentSystem.Repositories
{
    public class CommentRepo
    {
        private readonly CommentsDbContext _context;

        public CommentRepo(CommentsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comments> GetAll()
        {
            return _context.Comments.OrderByDescending(c => c.CommentDate).ToList();
        }

        public Comments Add(Comments comment)
        {
            comment.CommentDate = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
