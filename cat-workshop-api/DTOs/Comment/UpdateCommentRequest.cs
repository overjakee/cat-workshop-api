using System.ComponentModel.DataAnnotations;

namespace cat_workshop_api.DTOs.Comment
{
    public class UpdateCommentRequest
    {
        public string CommentText { get; set; } = string.Empty;

    }
}
