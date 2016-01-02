namespace Negwork.WebApi.Models.CommentModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreationRequestModel
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int ArticleId { get; set; }
    }
}