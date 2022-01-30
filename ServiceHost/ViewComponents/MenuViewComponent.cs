using _01_NewsProjectQuery;
using _01_NewsProjectQuery.Contracts.NewsCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly INewsCategoryQuery _newsCategoryQuery;

        public MenuViewComponent(INewsCategoryQuery newsCategoryQuery)
        {
            _newsCategoryQuery = newsCategoryQuery;
        }


        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                NewsCategories = _newsCategoryQuery.GetNewsCategories(),
              
            };
            return View(result);
        }
    }
}
