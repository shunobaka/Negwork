namespace Negwork.WebApi.Models
{
    using Negwork.Data.Models;
    using Negwork.WebApi.Infrastructure.Mappings;
    using System;

    public class UserIdentityResponseModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfileImage { get; set; }
    }
}