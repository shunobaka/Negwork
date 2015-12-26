namespace Negwork.Services.Data
{
    using System.Linq;

    using Contracts;
    using Negwork.Data.Models;
    using Negwork.Data.Repositories;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users
                .All()
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }
    }
}
