namespace Negwork.Services.Data.Contracts
{
    using System.Linq;
    using Negwork.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User GetByName(string name);
    }
}
