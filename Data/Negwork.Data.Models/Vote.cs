namespace Negwork.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public VoteType Value { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
