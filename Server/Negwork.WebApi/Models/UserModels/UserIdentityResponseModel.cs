namespace Negwork.WebApi.Models
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserIdentityResponseModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfileImage { get; set; }

        public string AdditionalInfo { get; set; }
    }
}