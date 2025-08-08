namespace cat_workshop_api.DTOs.Comment
{
    public class GetCommentResponse
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public int commentId { get; set; }
        public string commentText { get; set; } = string.Empty;
        public DateTime createDate { get; set; }

    }
}
