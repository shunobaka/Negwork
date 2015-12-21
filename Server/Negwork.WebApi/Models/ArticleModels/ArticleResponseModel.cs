namespace Negwork.WebApi.Models.ArticleModels
{
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class ArticleResponseModel : IMapFrom<Article>, IHaveCustomMappings
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

        public UserIdentityResponseModel Author { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleResponseModel>()
                .ForMember(a => a.Rating, opts => opts.MapFrom(a => a.NumberOfRatings != 0 ? (double)a.AllRatings / (double)a.NumberOfRatings : 0));
        }
    }
}