namespace Negwork.WebApi.Models.UserModels
{
    using System;
    using System.Collections.Generic;
    using ArticleModels;
    using Data.Models;
    using ImageModels;
    using Infrastructure.Mappings;

    public class UserInfoResponseModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfileImage { get; set; }

        public string AdditionalInfo { get; set; }

        public ICollection<ArticleResponseModel> Articles { get; set; }

        public ICollection<ImageResponseModel> Images { get; set; }
    }
}