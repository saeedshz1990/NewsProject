using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Application.Contracts.NewsCategory;

namespace ServiceHost.Areas.Administration.Pages.NewsHeadline.News
{
    public class CreateModel : PageModel
    {
        public CreateNews Command;
        public SelectList NewsCategories;

        private readonly INewsApplication _newsApplication;
        private readonly INewsCategoryApplication _newsCategoryApplication;

        public CreateModel(INewsApplication newsApplication,
            INewsCategoryApplication newsCategoryApplication)
        {
            _newsApplication = newsApplication;
            _newsCategoryApplication = newsCategoryApplication;
        }
        public void OnGet()
        {
            NewsCategories = new SelectList(_newsCategoryApplication.GetNewsCategories(), 
                "Id", "Name");
        }

        public IActionResult OnPost(CreateNews command)
        {
            var result = _newsApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
