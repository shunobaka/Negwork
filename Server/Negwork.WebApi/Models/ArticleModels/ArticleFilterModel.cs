namespace Negwork.WebApi.Models.ArticleModels
{
    using Common;

    public class ArticleFilterModel
    {
        public ArticleFilterModel()
        {
            this.Page = 1;
        }

        public string Filter { get; set; }

        public int? PageSize { get; set; }

        public OrderBy? OrderBy { get; set; }

        public int Page { get; set; }
    }
}