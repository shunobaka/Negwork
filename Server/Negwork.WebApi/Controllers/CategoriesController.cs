namespace Negwork.WebApi.Controllers
{
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.CategoryModels;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using AutoMapper;

    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private ICategoriesService data;

        public CategoriesController(ICategoriesService data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var result = this.data
                .GetAll()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var category = this.data.GetById(id);

            if (category == null)
            {
                return this.NotFound();
            }

            var result = Mapper.Map<CategoryResponseModel>(category);

            return this.Ok(result);
        }

        public IHttpActionResult Post(CategoryCreationModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = this.data.CreateCategory(model.Name, model.Image);

            if (category == null)
            {
                return this.BadRequest("Category name is already taken.");
            }

            return this.Ok(category);
        }

        [HttpGet]
        [Route("Articles")]
        public IHttpActionResult GetArticleCategories()
        {
            var result = this.data
                .GetArticleCategories()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [HttpGet]
        [Route("Images")]
        public IHttpActionResult GetImageCategories()
        {
            var result = this.data
                .GetImageCategories()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}