namespace Negwork.WebApi.Models.CategoryModels
{
    using Negwork.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CategoryCreationModel
    {
        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_CATEGORY_LENGHT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_CATEGORY_LENGTH)]
        public string Name { get; set; }
    }
}