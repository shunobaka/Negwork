namespace Negwork.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.ImageModels;
    using Services.Common;
    using Services.Data;

    public class ImagesController : ApiController
    {
        private ImagesService data;

        public ImagesController(ImagesService data)
        {
            this.data = data;
        }

        public IHttpActionResult Get([FromUri]FilterModel model)
        {
            var images = this.data
                .GetAll()
                .FilterImages(model)
                .ProjectTo<ImageResponseModel>()
                .ToList();

            return this.Ok(images);
        }

        public IHttpActionResult Get(int id)
        {
            var image = this.data.GetById(id);

            if (image == null)
            {
                return this.NotFound();
            }

            var result = Mapper.Map<ImageResponseModel>(image);

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(ImageCreationRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var created = this.data.CreateImage(
                this.User.Identity.GetUserId(),
                model.Title,
                model.Description,
                DateTime.Now,
                model.CategoryId);

            // TODO: this.Created
            return this.Ok();
        }
    }
}