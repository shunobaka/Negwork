using System.ComponentModel.DataAnnotations;

namespace Negwork.WebApi.Models.RatingModels
{
    public class RatingCreationModel
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
    }
}