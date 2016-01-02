namespace Negwork.Services.Data
{
    using System.Linq;
    using Contracts;
    using Negwork.Data.Models;
    using Negwork.Data.Repositories;
    using Common;

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

        public User GetByName(string name)
        {
            return this.users
                .All()
                .Where(u => u.UserName == name)
                .FirstOrDefault();
        }

        public ServiceResponse UpdateInfo(
            string userId,
            string firstName,
            string lastName,
            string additionalInfo,
            string profileImage)
        {
            var user = users
                .All()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (user == null)
            {
                return ServiceResponse.NotFound;
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                user.FirstName = firstName;
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                user.LastName = lastName;
            }

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                user.AdditionalInfo = additionalInfo;
            }

            if (!string.IsNullOrWhiteSpace(profileImage))
            {
                user.ProfileImage = profileImage;
            }

            users.SaveChanges();
            return ServiceResponse.Ok;
        }
    }
}
