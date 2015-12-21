namespace Negwork.Services.Data
{
    using Negwork.Data.Models;
    using Negwork.Data.Repositories;
    using Contracts;
    using System;
    using System.Linq;

    public class ArticlesService : IArticlesService
    {
        private IRepository<Article> articles;
        private IRepository<ArticleRating> ratings;

        public ArticlesService(IRepository<Article> articles, IRepository<ArticleRating> ratings)
        {
            this.articles = articles;
            this.ratings = ratings;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public Article GetById(int id)
        {
            return this.articles
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public Article CreateArticle(string userId, string title, string description, DateTime publishDate, string category)
        {
            var newArticle = new Article()
            {
                Title = title,
                AuthorId = userId,
                Description = description,
                DatePublished = publishDate,
                Category = category
            };

            this.articles.Add(newArticle);
            this.articles.SaveChanges();

            return newArticle;
        }

        public ServiceResponse RateArticle(string userId, int id, int rating)
        {
            var alreadyRated = this.ratings.All().Any(r => r.UserId == userId && r.ArticleId == id);

            if (alreadyRated)
            {
                return ServiceResponse.Duplicated;
            }

            var article = articles
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (article == null)
            {
                return ServiceResponse.NotFound;
            }

            if (article.AuthorId == userId)
            {
                return ServiceResponse.Own;
            }

            var articleRating = new ArticleRating()
            {
                UserId = userId,
                Value = rating
            };

            article.Ratings.Add(articleRating);
            article.AllRatings += rating;
            article.NumberOfRatings++;
            articles.SaveChanges();

            return ServiceResponse.Ok;
        }
    }
}
