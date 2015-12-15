namespace Negwork.WebApi.Models.ArticleModels
{
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArticleResponseModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_TITLE_LENGHT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_TITLE_LENGTH)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_DESCRIPTION_LENGTH)]
        public string Description { get; set; }

        public DateTime? DatePublished { get; set; }
    }
}