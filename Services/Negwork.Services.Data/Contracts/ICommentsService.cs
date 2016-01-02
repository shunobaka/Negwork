namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;

    public interface ICommentsService
    {
        Comment CreateComment(string userId, string content, int articleId);
    }
}
