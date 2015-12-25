namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;
    using System.Linq;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetArticleCategories();

        IQueryable<Category> GetImageCategories();

        Category GetById(int id);

        Category CreateCategory(string name, string image);
    }
}
