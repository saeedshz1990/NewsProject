using _01_NewsProjectQuery.Contracts.News;
using _01_NewsProjectQuery.Contracts.NewsCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class NewsModel : PageModel
    {
        public NewsQueryModel News;
        public List<NewsQueryModel> LatestNews;
        public List<NewsCategoryQueryModel> NewsCategories;
        private readonly INewsQuery _newsQuery;
        private readonly INewsCategoryQuery _newsCategoryQuery;
        //private readonly ICommentApplication _commentApplication;
        public NewsModel(INewsQuery newsQuery, INewsCategoryQuery newsCategoryQuery)
        {
            _newsQuery=newsQuery;
            _newsCategoryQuery=newsCategoryQuery;
        }

        public void OnGet(string id)
        {
            News = _newsQuery.GetNewsDetails(id);
            LatestNews = _newsQuery.LatestNews();
            NewsCategories = _newsCategoryQuery.GetNewsCategories();
        }

        public IActionResult OnPost(/*AddComment command,*/ string articleSlug)
        {
            //command.Type = CommentType.Article;
            //var result = _commentApplication.Add(command);
            return RedirectToPage("/News", new { Id = articleSlug });
        }
    }
}
