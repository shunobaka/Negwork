namespace Negwork.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Article> articles;
        private ICollection<Image> images;
        private ICollection<ArticleRating> ratings;
        private ICollection<ImageVote> votes;

        public User()
        {
            this.articles = new HashSet<Article>();
            this.images = new HashSet<Image>();
            this.ratings = new HashSet<ArticleRating>();
            this.votes = new HashSet<ImageVote>();
        }


        [Required]
        [MinLength(ModelConstants.MIN_USER_FIRSTNAME_LENGTH)]
        [MaxLength(ModelConstants.MAX_USER_FIRSTNAME_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.MIN_USER_LASTNAME_LENGTH)]
        [MaxLength(ModelConstants.MAX_USER_LASTNAME_LENGTH)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }
    
        [MaxLength(ModelConstants.MAX_USER_ADDITIONAL_INFO_LENGTH)]
        public string AdditionalInfo { get; set; }

        [Url]
        public string ProfileImage { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

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

        public virtual ICollection<ArticleRating> Ratings
        {
            get
            {
                return this.ratings;
            }
            set
            {
                this.ratings = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
