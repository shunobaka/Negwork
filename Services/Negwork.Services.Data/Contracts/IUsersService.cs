namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);
    }
}
