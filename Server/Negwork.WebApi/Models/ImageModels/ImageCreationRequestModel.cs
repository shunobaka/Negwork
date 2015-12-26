namespace Negwork.WebApi.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class ImageCreationRequestModel
    {
        [Required]
        [Url(ErrorMessage = ErrorMessages.IMAGE_URL_INVALID)]
        public string Url { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_IMAGE_TITLE_LENGHT, 
            ErrorMessage = ErrorMessages.IMAGE_TITLE_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_IMAGE_TITLE_LENGTH, 
            ErrorMessage = ErrorMessages.IMAGE_TITLE_TOO_LONG)]
        public string Title { get; set; }

        [MinLength(ModelConstants.MIN_IMAGE_DESCRIPTION_LENGTH,
            ErrorMessage = ErrorMessages.IMAGE_DESCRIPTION_TOO_SHORT)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string OwnerId { get; set; }
    }
}