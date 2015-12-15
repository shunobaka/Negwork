namespace Negwork.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class ArticleRating
    {
        [Key]
        public int Id { get; set; }

        [Range(ModelConstants.MIN_ARTICLE_RATING_VALUE, ModelConstants.MAX_ARTICLE_RATING_VALUE)]
        public int Value { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
