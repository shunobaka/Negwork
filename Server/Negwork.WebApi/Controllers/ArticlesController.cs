﻿namespace Negwork.WebApi.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.ArticleModels;
    using Services.Data.Contracts;
    using Services.Data;
    using System.Linq;
    using System.Web.Http;
    using System;
    using Services.Common;
    using AutoMapper;

    [RoutePrefix("api/Articles")]
    public class ArticlesController : ApiController
    {
        private IArticlesService data;

        public ArticlesController(IArticlesService data)
        {
            this.data = data;
        }
        
        public IHttpActionResult Get([FromUri]FilterModel model)
        {
            var articles = this.data
                .GetAll()
                .FilterArticles(model)
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(articles);
        }

        public IHttpActionResult Get(int id)
        {
            var article = this.data.GetById(id);

            if (article == null)
            {
                return this.NotFound();
            }

            var result = Mapper.Map<ArticleResponseModel>(article);

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(ArticleCreationRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var created = this.data.CreateArticle(
                this.User.Identity.GetUserId(),
                model.Title,
                model.Description,
                DateTime.Now,
                model.CategoryId);

            //TODO: this.Created
            return this.Ok();
        }
    }
}