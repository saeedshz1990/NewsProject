using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Application.Contracts.NewsCategory;

namespace ServiceHost.Areas.Administration.Pages.NewsHeadline.News
{
    public class EditModel : PageModel
    {
        public EditNews Command;
        public SelectList NewsCategories;

        private readonly INewsApplication _newsApplication;
        private readonly INewsCategoryApplication _newsCategoryApplication;

        public EditModel(INewsApplication newsApplication, 
            INewsCategoryApplication newsCategoryApplication)
        {
            _newsApplication = newsApplication;
            _newsCategoryApplication = newsCategoryApplication;
        }

        public void OnGet(long id)
        {
            Command=_newsApplication.GetDetails(id);
            NewsCategories=new SelectList (_newsCategoryApplication.GetNewsCategories(), "Id", "Name");
        }

        public IActionResult OnPost(EditNews command)
        {
            var result = _newsApplication.Edit(command);
            return RedirectToPage("/Index");
        }
    }
}
