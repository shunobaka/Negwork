namespace Negwork.WebApi.Controllers
{
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.RatingModels;
    using Services.Common;
    using Services.Data.Contracts;

    public class RatingsController : ApiController
    {
        private IArticlesService data;

        public RatingsController(IArticlesService data)
        {
            this.data = data;
        }

        [Authorize]
        public IHttpActionResult Post(RatingCreationRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = this.data.RateArticle(this.User.Identity.GetUserId(), model.ArticleId, model.Rating);

            if (result == ServiceResponse.Duplicated)
            {
                return this.BadRequest("You have already rated this article!");
            }
            
            if (result == ServiceResponse.NotFound)
            {
                return this.BadRequest("The article could not be found!");
            }

            if (result == ServiceResponse.Own)
            {
                return this.BadRequest("You cannot rate your own article!");
            }

            return this.Ok();
        }
    }
}