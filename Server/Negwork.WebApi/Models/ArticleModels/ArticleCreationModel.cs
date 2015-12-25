namespace Negwork.WebApi.Models.ArticleModels
{
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArticleCreationModel
    {
        private static string TITLE_TOO_SHORT_ERROR = string.Format("Title should be at least {0} characters long!", ModelConstants.MIN_ARTICLE_TITLE_LENGHT);

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_TITLE_LENGHT, 
            ErrorMessage = ErrorMessages.ARTICLE_TITLE_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_TITLE_LENGTH,
            ErrorMessage = ErrorMessages.ARTICLE_TITLE_TOO_LONG)]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_DESCRIPTION_LENGTH)]
        public string Description { get; set; }
    }
}