using cat_workshop_api.Data;
using cat_workshop_api.Interfaces.Repositories;
using cat_workshop_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cat_workshop_api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CatDbContext _context;
        public CommentRepository(CatDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCommentAsync(string commentText, int userId)
        {
            await _context.Comments.AddAsync(new Comment
            {
                UserId = userId,
                CommentText = commentText
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            var result = await _context.Comments.Include(c => c.User).ToListAsync();

            return result;
        }

        public async Task<bool> UpdateCommentAsync(int commentId, string commentText)
        {
            var result = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (result == null)
            {
                throw new Exception("Comment not found");
            }
            result.CommentText = commentText;
            _context.Comments.Update(result);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var result = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (result == null)
            {
                throw new Exception("Comment not found");
            }
            _context.Comments.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
