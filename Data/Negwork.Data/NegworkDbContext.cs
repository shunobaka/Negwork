namespace Negwork.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    
    public class NegworkDbContext : IdentityDbContext<User>
    {
        public NegworkDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static NegworkDbContext Create()
        {
            return new NegworkDbContext();
        }
    }
}
