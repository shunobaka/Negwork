namespace Negwork.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_COMMENT_CONTENT_LENGTH)]
        [MaxLength(ModelConstants.MAX_COMMENT_CONTENT_LENGTH)]
        public string Content { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
