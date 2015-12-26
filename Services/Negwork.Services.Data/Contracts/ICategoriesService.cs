namespace Negwork.Services.Data.Contracts
{
    using System.Linq;
    using Negwork.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetArticleCategories();

        IQueryable<Category> GetImageCategories();

        Category GetById(int id);

        Category CreateCategory(string name, string image);
    }
}
