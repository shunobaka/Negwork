﻿namespace Negwork.Services.Data
{
    using Negwork.Data.Models;
    using Negwork.Data.Repositories;
    using System;
    using System.Linq;

    public class ArticleService
    {
        private IRepository<Article> articles;

        public ArticleService(IRepository<Article> articles)
        {
            this.articles = articles;
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

        public Article CreateArticle(string userId, string title, string description, DateTime? publishDate)
        {
            var newArticle = new Article()
            {
                Title = title,
                AuthorId = userId,
                Description = description,
                DatePublished = publishDate
            };

            this.articles.Add(newArticle);
            this.articles.SaveChanges();

            return newArticle;
        }
    }
}
