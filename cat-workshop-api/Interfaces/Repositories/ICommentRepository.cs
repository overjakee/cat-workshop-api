using cat_workshop_api.Models;

namespace cat_workshop_api.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsAsync();
        Task<bool> AddCommentAsync(string commentText, int userId);

        Task<bool> UpdateCommentAsync(int commentId, string commentText);
        Task<bool> DeleteCommentAsync(int commentId);
    }
}
