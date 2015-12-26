namespace Negwork.WebApi.Models.ImageModels
{
    using System;
    using CategoryModels;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ImageResponseModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryResponseModel Category { get; set; }

        public DateTime? DatePublished { get; set; }

        public UserIdentityResponseModel Owner { get; set; }
    }
}