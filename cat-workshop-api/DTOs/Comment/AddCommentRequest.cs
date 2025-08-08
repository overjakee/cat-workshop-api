using System.ComponentModel.DataAnnotations;

namespace cat_workshop_api.DTOs.Comment
{
    public class AddCommentRequest
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; } = "";
    }
}
