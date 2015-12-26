namespace Negwork.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        private ICollection<Vote> votes;

        public Image()
        {
            this.votes = new HashSet<Vote>();
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

        [MinLength(ModelConstants.MIN_IMAGE_DESCRIPTION_LENGTH)]
        public string Description { get; set; }

        public DateTime? DatePublished { get; set; }

        public int Score { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string OwnerId { get; set; }
        
        public User Owner { get; set; }

        public virtual ICollection<Vote> Votes
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
