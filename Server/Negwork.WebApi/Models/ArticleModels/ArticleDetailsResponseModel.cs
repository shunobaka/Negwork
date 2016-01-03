namespace Negwork.WebApi.Models.ArticleModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CategoryModels;
    using CommentModels;
    using Data.Models;
    using Negwork.WebApi.Infrastructure.Mappings;

    public class ArticleDetailsResponseModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryResponseModel Category { get; set; }

        public DateTime? DatePublished { get; set; }

        public UserIdentityResponseModel Author { get; set; }

        public double Rating { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleDetailsResponseModel>()
                .ForMember(a => a.Rating, opts => opts.MapFrom(a => a.NumberOfRatings != 0 ? (double)a.AllRatings / (double)a.NumberOfRatings : 0));
        }
    }
}