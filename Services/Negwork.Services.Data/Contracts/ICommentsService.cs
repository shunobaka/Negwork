namespace Negwork.Services.Data.Contracts
{
    using System;
    using Negwork.Data.Models;

    public interface ICommentsService
    {
        Comment CreateComment(string userId, string content, int articleId, DateTime? creationDate);
    }
}
