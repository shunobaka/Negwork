namespace Negwork.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Article> articles;
        private ICollection<Image> images;

        public Category()
        {
            this.articles = new HashSet<Article>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelConstants.MIN_ARTICLE_CATEGORY_LENGHT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_CATEGORY_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}
