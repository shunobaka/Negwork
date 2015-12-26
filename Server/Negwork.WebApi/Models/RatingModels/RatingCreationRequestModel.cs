namespace Negwork.WebApi.Models.RatingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RatingCreationRequestModel
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}