namespace Negwork.WebApi.Models.ArticleModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class ArticleCreationRequestModel
    {
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