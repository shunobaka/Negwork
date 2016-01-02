namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;
    using System;

    public interface ICommentsService
    {
        Comment CreateComment(string userId, string content, int articleId, DateTime? creationDate);
    }
}
