namespace Negwork.WebApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Web.Http;

    public class IdentityController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            int user = 0;

            return this.Ok(user);
        }
    }
}