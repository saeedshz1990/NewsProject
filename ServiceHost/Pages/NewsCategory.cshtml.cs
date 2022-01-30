using _01_NewsProjectQuery.Contracts.News;
using _01_NewsProjectQuery.Contracts.NewsCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class NewsCategoryModel : PageModel
    {
        public NewsCategoryQueryModel NewsCategory;
        public List<NewsCategoryQueryModel> NewsCategories;
        public List<NewsQueryModel> LatestNews;

        private readonly INewsQuery _newsQuery;
        private readonly INewsCategoryQuery _newsCategoryQuery;

        public NewsCategoryModel(INewsQuery newsQuery, INewsCategoryQuery newsCategoryQuery)
        {
            _newsQuery = newsQuery;
            _newsCategoryQuery = newsCategoryQuery;
        }

        public void OnGet(string id)
        {
            LatestNews = _newsQuery.LatestNews();
            NewsCategory = _newsCategoryQuery.GetNewsCategory(id);
            NewsCategories = _newsCategoryQuery.GetNewsCategories();
        }
    }
}
