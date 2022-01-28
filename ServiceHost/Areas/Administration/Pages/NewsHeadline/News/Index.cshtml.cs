using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Application.Contracts.NewsCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.NewsHeadline.News
{
    public class IndexModel : PageModel
    {
        public NewsSearchModel SearchModel;
        public List<NewsViewModel> News;
        public SelectList NewsCategories;

        private readonly INewsApplication _newsApplication;
        private readonly INewsCategoryApplication _newsCategoryApplication;

        public IndexModel(INewsApplication newsApplication,
            INewsCategoryApplication newsCategoryApplication)
        {
            _newsApplication = newsApplication;
            _newsCategoryApplication = newsCategoryApplication;
        }

        public void OnGet(NewsSearchModel searchModel)
        {
            NewsCategories = new SelectList(_newsCategoryApplication.GetNewsCategories(), "Id", "Name");
            News = _newsApplication.Search(searchModel);
        }
    }
}
