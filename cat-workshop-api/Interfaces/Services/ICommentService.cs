using cat_workshop_api.DTOs.Comment;
using cat_workshop_api.Models;

namespace cat_workshop_api.Interfaces.Services
{
    public interface ICommentService
    {
        Task<List<GetCommentResponse>> GetCommentsAsync();
        Task<AddCommentResponse> AddCommentAsync(string commentText, int userId);

        Task<UpdateCommentResponse> UpdateCommentAsync(UpdateCommentRequest request, int commentId);
        Task<DeleteCommentResponse> DeleteCommentAsync(int commentId);
    }
}
