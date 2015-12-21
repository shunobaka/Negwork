namespace Negwork.WebApi.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System;
    using System.Web.Http;

    public class RatingsController : ApiController
    {
        private IArticlesService data;

        public RatingsController(IArticlesService data)
        {
            this.data = data;
        }

        [Authorize]
        public IHttpActionResult Post(int id, int rating)
        {
            var ratedArticle = data.RateArticle(this.User.Identity.GetUserId(), id, rating);

            if (ratedArticle == null)
            {
                return this.BadRequest("There was a problem rating the article.");
            }

            return this.Ok();
        }
    }
}