namespace Negwork.Services.Data.Contracts
{
    using System.Linq;
    using Common;
    using Negwork.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User GetByName(string name);

        ServiceResponse UpdateInfo(string userId, string firstName, string lastName, string additionalInfo, string profileImage);
    }
}
