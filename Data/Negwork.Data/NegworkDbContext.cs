namespace Negwork.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class NegworkDbContext : IdentityDbContext<User>
    {
        public NegworkDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public static NegworkDbContext Create()
        {
            return new NegworkDbContext();
        }
    }
}
