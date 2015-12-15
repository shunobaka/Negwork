namespace Negwork.WebApi.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Data.Repositories;
    using Models.ArticleModels;
    using Services.Data;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class ArticlesController : ApiController
    {
        private ArticleService data;

        public ArticlesController(ArticleService data)
        {
            this.data = data;
        }

        public ArticlesController()
            : this(new ArticleService(new GenericRepository<Article>(new Data.NegworkDbContext())))
        {
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
        [HttpPost]
        public IHttpActionResult Post(ArticleCreationModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var created = this.data.CreateArticle(
                "cd4b7a44-da35-4f2b-ac13-2ae9eec01780",
                model.Title,
                model.Description,
                model.DatePublished);

            //TODO: this.Created
            return this.Ok();
        }
    }
}