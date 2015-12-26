namespace Negwork.Services.Data.Contracts
{
    using Negwork.Data.Models;
    using Common;
    using System;
    using System.Linq;

    public interface IImagesService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);

        Image CreateImage(string userId, string title, string description, DateTime publishDate, int categoryId);

        ServiceResponse VoteImage(string userId, int id, VoteType vote);
    }
}
