using NewsManagement.Application.Contracts.NewsCategory;
using System.Collections.Generic;

namespace NewsManagement.Application.Contracts.News
{
    public class NewsSearchModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public List<NewsCategoryViewModel> Categories { get; set; }
    }
}
