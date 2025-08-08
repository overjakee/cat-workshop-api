using cat_workshop_api.DTOs.Comment;
using cat_workshop_api.Interfaces.Repositories;
using cat_workshop_api.Interfaces.Services;
using cat_workshop_api.Models;
using System;

namespace cat_workshop_api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public async Task<AddCommentResponse> AddCommentAsync(string commentText, int userId)
        {
            if (string.IsNullOrWhiteSpace(commentText))
                throw new ArgumentException("Comment text cannot be empty.", nameof(commentText));
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.", nameof(userId));

            var addSuccess = await _commentRepository.AddCommentAsync(commentText, userId);

            if (!addSuccess)
                throw new InvalidOperationException("Failed to add comment.");

            return new AddCommentResponse
            {
                isSuccess = addSuccess
            };
        }

        public async Task<List<GetCommentResponse>> GetCommentsAsync()
        {
            var listComments = await _commentRepository.GetCommentsAsync();

            if (listComments == null)
                throw new InvalidOperationException("Failed to retrieve comments.");

            var response = listComments.Select(c => new GetCommentResponse
            {
                userId = c.UserId,
                userName = $"{c.User.FirstName} {c.User.LastName}",
                commentId = c.CommentId,
                commentText = c.CommentText,
                createDate = c.CreatedAt
            }).ToList();

            return response;
        }

        public async Task<UpdateCommentResponse> UpdateCommentAsync(UpdateCommentRequest request, int commentId)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            //if (string.IsNullOrWhiteSpace(request.CommentText))
            //    throw new ArgumentException("Comment text cannot be empty.", nameof(request.CommentText));
            if (commentId <= 0)
                throw new ArgumentException("Invalid comment ID.", nameof(commentId));

            var updateSuccess = await _commentRepository.UpdateCommentAsync(commentId, request.CommentText);

            if (!updateSuccess)
                throw new InvalidOperationException($"Failed to update comment with ID {commentId}.");

            return new UpdateCommentResponse
            {
                IsUpdated = updateSuccess
            };
        }

        public async Task<DeleteCommentResponse> DeleteCommentAsync(int commentId)
        {
            if (commentId <= 0)
                throw new ArgumentException("Invalid comment ID.", nameof(commentId));

            var deleteSuccess = await _commentRepository.DeleteCommentAsync(commentId);

            if (!deleteSuccess)
                throw new InvalidOperationException($"Failed to delete comment with ID {commentId}.");

            return new DeleteCommentResponse
            {
                IsDeleted = deleteSuccess
            };
        }
    }
}
