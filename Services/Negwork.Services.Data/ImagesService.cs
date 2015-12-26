namespace Negwork.Services.Data
{
    using System;
    using System.Linq;
    using Negwork.Data.Models;
    using Contracts;
    using Negwork.Data.Repositories;
    using Common;

    public class ImagesService : IImagesService
    {
        private IRepository<Image> images;
        private IRepository<Vote> votes;

        public ImagesService(IRepository<Image> images, IRepository<Vote> votes)
        {
            this.images = images;
            this.votes = votes;
        }

        public Image CreateImage(string userId, string title, string description, DateTime publishDate, int categoryId)
        {
            var newImage = new Image()
            {
                Title = title,
                Description = description,
                OwnerId = userId,
                CategoryId = categoryId,
                DatePublished = publishDate
            };

            this.images.Add(newImage);
            this.images.SaveChanges();

            return newImage;
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        public Image GetById(int id)
        {
            return this.images
                .All()
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public ServiceResponse VoteImage(string userId, int id, VoteType vote)
        {
            var alreadyRated = this.votes.All().Any(v => v.UserId == userId && v.ImageId == id);

            if (alreadyRated)
            {
                return ServiceResponse.Duplicated;
            }

            var image = this.images
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (image == null)
            {
                return ServiceResponse.NotFound;
            }

            if (image.OwnerId == userId)
            {
                return ServiceResponse.Own;
            }

            var imageVote = new Vote()
            {
                UserId = userId,
                ImageId = id,
                Value = vote
            };

            image.Votes.Add(imageVote);

            if (vote == VoteType.UpVote)
            {
                image.Score++;
            }
            else
            {
                image.Score--;
            }

            images.SaveChanges();

            return ServiceResponse.Ok;
        }
    }
}
