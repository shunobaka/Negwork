namespace Negwork.Services.Data.Contracts
{
    using System.Linq;
    using Negwork.Data.Models;
    using Common;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User GetByName(string name);

        ServiceResponse UpdateInfo(string userId, string firstName, string lastName, string additionalInfo, string profileImage);
    }
}
