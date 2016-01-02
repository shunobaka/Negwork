namespace Negwork.WebApi.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models.CommentModels;
    using Services.Data.Contracts;
    using System;
    using System.Web.Http;

    public class CommentsController : ApiController
    {
        private ICommentsService data;

        public CommentsController(ICommentsService data)
        {
            this.data = data;
        }

        [Authorize]
        public IHttpActionResult Post(CommentCreationRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var created = this.data.CreateComment(
                this.User.Identity.GetUserId(),
                model.Content,
                model.ArticleId,
                DateTime.Now);

            return this.Ok(created);
        }
    }
}