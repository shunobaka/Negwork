namespace Negwork.Services.Data
{
    using System.Linq;

    using Common;
    using Negwork.Data.Models;

    public static class FilterExtensions
    {
        public static IQueryable<Article> FilterArticles(this IQueryable<Article> query, FilterModel filters)
        {
            if (filters == null)
            {
                return query;
            }

            if (filters.Category != null)
            {
                query = query.Where(a => a.Category.Name.ToLower() == filters.Category.ToLower());
            }

            query = query.OrderByDescending(a => a.DatePublished);

            if (filters.OrderType == "asc")
            {
                if (filters.OrderBy == "date")
                {
                    query = query.OrderBy(a => a.DatePublished);
                }

                if (filters.OrderBy == "rating")
                {
                    query = query.OrderBy(a => a.NumberOfRatings != 0 ? ((double)a.AllRatings / (double)a.NumberOfRatings) : 0);
                }

                if (filters.OrderBy == "userrating")
                {
                    // TODO: Extend
                    // query = query.OrderBy(a => (d))
                }

                if (filters.OrderBy == "title")
                {
                    query = query.OrderBy(a => a.Title);
                }

                if (filters.OrderBy == "category")
                {
                    query = query.OrderBy(a => a.Category);
                }
            }
            else
            {
                if (filters.OrderBy == "date")
                {
                    query = query.OrderByDescending(a => a.DatePublished);
                }

                if (filters.OrderBy == "rating")
                {
                    query = query.OrderByDescending(a => a.NumberOfRatings != 0 ? ((double)a.AllRatings / (double)a.NumberOfRatings) : 0);
                }

                if (filters.OrderBy == "userrating")
                {
                    // TODO: Extend
                    // query = query.OrderBy(a => (d))
                }

                if (filters.OrderBy == "title")
                {
                    query = query.OrderByDescending(a => a.Title);
                }

                if (filters.OrderBy == "category")
                {
                    query = query.OrderByDescending(a => a.Category);
                }
            }

            if (filters.Filter != null)
            {
                if (filters.FilterBy == "title")
                {
                    query = query.Where(a => a.Title.ToLower().Contains(filters.Filter.ToLower()));
                }

                if (filters.FilterBy == "user")
                {
                    query = query.Where(a => a.Author.UserName.ToLower().Contains(filters.Filter.ToLower()));
                }

                if (filters.FilterBy == "description")
                {
                    query = query.Where(a => a.Description.ToLower().Contains(filters.Filter.ToLower()));
                }
            }

            int size = filters.PageSize;
            int page = filters.Page;

            query = query
                .Skip((page - 1) * size)
                .Take(size);

            return query;
        }

        public static IQueryable<Image> FilterImages(this IQueryable<Image> query, FilterModel filters)
        {
            if (filters == null)
            {
                return query;
            }

            if (filters.Category != null)
            {
                query = query.Where(i => i.Category.Name.ToLower() == filters.Category.ToLower());
            }

            query = query.OrderByDescending(i => i.DatePublished);

            if (filters.OrderType == "asc")
            {
                if (filters.OrderBy == "date")
                {
                    query = query.OrderBy(i => i.DatePublished);
                }

                if (filters.OrderBy == "score")
                {
                    query = query.OrderBy(i => i.Score);
                }

                if (filters.OrderBy == "userrating")
                {
                    // TODO: Extend
                    // query = query.OrderBy(a => (d))
                }

                if (filters.OrderBy == "title")
                {
                    query = query.OrderBy(i => i.Title);
                }

                if (filters.OrderBy == "category")
                {
                    query = query.OrderBy(i => i.Category);
                }
            }
            else
            {
                if (filters.OrderBy == "date")
                {
                    query = query.OrderByDescending(i => i.DatePublished);
                }

                if (filters.OrderBy == "score")
                {
                    query = query.OrderByDescending(i => i.Score);
                }

                if (filters.OrderBy == "userrating")
                {
                    // TODO: Extend
                    // query = query.OrderBy(a => (d))
                }

                if (filters.OrderBy == "title")
                {
                    query = query.OrderByDescending(i => i.Title);
                }

                if (filters.OrderBy == "category")
                {
                    query = query.OrderByDescending(i => i.Category);
                }
            }

            if (filters.Filter != null)
            {
                if (filters.FilterBy == "title")
                {
                    query = query.Where(i => i.Title.ToLower().Contains(filters.Filter.ToLower()));
                }

                if (filters.FilterBy == "user")
                {
                    query = query.Where(i => i.Owner.UserName.ToLower().Contains(filters.Filter.ToLower()));
                }

                if (filters.FilterBy == "description")
                {
                    query = query.Where(i => i.Description.ToLower().Contains(filters.Filter.ToLower()));
                }
            }

            int size = filters.PageSize;
            int page = filters.Page;

            query = query
                .Skip((page - 1) * size)
                .Take(size);

            return query;
        }
    }
}
