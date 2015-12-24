namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;
    using System;
    using System.Linq;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        Article GetById(int id);

        Article CreateArticle(string userId, string title, string description, DateTime publishDate, int categoryId);

        ServiceResponse RateArticle(string userId, int id, int rating);
    }
}
