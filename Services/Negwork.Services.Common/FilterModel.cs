namespace Negwork.Services.Common
{
    public class FilterModel
    {
        public FilterModel()
        {
            this.Page = 1;
            this.OrderBy = "date";
            this.PageSize = 10;
            this.OrderType = "desc";
        }

        public string Category { get; set; }

        public string Filter { get; set; }

        public string FilterBy { get; set; }

        public string OrderBy { get; set; }

        public string OrderType { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
