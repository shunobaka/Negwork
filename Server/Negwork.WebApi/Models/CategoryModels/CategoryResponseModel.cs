namespace Negwork.WebApi.Models.CategoryModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class CategoryResponseModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}