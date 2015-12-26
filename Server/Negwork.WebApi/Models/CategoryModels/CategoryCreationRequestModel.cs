namespace Negwork.WebApi.Models.CategoryModels
{
    using Negwork.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CategoryCreationRequestModel
    {
        [Required]
        [MinLength(ModelConstants.MIN_ARTICLE_CATEGORY_LENGHT,
            ErrorMessage = ErrorMessages.CATEGORY_NAME_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_ARTICLE_CATEGORY_LENGTH,
            ErrorMessage = ErrorMessages.CATEGORY_NAME_TOO_LONG)]
        public string Name { get; set; }

        [Url(ErrorMessage = ErrorMessages.CATEGORY_IMAGE_INVALID)]
        [Required]
        public string Image { get; set; }
    }
}