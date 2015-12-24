﻿namespace Negwork.WebApi.Models.ArticleModels
{
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CategoryModels;

    public class ArticleResponseModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public CategoryResponseModel Category { get; set; }

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