namespace Negwork.WebApi.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Data.Repositories;
    using Microsoft.AspNet.Identity;
    using Models.ArticleModels;
    using Services.Data.Contracts;
    using Services.Data;
    using System.Linq;
    using System.Web.Http;

    public class ArticlesController : ApiController
    {
        private IArticlesService data;

        public ArticlesController(IArticlesService data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var articles = this.data
                .GetAll()
                .ProjectTo<ArticleResponseModel>()
                .ToList();


            if (articles.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(articles);
        }

        public IHttpActionResult Get(int id)
        {
            var article = this.data.GetById(id);

            if (article == null)
            {
                return this.NotFound();
            }

            var result = new ArticleResponseModel()
            {
                Id = article.Id,
                DatePublished = article.DatePublished,
                Description = article.Description,
                Title = article.Title
            };

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(ArticleCreationModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var created = this.data.CreateArticle(
                this.User.Identity.GetUserId(),
                model.Title,
                model.Description,
                model.DatePublished);

            //TODO: this.Created
            return this.Ok();
        }
    }
}