namespace Negwork.Services.Data
{
    using System;
    using Contracts;
    using Negwork.Data.Models;
    using Negwork.Data.Repositories;

    public class CommentsService : ICommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment CreateComment(string userId, string content, int articleId, DateTime? creationDate)
        {
            var comment = new Comment()
            {
                ArticleId = articleId,
                UserId = userId,
                Content = content,
                CreationDate = creationDate
            };

            comments.Add(comment);
            comments.SaveChanges();

            return comment;
        }
    }
}
