namespace Negwork.Services.Data.Contracts
{
    using System;
    using System.Linq;

    using Common;
    using Negwork.Data.Models;

    public interface IImagesService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);

        Image CreateImage(string userId, string title, string description, DateTime publishDate, int categoryId);

        ServiceResponse VoteImage(string userId, int id, VoteType vote);
    }
}
