namespace Negwork.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        private ICollection<ArticleRating> ratings;

        public Article()
        {
            this.ratings = new HashSet<ArticleRating>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_TITLE_LENGHT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_TITLE_LENGTH)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_DESCRIPTION_LENGTH)]
        public string Description { get; set; }

        public DateTime? DatePublished { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int AllRatings { get; set; }

        public int NumberOfRatings { get; set; }

        public virtual ICollection<ArticleRating> Ratings
        {
            get
            {
                return this.ratings;
            }
            set
            {
                this.ratings = value;
            }
        }
    }
}
