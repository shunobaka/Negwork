namespace Negwork.WebApi.Extensions
{
    using Data.Models;
    using WebApi.Models.ArticleModels;
    using System.Linq;
    using Common;

    public static class QueryableExtensions
    {
        public static IQueryable<Article> FilterArticles(this IQueryable<Article> query, ArticleFilterModel filters)
        {
            if (filters == null)
            {
                return query;
            }

            if (filters.OrderBy == OrderBy.Date)
            {
                query = query.OrderBy(a => a.DatePublished);
            }

            if (filters.OrderBy == OrderBy.Rating)
            {
                query = query.OrderBy(a => (double)a.AllRatings / (double)a.NumberOfRatings);
            }

            if (filters.OrderBy == OrderBy.Title)
            {
                query = query.OrderBy(a => a.Title);
            }

            if (filters.Filter != null)
            {
                query = query.Where(a =>
                    a.Title.Contains(filters.Filter) ||
                    a.Description.Contains(filters.Filter) ||
                    a.Author.UserName.Contains(filters.Filter) ||
                    a.Category.Contains(filters.Filter));
            }

            int size = 0;
            int page = filters.Page;

            if (filters.PageSize != null)
            {
                size = (int)filters.PageSize;
            }

            query = query
                .Skip((page - 1) * size)
                .Take(size);

            return query;
        }
    }
}
