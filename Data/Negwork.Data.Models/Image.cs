namespace Negwork.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        private ICollection<ImageVote> votes;

        public Image()
        {
            this.votes = new HashSet<ImageVote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_IMAGE_TITLE_LENGHT)]
        [MaxLength(ModelConstants.MAX_IMAGE_TITLE_LENGTH)]
        public string Title { get; set; }

        public string OwnerId { get; set; }
        
        public User Owner { get; set; }

        public virtual ICollection<ImageVote> Votes
        {
            get
            {
                return this.votes;
            }
            set
            {
                this.votes = value;
            }
        }
    }
}
