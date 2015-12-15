using Negwork.Data.Models;
using Negwork.Data.Repositories;
using System.Linq;

namespace Negwork.Services.Data
{
    public class UsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        //public User GetById(string id)
        //{
        //    var user = this.users
        //        .All()
        //        .Where(u => u.GenerateUserIdentityAsync.id == id)
        //}
    }
}
