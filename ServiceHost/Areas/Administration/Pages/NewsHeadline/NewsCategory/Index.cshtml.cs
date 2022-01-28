using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsManagement.Application.Contracts.NewsCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.NewsHeadline.NewsCategory
{
    public class IndexModel : PageModel
    {
        public NewsCategorySearchModel searchModel;

        public List<NewsCategoryViewModel> NewsCategories;
        private readonly INewsCategoryApplication _newsCategoryApplication;

        public IndexModel(INewsCategoryApplication newsCategoryApplication)
        {
            _newsCategoryApplication = newsCategoryApplication;
        }

        public void OnGet(NewsCategorySearchModel searchModel)
        {
            NewsCategories = _newsCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateNewsCategory());
        }

        public JsonResult OnPostCreate(CreateNewsCategory command)
        {
            var result = _newsCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _newsCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditNewsCategory command)
        {

            var result = _newsCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
