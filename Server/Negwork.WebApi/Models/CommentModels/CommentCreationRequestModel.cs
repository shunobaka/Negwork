namespace Negwork.WebApi.Models.CommentModels
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CommentCreationRequestModel
    {
        [Required]
        [MinLength(ModelConstants.MIN_COMMENT_CONTENT_LENGTH,
            ErrorMessage = ErrorMessages.COMMENT_CONTENT_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_COMMENT_CONTENT_LENGTH,
            ErrorMessage = ErrorMessages.COMMENT_CONTENT_TOO_LONG)]
        public string Content { get; set; }
        
        [Required]
        public int ArticleId { get; set; }
    }
}