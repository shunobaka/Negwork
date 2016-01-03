namespace Negwork.WebApi.Models.CommentModels
{
    using System;
    using Data.Models;
    using Negwork.WebApi.Infrastructure.Mappings;

    public class CommentResponseModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? CreationDate { get; set; }

        public UserIdentityResponseModel User { get; set; }
    }
}